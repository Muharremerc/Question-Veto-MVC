using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuestionMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Question()
        {
            return View();
        }

        public ActionResult getAddQuestion()
        {
            var c = Session["Content"] as DAL.Model.Content;
            if(c==null)
            {
                var classEntity = DAL.Act.GetClassEntity();
                c = classEntity.GetContentById(1002);
            }
            return PartialView("_AddQuestion",c);
        }
        public JsonResult AddContent(string name,string password)
        {
            var classEntity = DAL.Act.GetClassEntity();
            var c = classEntity.addContent(name, password);
            Session["Content"]=c;
            return Json(c);
        }
        public ActionResult OptionView()
        {

            try
            {
                return PartialView("_OptionView");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public JsonResult addQuestion(string question,int score)
        {

            try
            {
                var classEntity = DAL.Act.GetClassEntity();
                var c = Session["Content"] as DAL.Model.Content;
                var q = classEntity.addQuestion(c.Id,question,score);
                Session["Question"] = q;
                return Json("");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public JsonResult addOption(int id,string option ,bool answer)
        {

            try
            {
                var classEntity = DAL.Act.GetClassEntity();
                var o = classEntity.addOption(id,option,answer);
                return Json(true);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult getOptionByQuestionId(int id)
        {
            try
            {
                var classEntity = DAL.Act.GetClassEntity();
                var o = classEntity.getOptionByQuestionId(id);
                return PartialView("_OptionList",o);
            }
            catch (Exception)
            {

                throw;
            }

          
        }

        public ActionResult getQuestionListByContentId()
        {
            try
            {
                var classEntity = DAL.Act.GetClassEntity();
                var c = Session["Content"] as DAL.Model.Content;

                if (c == null)
                {
                    c = classEntity.GetContentById(1002);
                }

                var q = classEntity.getQuestionList(c.Id);
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
                return PartialView("_QuestionList", qlm);

            }

        
            catch (Exception ex)
            {

                throw;
            }


        }



        public JsonResult selectOption(int id)
        {

            try
            {
                var classEntity = DAL.Act.GetClassEntity();
                var o = classEntity.changeOption(id);
                return Json(true);

            }
            catch (Exception)
            {

                throw;
            }

        }

        public JsonResult finishContent()
        {
            try
            {
                var classEntity = DAL.Act.GetClassEntity();
                var contentid = Session["Content"] as DAL.Model.Content;
                Session["Question"] = null;
                Session["Content"] = null;
                return Json("Id : "+contentid.Id+" - Password : "+contentid.Password+"     Please Save");

            }
            catch (Exception)
            {

                throw;
            }

        }




    }
        

    
}