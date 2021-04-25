$(document).ready(function () {
    $('#chkStatus').val(this.checked);

    $("input[type='checkbox']").change(function () {
        if (this.checked == true) {
            $.ajax({
                data: { id: $(this).data('id') },
                url: '/Exam/ActiveStatus',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    toastr.success('The exam has been successfully opened');
                }
            });
        } else {
            $.ajax({
                data: { id: $(this).data('id') },
                url: '/Exam/DisableStatus',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status = true) {
                        toastr.info('The exam has been successfully closed');
                    }
                }
            });
        }
    });
});