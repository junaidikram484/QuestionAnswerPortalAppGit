using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionAnswerPortal.Models
{
    public class Answers
    {
        [PrimaryKey, AutoIncrement]
        public Int64 Id { get; set; }

        [NotNull]
        public String AnswerText { get; set; }

        [NotNull]
        public String CreatedDate { get; set; }

        public String UpdatedDate { get; set; }

        [NotNull]
        public Int64 Status { get; set; }

        [NotNull]
        public Int64 QuestionID { get; set; }

        public static List<Answers> GetAnswersOfQuestion(int questionID)
        {
            try
            {
                using(var db = new DbHelper())
                {
                    List<Answers> answersOfQuestion = db.Answer.Where(x => x.QuestionID == questionID).ToList();
                    return answersOfQuestion;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return new List<Answers>();
            }
        }
        public static void SubmitAnswer(Answers answer)
        {
            try
            {
                using (var db = new DbHelper())
                {
                    db.Answer.Add(answer);
                    db.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
