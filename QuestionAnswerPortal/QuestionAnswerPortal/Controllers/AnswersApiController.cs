using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuestionAnswerPortal.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QuestionAnswerPortal.Controllers
{
    [Route("api/[controller]")]
    public class AnswersApiController : Controller
    {
        // GET api/<controller>/5
        [HttpGet("/api/AnswersApi/GetAnswerOfQuestion")]
        public List<Answers> GetAnswerOfQuestion(string questionID)
        {
            return Answers.GetAnswersOfQuestion(int.Parse(questionID));
        }

        // POST api/<controller>
        [HttpPost("/api/AnswersApi/SubmitAnswer")]
        public void SubmitAnswer(Answers answer)
        {
            Answers.SubmitAnswer(answer);
        }
    }
}
