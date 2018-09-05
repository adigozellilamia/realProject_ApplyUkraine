$(document).ready(function () {
    $(".btn-apply-ukraine").click(function () {
        console.log("Salam")
        $(".form-invitation").slideToggle();
    })
    //$(".invitation-letter-overlay-close").click(function () {
    //    $(".invitation-letter-overlay").css("display", "none");
    //})

    //$(".invitation-letter-checker").click(function () {
    //    $(".invitation-letter-overlay").css("display", "block");
    //});
})

window.LiqPayCheckoutCallback = function () {
    LiqPayCheckout.init({
        data: "eyJwdWJsaWNfa2V5IjoiaTgwMDI4NzQ4NTQiLCJ2ZXJzaW9uIjoiMyIsImFjdGlvbiI6InBheSIsImFtb3VudCI6IjMiLCJjdXJyZW5jeSI6IlVTRCIsImRlc2NyaXB0aW9uIjoidGVzdCIsIm9yZGVyX2lkIjoiMDAwMDAxIn0=",
        signature: "UJuRHMkFkq2Dvvogg/UG5mrJBvQ=",
        embedTo: "#liqpay_checkout",
        language: "ru",
        mode: "embed" // embed || popup
    }).on("liqpay.callback", function (data) {
        console.log(data.status);
        console.log(data);
    }).on("liqpay.ready", function (data) {
        // ready
    }).on("liqpay.close", function (data) {
        // close
    });
};