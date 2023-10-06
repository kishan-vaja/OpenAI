$(document).ready(function () {
    var h1 = document.querySelector("h1");
    h1.addEventListener("input", function () {
        this.setAttribute("data-heading", this.innerText);
    });

    $("#imgContainer").hover(function () {
        //site.alerts.success("Test");
        //$("#button").toggle();
        $("#button").fadeIn("slow");
        $("#button").click(function () {
            $("#imgContainer").animate({ left: '250px', bottom: '100px' });
        });
    });
});