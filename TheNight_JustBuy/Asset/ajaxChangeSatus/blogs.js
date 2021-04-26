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

$(document).on('switchChange.bootstrapSwitch', '#chkStatus', function (event, state) {
    if ($(this).bootstrapSwitch('state')) {
        $.ajax({
            data: { id: $(this).data('id') },
            url: '/Admin/Blogs/ActiveStatus',
            dataType: 'json',
            type: 'POST',
            success: function (res) {
                Toast.fire({
                    icon: 'success',
                    title: 'The blog has been successfully shown'
                })
            }
        });

    } else {
        $.ajax({
            data: { id: $(this).data('id') },
            url: '/Admin/Blogs/DisableStatus',
            dataType: 'json',
            type: 'POST',
            success: function (res) {
                if (res.status = true) {
                    Toast.fire({
                        icon: 'success',
                        title: 'The blog has been successfully hidden'
                    })
                }
            }
        });
    }
});


$('.approve').off('click').on('click', function () {
    $.ajax({
        data: { id: $(this).data('id') },
        url: '/Admin/Blogs/ApproveBlog',
        dataType: 'json',
        type: 'POST',
        success: function (res) {
            if (res.status == true) {
                Toast.fire({
                    icon: 'success',
                    title: 'The blog has been successfully shown'
                });

            }
        }
    })
    $('#blog-' + $(this).data('id')).hide("slow");
});

$('.ignore').off('click').on('click', function () {
    $.ajax({
        data: { id: $(this).data('id') },
        url: '/Admin/Blogs/Ignore',
        dataType: 'json',
        type: 'POST',
        success: function (res) {
            if (res.status == true) {
                Toast.fire({
                    icon: 'success',
                    title: 'The blog has been successfully ignored'
                });

            }
        }
    })
    $('#blog-' + $(this).data('id')).hide("slow");
});