$(document).ready(function () {
    if ($("input[name='Password']")) {
        console.log("dsdsf")
    }
    $("input[name='Password']").focusout(function () {
        console.log("sdbhbh")
    })
    $("input[name='Password']").focusout(function () {
        if ($("input[name='Password']").val().length > 0) {
            $("input[name='ConfirmPassword']").prop('disabled', false)

        }
        else {
            $("input[name='ConfirmPassword']").prop('disabled', true)
            $("input[name='ConfirmPassword']").val("")
            $("#alert").slideUp(200)
        }
        if (($("input[name='Password']").val() != $("input[name='ConfirmPassword']").val()) && ($("input[name='ConfirmPassword']").val().length > 0)) {
            $("#alert").slideDown(200)

        }
        else {
            $("#alert").slideUp(200)
        }
    })
    $("input[name='ConfirmPassword']").focusout(function () {
        if ($("input[name='Password']").val() != $("input[name='ConfirmPassword']").val()) {
            $("#alert").slideDown(200)

        }
        else {
            $("#alert").slideUp(200)
        }
    })



})
