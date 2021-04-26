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
            url: '/Admin/BlogComments/ActiveStatus',
            dataType: 'json',
            type: 'POST',
            success: function (res) {
                Toast.fire({
                    icon: 'success',
                    title: 'The comment has been successfully shown'
                })
            }
        });

    } else {
        $.ajax({
            data: { id: $(this).data('id') },
            url: '/Admin/BlogComments/DisableStatus',
            dataType: 'json',
            type: 'POST',
            success: function (res) {
                if (res.status = true) {
                    Toast.fire({
                        icon: 'success',
                        title: 'The comment has been successfully hidden'
                    })
                }
            }
        });

    }
});