$(document).ready(function () {
    $('#chkStatus').val(this.checked);

    $("input[type='checkbox']").change(function () {
        if (this.checked == true) {
            $.ajax({
                data: { id: $(this).data('id') },
                url: '/Lectures/ApproveStudent',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    toastr.success('The student has been approved to join your course.');
                }
            });
        } else {
            $.ajax({
                data: { id: $(this).data('id') },
                url: '/Lectures/TurnedOut',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    toastr.info('You turned out the student out of the course.');
                }
            });
        }
    });
});