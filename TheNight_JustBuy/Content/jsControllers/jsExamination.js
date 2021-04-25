$("#btnPrevious").hide();
$("#btnFinish").hide();
$('#btnNext').off('click').on('click', function (e) {
    e.preventDefault();
    $.ajax({
        data: { id: JSON.stringify($("#questionID").val()), choice: JSON.stringify($("input[type=radio][name=radioChoice]:checked").val()) },
        url: '/Exam/Next',
        dataType: 'json',
        type: 'POST',
        success: function (res) {
            $("#lbDescription").empty().append(res.des + " (" + res.mark + " marks)");

            $("#lbChoiceA").empty().append(res.choicea);
            $("#choiceA").val(res.choicea);

            $("#lbChoiceB").empty().append(res.choiceb);
            $("#choiceB").val(res.choiceb);

            $("#lbChoiceC").empty().append(res.choicec);
            $("#choiceC").val(res.choicec);

            $("#lbChoiceD").empty().append(res.choiced);
            $("#choiceD").val(res.choiced);

            $("#questionID").val(res.ID);

            $("input:radio").prop("checked", false);

            if (res.choiceCheck == res.choicea) {
                $("#choiceA").prop("checked", true);
            }
            if (res.choiceCheck == res.choiceb) {
                $("#choiceB").prop("checked", true);
            }
            if (res.choiceCheck == res.choicec) {
                $("#choiceC").prop("checked", true);
            }
            if (res.choiceCheck == res.choiced) {
                $("#choiceD").prop("checked", true);
            }

            if (res.type == 1) {
                $("#lbContent").empty().append(res.question);
            }
            if (res.type == 2) {
                $("#lbContent").empty().append('<audio controls preload="none"><source src="' + res.question + '"></audio>');
            }
            if (res.type == 3) {
                $("#lbContent").empty().append('<div class="text-center"><img width="50%" src="' + res.question + '" alt="Question" /></div>');
            }
            if (res.isNext == true) {
                $("#btnNext").show();
                $("#btnFinish").hide();
            }
            if (res.isNext == false) {
                $("#btnFinish").show();
                $("#btnNext").hide();
            }
            if (res.isPrev == true) {
                $("#btnPrevious").show();
            }
            if (res.isPrev == false) {
                $("#btnPrevious").hide();
            }
        }
    })
});


$('#btnPrevious').off('click').on('click', function (e) {
    e.preventDefault();
    $.ajax({
        data: { id: JSON.stringify($("#questionID").val()), choice: JSON.stringify($("input[type=radio][name=radioChoice]:checked").val()) },
        url: '/Exam/Previous',
        dataType: 'json',
        type: 'POST',
        success: function (res) {
            $("#lbDescription").empty().append(res.des);

            $("#lbChoiceA").empty().append(res.choicea);
            $("#choiceA").val(res.choicea);

            $("#lbChoiceB").empty().append(res.choiceb);
            $("#choiceB").val(res.choiceb);

            $("#lbChoiceC").empty().append(res.choicec);
            $("#choiceC").val(res.choicec);

            $("#lbChoiceD").empty().append(res.choiced);
            $("#choiceD").val(res.choiced);

            $("#questionID").val(res.ID);

            $("input:radio").prop("checked", false);

            if (res.choiceCheck == res.choicea) {
                $("#choiceA").prop("checked", true);
            }
            if (res.choiceCheck == res.choiceb) {
                $("#choiceB").prop("checked", true);
            }
            if (res.choiceCheck == res.choicec) {
                $("#choiceC").prop("checked", true);
            }
            if (res.choiceCheck == res.choiced) {
                $("#choiceD").prop("checked", true);
            }
            if (res.type == 1) {
                $("#lbContent").empty().append(res.question);
            }
            if (res.type == 2) {
                $("#lbContent").empty().append('<audio controls preload="none"><source src="' + res.question + '"></audio>');
            }
            if (res.type == 3) {
                $("#lbContent").empty().append('<div class="text-center"><img width="50%" src="' + res.question + '" alt="Question" /></div>');
            }
            if (res.isNext == true) {
                $("#btnNext").show();
                $("#btnFinish").hide();
            }
            if (res.isNext == false) {
                $("#btnFinish").show();
                $("#btnNext").hide();
            }
            if (res.isPrev == true) {
                $("#btnPrevious").show();
            }
            if (res.isPrev == false) {
                $("#btnPrevious").hide();
            }

        }
    })
});


$('#btnFinish').off('click').on('click', function (e) {
    e.preventDefault();
    $.ajax({
        data: { id: JSON.stringify($("#questionID").val()), choice: JSON.stringify($("input[type=radio][name=radioChoice]:checked").val()) },
        url: '/Exam/Complete',
        dataType: 'json',
        type: 'POST',
        success: function (res) {
            if (res.status = true) {
                window.location = "../Finish";
            }
        }
    })
});

$('#btnCompleted').off('click').on('click', function (e) {
    e.preventDefault();
    $.ajax({
        data: { id: JSON.stringify($("#questionID").val()), choice: JSON.stringify($("input[type=radio][name=radioChoice]:checked").val()) },
        url: '/Exam/Complete',
        dataType: 'json',
        type: 'POST',
        success: function (res) {
            if (res.status = true) {
                window.location = "../Finish";
            }
        }
    })
});

function counter(m) {
    minutes = m - 1;
    seconds = 60;
    countDown();
}

function countDown() {
    document.getElementById("min").innerHTML = minutes;
    document.getElementById("remain").innerHTML = seconds;
    setTimeout("countDown()", 1000);
    if (minutes == 0 && seconds == 0) {

        window.location = "../Finish";
    }
    else {
        seconds--;
        if (seconds == 0 && minutes > 0) {
            minutes--;
            seconds = 60;
        }
    }
}