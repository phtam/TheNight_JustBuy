$(document).ready(function () {
    $("#slQuestion").change(function () {
        $.ajax({
            type: "POST",
            url: '/Values/CusUsernameValidation',
            data: {
                username: $(this).val()
            },
            cache: false,
            datatype: "json",
        }).done(function (data) {
            $("#notice_invalid_username").empty();
            $("#notice_invalid_username").append(data);
        });
    });
});