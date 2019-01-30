using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL.Model;

namespace QuestionMVC.Controllers
{
    public class VetoController : Controller
    {
        // GET: Veto
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult getAddVetoView(string name,string password)
        {
            var classEntity = DAL.Act.GetClassEntity();
            var c = classEntity.addContent(name,password);
            Session["Content"] = c;

            return PartialView("_AddVeto",c);
        }

        public ActionResult addVetoOption(string name)
        {
            try
            {
                var classEntity = DAL.Act.GetClassEntity();
                var c = Session["Content"] as DAL.Model.Content;
                var v = classEntity.addOptionVeto(name, c.Id);
                var vlist = classEntity.getAllVetobyContentId(c.Id);
                return PartialView("_vetoView",vlist);


            }
            catch (Exception)
            {

                throw;
            }
                        

        }

        public ActionResult VetoResult()
        {
            return View();
        }


        public ActionResult AnswerVeto(int id,string password)
        {
            try
            {
                var classEntity = DAL.Act.GetClassEntity();
                var v = classEntity.getAllVetobyContentId2(id, password);
                return PartialView("_VetoesListView",v);
            }
            catch (Exception)
            {

                throw;
            }


        }

        public ActionResult getResult(int id)
        {
            try
            {
                var classEntity = DAL.Act.GetClassEntity();
                var v = classEntity.getAllVetobyVetoId(id);
                return PartialView("_getResult", v);
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public JsonResult VetoOp(int id)
        {
            var classEntity = DAL.Act.GetClassEntity();
            var v = classEntity.PlusVetoCount(id);
            return Json(v.ContentId);

        }

    }
}