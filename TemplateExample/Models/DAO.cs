using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;
using System.Web.Mvc;
using System.Configuration;

namespace BayviewHouse.Models
{
    public class DAO
    {
        SqlConnection con;
        public string message = "";
        public void Connection()
        {
            con = new SqlConnection(WebConfigurationManager.ConnectionStrings["DBCon"].ConnectionString);
        }

        public List<string> PopulateRooms()
        {
            List<string> rooms = new List<string>();
            Connection();
            SqlDataReader reader;
            SqlCommand cmd = new SqlCommand("SELECT RoomName FROM Room", con);
            string RoomName;
            try
            {
                con.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                  RoomName  = reader["RoomName"].ToString();
                    rooms.Add(RoomName);
                } 

            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return rooms;
        }

        public int InsertCustomer(Customer_Model c)
        {
            int count = 0;

            Connection();
            SqlCommand cmd = new SqlCommand("uspInsertIntoCustomer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@email", c.Email);
            cmd.Parameters.AddWithValue("@first", c.FirstName);
            cmd.Parameters.AddWithValue("@last", c.LastName);            
            cmd.Parameters.AddWithValue("@phone", c.Phone);
            cmd.Parameters.AddWithValue("@pass", c.Password);
            try
            {
                con.Open();
                count = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                message = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return count;

        }

        public List<Tour_Model> PopulateTours()
        {
            List<Tour_Model> tours = new List<Tour_Model>();

            Connection();
            SqlDataReader reader;
            SqlCommand cmd = new SqlCommand("SELECT * FROM Tour", con);

            try
            {
                con.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Tour_Model tour = new Tour_Model();
                    tour.TourArea = (reader["TourArea"].ToString());
                    tour.CompanyID = int.Parse(reader["CompanyID"].ToString());
                    tour.TourID = int.Parse(reader["TourID"].ToString());
                    tour.TimeDurationMins = int.Parse(reader["TimeDurationMins"].ToString());
                    tour.PricePerPerson = decimal.Parse(reader["PricePerPerson"].ToString());

                    tours.Add(tour);
                }

            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return tours;
        }

        public int InsertBooking(Booking_Model booking)
        {
            Connection();
            int count = 0;
            SqlCommand cmd = new SqlCommand("uspInsertIntoBooking", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Email", booking.Email);
            cmd.Parameters.AddWithValue("@RoomName", booking.RoomName);
            cmd.Parameters.AddWithValue("@ArrivalDate", booking.ArrivalDate);
            cmd.Parameters.AddWithValue("@DepartureDate", booking.DepartureDate);
            cmd.Parameters.AddWithValue("@CardHolderName", booking.CardHolderName);
            cmd.Parameters.AddWithValue("@CardType", booking.CardType);
            cmd.Parameters.AddWithValue("@CardNumber", booking.CreditCardNumber);
            cmd.Parameters.AddWithValue("@CardExpiry", booking.ExpiryDate);
            cmd.Parameters.AddWithValue("@SecurityNumber", booking.SecurityNumber);

            try
            {
                con.Open();
                count = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                message = ex.Message;

            }
            finally
            {
                con.Close();
            }
            return count;
        }
        public string CheckLogin(Customer_Model c)
        {
            c.FirstName = null;
            Connection();
            SqlDataReader reader;
            SqlCommand command = new SqlCommand("uspCheckLogin", con);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@email", c.Email);
            command.Parameters.AddWithValue("@pass", c.Password);
            try
            {
                con.Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    c.FirstName = reader["FirstName"].ToString();
                }
            }
            catch(Exception ex)
            {
                message = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return c.FirstName;
        }
    }   
}