using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuestionMVC.Models
{
    public class UserAnswerModel
    {

        public class UserAnswer
        {
            public UserDetails User { get; set; }
            public List<Answer> Answers { get; set; }
            public string Content { get; set; }

        }



        public class Answer
        {
            public int Id { get; set; }
            public string Question { get; set; }
            public bool Result { get; set; }

        }

        public class UserDetails
        {
            public int Id { get; set; }
            public string Name { get; set; }

        }
    }
}