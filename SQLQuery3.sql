CREATE TABLE [dbo].[CustomerTour] (
    [CustomerTourID] INT           IDENTITY (1, 1) NOT NULL,
    [TourArea]       VARCHAR (255) NOT NULL,
    [Email]          VARCHAR (255) NOT NULL,
    [DateOfTour]     DATE          NOT NULL,
    [NumberOfPeople] INT           NOT NULL,
    CONSTRAINT [pk_CustomerTour] PRIMARY KEY CLUSTERED ([CustomerTourID] ASC),
    CONSTRAINT [fk_CustomerTour_Tour] FOREIGN KEY ([TourArea]) REFERENCES [dbo].[Tour] ([TourArea]),
    CONSTRAINT [fk_CustomerTour_Customer] FOREIGN KEY ([Email]) REFERENCES [dbo].[Customer] ([Email])
);
