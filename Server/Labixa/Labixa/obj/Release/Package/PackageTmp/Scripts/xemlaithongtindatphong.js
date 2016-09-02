$(document).ready(function () {
    $("#order-button").click(function () {
        $(this).closest('form').submit();
        event.preventDefault();
        return false;
    });
});

function goBack() {
    window.history.back();
}