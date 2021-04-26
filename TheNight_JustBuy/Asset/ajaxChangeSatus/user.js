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
            data: { userid: JSON.stringify($(this).data('id')) },
            url: '/Admin/Values/ActiveStatus',
            dataType: 'json',
            type: 'POST',
            success: function (res) {
                Toast.fire({
                    icon: 'success',
                    title: 'The user has been successfully ativated'
                })
            }
        });
    } else {
        $.ajax({
            data: { userid: JSON.stringify($(this).data('id')) },
            url: '/Admin/Values/DisableStatus',
            dataType: 'json',
            type: 'POST',
            success: function (res) {
                if (res.status = true) {
                    Toast.fire({
                        icon: 'success',
                        title: 'The user has been successfully blocked'
                    })
                }
            }
        });
    }
});