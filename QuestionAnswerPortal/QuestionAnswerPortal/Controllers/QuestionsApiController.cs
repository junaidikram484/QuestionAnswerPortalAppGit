using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuestionAnswerPortal.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QuestionAnswerPortal.Controllers
{
    [Route("api/QuestionApi")]
    public class QuestionsApiController : Controller
    {
        // GET: api/<controller>
        
        [HttpGet("/api/QuestionApi/GetAllQuestions")]
        public List<Questions> GetAllQuestions()
        {
            return Questions.GetAllQuestions();
        }
        
        [HttpPost("/api/QuestionApi/SubmitQuestion")]
        public void SubmitQuestion(Questions question)
        {
            Questions.SubmitQuestion(question);
        }

    }
}
