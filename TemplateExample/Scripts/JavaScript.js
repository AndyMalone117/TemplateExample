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
function myFunction() {
    var x = document.getElementById("myTopnav");
    if (x.className === "topnav") {
        x.className += " responsive";
    } else {
        x.className = "topnav";
    }

    $("ul a img").hide();
}

function book(message) {
    alert(message);
}