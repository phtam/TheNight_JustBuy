$(function () {
    $.validator.setDefaults({
        submitHandler: function () {
            $.ajax({
                data: { comment: JSON.stringify($("#txtComment").val()), lectureID: JSON.stringify($("#hdLecture").val()) },
                url: '/Courses/CommentLecture',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        $("#apdComment").append('<div class="card-courses-list-bx"> <ul class="card-courses-view"> <li class="card-courses-user"> <div class="card-courses-user-pic"> <img src="' + res.avt + '" alt="" /> </div> <div class="card-courses-user-info"> <h4>' + res.name + '</h4> <h5>' + res.date + '</h5> </div> </li> <li class="row card-courses-dec"> <p>' + res.content + '</p> </li> </ul> </div>');
                        $("#txtComment").val("")
                    }
                }
            })
        }
    });

    $('#commentForm').validate({
        rules: {
            txtComment: {
                required: true
            }
        },
        messages: {
            txtComment: {
                required: "Please enter your comment"
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