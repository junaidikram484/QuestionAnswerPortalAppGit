$(function () {
    $('#question-error').hide();
    //to get all questions on page load
    GetAllQuestions();
})
//when user will hit submit button after adding question text
$('body').on('click', '#question-submit', function (e) {
    var questionText = $('#question-id').val();
    if (questionText != "" && questionText != undefined) {
        //ajax call to save question in DB
        $('#question-error').hide();
        SubmitQuestion(questionText);
    }
    else {
        $('#question-error').show();
    }
})
//function to get all question that include ajax call to api action.
function GetAllQuestions() {
    var questionsList = '';
    $.ajax({
        url: '/api/QuestionApi/GetAllQuestions',
        method: 'GET',
        async: false,
        success: function (data) {
            questionsList = data;
        },
        error: function (e) {
            console.log(e);
        }
    });
    BindQuestions(questionsList)
}
//function that binds response to the html to show results.
function BindQuestions(questionsList) {
    var html = '';
    $('#question-id').val('');
    if (questionsList.length > 0) {
        $.each(questionsList, function (index, value) {
            html += `<div class="card-body">
                <a href="#" class='question-href' data-toggle="modal" data-target="#AnswerModal" data-id="${value.id}"><p>${value.questionText}</p></a>
            </div><hr />`
        });
    }
    else {
        html += `<div class="card-body">
                <p>No Questions yet!</p>
            </div><hr />`
    }
    $('#questions-container').empty();
    $('#questions-container').append(html);
}
// function that call api method to store entered question in db
function SubmitQuestion(questionText) {
    $.ajax({
        url: '/api/QuestionApi/SubmitQuestion',
        method: 'POST',
        data: { QuestionText: questionText },
        success: function () {
            window.location.reload();
        },
        error: function (e) {
            console.log(e);
        }
    });
}