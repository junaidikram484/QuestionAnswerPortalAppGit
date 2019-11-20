using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionAnswerPortal.Models
{
    public class Questions
    {
        [PrimaryKey, AutoIncrement]
        public Int64 Id { get; set; }

        [NotNull]
        public String QuestionText { get; set; }

        [NotNull]
        public String CreatedDate { get; set; }

        public String UpdatedDate { get; set; }

        [NotNull]
        public Int64 Status { get; set; }

        public List<Answers> Answers { get; } = new List<Answers>();

        public static List<Questions> GetAllQuestions()
        {
            try
            {
                using (var db = new DbHelper())
                {
                    List<Questions> questionsList = db.Question.ToList();
                    return questionsList;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Occured: " + ex);
                return new List<Questions>();
            }
        }
        public static void SubmitQuestion(Questions question)
        {
            try
            {
                using (var db = new DbHelper())
                {
                    db.Question.Add(question);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Occured: " + ex);
            }
        }
    }
}
