$(function () {
    const Toast = Swal.mixin({
        toast: true,
        position: 'top-end',
        showConfirmButton: false,
        timer: 3000,
        timerProgressBar: true,
        onOpen: (toast) => {
            toast.addEventListener('mouseenter', Swal.stopTimer)
            toast.addEventListener('mouseleave', Swal.resumeTimer)
        }
    })

    $.validator.setDefaults({
        submitHandler: function () {
            $.ajax({
                data: { currentpass: JSON.stringify($("#currentPass").val()), newpass: JSON.stringify($("#newPass").val()) },
                url: '/Admin/Profile/ChangePassword',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == false) {
                        $('#invalid_currentpass').empty().append('<div class="text-danger">The current password is incorrect. Try again, please!</div>');
                        $("#currentPass").val("");
                        $("#newPass").val("");
                        $("#confirmPass").val("");
                        $('#notice_success').empty();
                    }
                    if (res.status == true) {
                        Toast.fire({
                            icon: 'success',
                            title: ' You have successfully changed your password.'
                        })
                        $("#currentPass").val("");
                        $("#newPass").val("");
                        $("#confirmPass").val("");
                        $('#invalid_currentpass').empty();
                    }
                }
            })
        }
    });
    $('#changePasswordForm').validate({
        rules: {
            currentPass: {
                required: true
            },
            newPass: {
                required: true,
                minlength: 8,
                maxlength: 255
            },
            confirmPass: {
                required: true,
                equalTo: "#newPass"
            }

        },
        messages: {
            currentPass: {
                required: "Please enter your current password."
            },
            newPass: {
                required: "Please enter your new password",
                minlength: "The new password must be between 8 and 255 characters long.",
                maxlength: "The new password must be between 8 and 255 characters long."
            },
            confirmPass: {
                required: "Please confirm your new password.",
                equalTo: "The confirm password is incorrect."
            }
        },
        errorElement: 'span',
        errorPlacement: function (error, element) {
            error.addClass('invalid-feedback');
            element.closest('.form-group').append(error);
        },
        highlight: function (element, errorClass, validClass) {
            $(element).addClass('is-invalid');
        },
        unhighlight: function (element, errorClass, validClass) {
            $(element).removeClass('is-invalid');
        }
    });
});