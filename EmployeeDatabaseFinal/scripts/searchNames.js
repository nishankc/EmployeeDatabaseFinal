$(document).ready(function () {
    $('#SearchFirstName').hide();
    $('#SearchSurname').hide();
    $('.searchAreaSurname').hide();
    $('.searchAreaFirstName').hide()

});

$(function () {
    $('#beginSearch').click(function () {

        $(this).hide();
        $('#SearchFirstName').show();
        $('#SearchSurname').show();
    });
});

$(function () {
    $('#SearchSurname').click(function () {

        $(this).hide();
        $('#SearchFirstName').hide();
        $('.searchAreaSurname').show();
    });
});

$(function () {
    $('#SearchFirstName').click(function () {

        $(this).hide();
        $('#SearchSurname').hide();
        $('.searchAreaFirstName').show();
    });
});
