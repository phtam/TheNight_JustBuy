$(document).ready(function () {
    $('#chkStatus').val(this.checked);

    $("input[type='checkbox']").change(function () {
        if (this.checked == true) {
            $.ajax({
                data: { id: $(this).data('id') },
                url: '/Lectures/ActiveStatus',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    toastr.success('The courses has been successfully opened.');
                }
            });
        } else {
            $.ajax({
                data: { id: $(this).data('id') },
                url: '/Lectures/DisableStatus',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status = true) {
                        toastr.info('The courses has been successfully closed.');
                    }
                }
            });
        }
    });
});