
$(document).ready(function () {

    //rodo
    const xButton = document.getElementById("rodoc");
    const rodoToHide = document.getElementById("rodo");
    if (sessionStorage.getItem("rodo") == "ok") {
        rodoToHide.style.display = "none";
    }


    xButton.addEventListener("click", function (e) {
        e.preventDefault();
        rodoToHide.style.display = "none";
        sessionStorage.setItem("rodo", "ok");
    });


    //share

    function copyToClipboard(text) {
        var $temp = $("<input>");
        $("body").append($temp);
        $temp.val(text).select();
        document.execCommand("copy");
        $temp.remove();
    }

    let btn = document.getElementById('share');
    btn.addEventListener("click", function (e) {
        e.preventDefault();
        copyToClipboard("http://www.sasso.pl");
            let infoDiv = $(".copy-info");
            infoDiv.delay(900).fadeToggle();
            infoDiv.delay(900).fadeToggle();
    });

});
