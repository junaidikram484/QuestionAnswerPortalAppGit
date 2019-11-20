var selectedQuestionID = '';
//question click event that opens modal to show answers and we are capturing question id in this method also.
$('body').on('click', '.question-href', function () {
    $('#answerModelLabel').append(`Question: ${$(this).text()}?`);
    var questionID = selectedQuestionID = $(this).attr('data-id');
    GetAnswersOfQuestion(questionID);
})
//function when user will hit submit button after adding answer.
$('body').on('click', '#answer-submit', function () {
    var answerText = $('#answer-id').val();
    SubmitAnswer(selectedQuestionID, answerText);
})
//function that calls api method to store entered answer into db.
function SubmitAnswer(selectedQuestionID, answerText) {
    $.ajax({
        url: '/api/AnswersApi/SubmitAnswer',
        method: 'POST',
        data: { AnswerText: answerText, QuestionID: selectedQuestionID },
        async: false,
        success: function (data) {
            //Bind answer List again
            GetAnswersOfQuestion(selectedQuestionID);
        },
        error: function (e) {
            console.log(e);
        }
    });
}
//function to get answers of question including ajax to api method
function GetAnswersOfQuestion(questionID) {
    var answerList = '';
    $.ajax({
        url: '/api/AnswersApi/GetAnswerOfQuestion',
        method: 'GET',
        data: { questionID: questionID },
        async: false,
        success: function (data) {
            answerList = data;
            console.log(data);
        },
        error: function (e) {
            console.log(e);
        }
    });
    BindAnswers(answerList);
}
// function to bind answers to html to show results.
function BindAnswers(answersList) {
    var html = '';
    $('#answer-id').val('');
    if (answersList.length > 0) {
        $.each(answersList, function (index, value) {
            html += `<div class="card-body">
                <a href="#"><p>${value.answerText}</p></a>
            </div><hr />`
        });
    } else {
        html += `<div class="card-body">
                <p>No Answers yet!</p>
            </div><hr />`
    }
    $('#answer-container').empty();
    $('#answer-container').append(html);
}