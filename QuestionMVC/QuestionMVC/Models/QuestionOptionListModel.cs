using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuestionMVC.Models
{
    public class QuestionOptionListModel
    {
        public class QuestionListModel
        {
            public Question Q { get; set; }
            public List<Option> O { get; set; }
        }

        public class Question
        {
            public int Id { get; set; }
            public string QuestionDetails { get; set; }
            public int Score { get; set; }

        }

        public class Option
        {
            public int Id { get; set; }
            public string OptionDetails { get; set; }
            public bool Answer { get; set; }
        }
    }
}