﻿$(document).ready(function () {
    $('.js-example-basic-single').select2();
});
function onSuccess() {
    $('#loader').addClass('hidden');
    Swal.fire({
        title: "Congratulations!!",
        text: "Thank you for your order! We've received it and will process it promptly. You'll receive a confirmation email shortly. Expect delivery within 7 days.",
        icon: "success"
    }).then(function () {
        window.location = "/Home/Index";
    });
}
function onBegin() {
    $('#loader').removeClass('hidden');
}
function onFailure() {

}
function onSuccessapi(response) {
    $('#loader').addClass('hidden');
    Swal.fire({
        title: "The Predicted AQI Of The Coming Hour: " + response,
        icon: "success"
    });
}
function onBeginapi() {
    $('#loader').removeClass('hidden');
}
function onSuccessSignUp(response) {
    $('#loader').addClass('hidden');
    Swal.fire({
        title: "Success!!",
        text: "Your account has been created successfully! Please login using your credentials to continue.",
        icon: "success"
    }).then(function () {
        window.location = "/SignUp/Login";
    });
}
function onBeginSignUp() {
    $('#loader').removeClass('hidden');
}
function onFailureapi() {

}

$("#Quantity").on('change', function () {
    var quantity = $(this).val();
    var price = $("#Price").val();
    var TotalPrice = (price * quantity).toFixed(2);
    $("#TotalPrice").val(TotalPrice);
}) 

function onBeginContact() {
    $('#loader').removeClass('hidden');
}

function onSuccessContact() {
    $('#loader').addClass('hidden');
    Swal.fire({
        title: "Thank you for reaching out!!",
        text: "Our team will contact you within 24-48 hours. We appreciate your interest in PureAirPro!",
        icon: "success"
    }).then(function () {
        window.location = "/";
    });
}