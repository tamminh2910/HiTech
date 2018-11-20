$(document).ready(function () {
   
    $('#CheckboxAll').click(function () {
        if ($(this).is(":checked")) {
            $('.CheckboxID').prop("checked", true)
        }
        else {
            $('.CheckboxID').prop("checked", false)
        }

    })
})