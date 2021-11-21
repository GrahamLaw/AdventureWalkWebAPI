using AdventureWalk.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureWalk.Controllers
{    
    [ApiController]
    public class QuizController : ControllerBase
    {

        [HttpGet]
        [Route("api/Questions/All")]
        public List<Question> GetQuestions()
        {
            using (QuizDBContext db = new QuizDBContext())
            {
                var questions = db.Questions.ToList();
                return questions;
            }
        }

        [HttpGet]
        [Route("api/Questions")]
        public Question GetQuestions(int qId)
        {
            using (QuizDBContext db = new QuizDBContext())
            {
                var question = db.Questions
                    .Where(y => qId == y.Qid)
                    .FirstOrDefault();
                    
                return question;
            }
        }

        [HttpGet]
        [Route("api/Answers")]
        public ActionResult GetAnswers(int qId)
        {
            using (QuizDBContext db = new QuizDBContext())
            {
                var result = db.Questions
                        .Where(y => qId == y.Qid)
                        .Select(z => z.Answer)
                        .SingleOrDefault();


                return Ok(result);
            }
        }
    }
}
