/*Javascript to scroll to the #content section of 
the page at a speed of 1 second.*/
$(document).ready(function () {
    $(function () {
        $('a[href="#content"]').click(function () {
            var target = $(this.hash);
            if (target.length) {
                $('html, body').animate({
                    scrollTop: target.offset().top
                }, 1000);
                return false;
            }
        });
    });
    /*This adds a class .hovercolor to the FAQ on mouseover 
    and removes it on mouseout and click toggles at .3 seconds.*/
    $(document).ready(function () {
        $(".question").mouseover(function () {
            $(this).addClass("hovercolor");
        });
        $(".question").mouseout(function () {
            $(this).removeClass("hovercolor");
        });
        $(".answer").hide();
        $(".question").click(function () {
            $(this).next(".answer").slideToggle(300);
        })
    });

});
//javascript for mobile nav bar.
function myFunction() {
    var x = document.getElementById("myTopnav");
    if (x.className === "topnav") {
        x.className += " responsive";
    } else {
        x.className = "topnav";
    }

    $("ul a img").hide();
}
/*This funtion toggles the detail form to appear once 
check availability button is clicked at 0.6 seconds.*/
$(document).ready(function () {
    $("#check").click(function () {
        $("#form2").slideToggle(600).show();
    });
})
function book(message) {
    alert(message);
}