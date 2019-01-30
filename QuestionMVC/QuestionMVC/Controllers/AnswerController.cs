using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuestionMVC.Controllers
{
    public class AnswerController : Controller
    {
        // GET: Answer
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult getQuestionByContentId(int id,string name,string surname)
        {
            try
            {
                var classEntity = DAL.Act.GetClassEntity();
                var q = classEntity.getQuestionList(id);
                Session["User"] = classEntity.createUser(name, surname);
                List<QuestionMVC.Models.QuestionOptionListModel.QuestionListModel> qlm = new List<Models.QuestionOptionListModel.QuestionListModel>();
                foreach (var item in q)
                {
                    var x = classEntity.getOptionByQuestionId(item.Id);
                    List<QuestionMVC.Models.QuestionOptionListModel.Option> op = new List<Models.QuestionOptionListModel.Option>();
                    foreach (var item2 in x)
                    {
                        op.Add(new Models.QuestionOptionListModel.Option
                        {
                            Id = item2.Id,
                            OptionDetails = item2.OptionDetails,
                            Answer = bool.Parse(item2.Answer.ToString())
                            
                        });
                    }


                    qlm.Add(new Models.QuestionOptionListModel.QuestionListModel
                    {


                        Q = new Models.QuestionOptionListModel.Question
                        {
                            Id = item.Id,
                            QuestionDetails = item.Question1,
                            Score = Int32.Parse(item.Score.ToString())
                        },
                        O = op
                        

                    });
                }

                var u = Session["User"] as DAL.Model.Userr;
                var c = classEntity.addUserContent(u.Id, id);
              
                return PartialView("_getQuestionList",qlm);
            }
            catch (Exception)
            {

                throw;
            }
                        

        }

        public ActionResult UsersAnswers()
        {

            return View();

        }



        public JsonResult selectOption(int id)
        {

            try
            {
                var classEntity = DAL.Act.GetClassEntity();
                var u = Session["User"] as DAL.Model.Userr;
                var o = classEntity.ChooseQuestionOption(id,u.Id);
                return Json(o);

            }
            catch (Exception)
            {

                throw;
            }

        }


        public ActionResult getAlluserAnswer(int id,string password)
        {
            try
            {
                var classEntity = DAL.Act.GetClassEntity();
                var uList = classEntity.getallUserAnswerbyContentId(id);
                List<Models.UserAnswerModel.UserAnswer> ualist = new List<Models.UserAnswerModel.UserAnswer>();
                //foreach (var item in uList)
                //{
                //    foreach (var item2 in item.Userr.UserQuestionOptions)
                //    {
                //        ualist.Add(new Models.UserAnswerModel.UserAnswer
                //        {
                //            User = new Models.UserAnswerModel.UserDetails
                //            {
                //                Id = item.Userr.Id,
                //                Name = item.Userr.Name
                //            },
                //            Answers = new List<Models.UserAnswerModel.Answer>
                //            {
                //                new Models.UserAnswerModel.Answer
                //                    {
                //                     Id=item2.Question.Id,
                //                     Question=item2.Question.Question1,
                //                     Result=bool.Parse(item2.Option.Answer.ToString())
                //                    }

                //            }
                //        });
                //    }

                //}
                foreach (var item in uList)
                {
                    Models.UserAnswerModel.UserDetails u = new Models.UserAnswerModel.UserDetails();
                    u.Id = item.Userr.Id;
                    u.Name = item.Userr.Name+" "+item.Userr.Surname;
                    List<Models.UserAnswerModel.Answer> ua = new List<Models.UserAnswerModel.Answer>();
                    foreach (var item2 in item.Userr.UserQuestionOptions)
                    {
                        ua.Add(new Models.UserAnswerModel.Answer
                        {
                            Id=item2.Question.Id,
                             Question=item2.Question.Question1,
                             Result=bool.Parse(item2.Option.Answer.ToString())
                        }
                        );
                    }
                    Models.UserAnswerModel.UserAnswer uam = new Models.UserAnswerModel.UserAnswer();
                    uam.Answers = ua;
                    uam.User = u;
                    uam.Content = item.Content.Name;
                    ualist.Add(uam);
                    
                }

                



                return PartialView("_UserAnswerList",ualist);
            }
            catch (Exception ex)
            {

                throw;
            }

        }


    }
}