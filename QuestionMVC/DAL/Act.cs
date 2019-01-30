using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DAL.Model;

namespace DAL
{
    public class Act
    {

        private Act()
        {

        }
        private static Act ClassEntity;
        public static Act GetClassEntity()
        {
            if (ClassEntity == null)
                ClassEntity = new Act();
            return ClassEntity;

        }
        
        public Content addContent(string name,string password)
        {
            try
            {
                var db = QuestionEntities.getDbEntity();
                Content c = new Content();
                c.Name = name;
                c.Password = password;
                db.Contents.Add(c);
                db.SaveChanges();
                return c;
            }
            catch (Exception)
            {

                throw;
            }


        }


        public List<Option> getOptionByQuestionId(int id)
        {
            try
            {
                var db = QuestionEntities.getDbEntity();
                var o = db.Options.Where(x => x.QuestionId == id).ToList();
                return o;

            }
            catch (Exception)
            {

                throw;
            }

        }
        public Option addOption(int id,string option,bool answer)
        {
            try
            {

                var db = QuestionEntities.getDbEntity();
                Option o = new Option();
                o.QuestionId = id;
                o.OptionDetails = option;
                o.Answer = answer;
                db.Options.Add(o);
                db.SaveChanges();
                return o;

            }
            catch (Exception)
            {

                throw;
            }

        }

        public Question addQuestion(int id,string question,int score)
        {
            try
            {
                var db = QuestionEntities.getDbEntity();
                Question q = new Question();
                q.ContentId = id;
                q.Question1 = question;
                q.Score = score;
                db.Questions.Add(q);
                db.SaveChanges();
                return q;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<Question> getQuestionList(int id)
        {
            try
            {
                var db = QuestionEntities.getDbEntity();
                var qList = db.Questions.Where(x => x.ContentId == id).ToList();
                return qList;
            }
            catch (Exception)
            {

                throw;
            }
        }

      public Content GetContentById(int id)
        {
            try
            {
                var db = QuestionEntities.getDbEntity();
                var c = db.Contents.Where(x => x.Id == id).FirstOrDefault();
                return c;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public Option changeOption(int id)
        {
            try
            {
                var db = QuestionEntities.getDbEntity();
                var o = db.Options.Where(x => x.Id == id).FirstOrDefault();
                var oList = db.Options.Where(x => x.QuestionId == o.QuestionId).ToList();
                foreach (Option item in oList)
                {
                    item.Answer = false;
                }
                o.Answer = true;
                db.SaveChanges();
                return o;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public bool ChooseQuestionOption(int oId,int uId)
        {
            try
            {
                var db = QuestionEntities.getDbEntity();
                var opt= db.Options.Where(x => x.Id == oId).FirstOrDefault();
               

                var queOp = db.UserQuestionOptions.Where(x => x.UserId == uId).Where(x=>x.QuestionId==opt.QuestionId).FirstOrDefault();
                
                    if(queOp==null)
                    {
                        UserQuestionOption uqo = new UserQuestionOption();
                        uqo.OptionId = oId;
                        uqo.UserId = uId;
                        uqo.QuestionId = opt.QuestionId;
                        db.UserQuestionOptions.Add(uqo);
                        db.SaveChanges();
                    }
                    else
                    {

                        var temp = db.UserQuestionOptions.Where(x => x.UserId==uId).Where(x=>x.QuestionId==opt.QuestionId).FirstOrDefault();
                        temp.OptionId = opt.Id;
                        db.SaveChanges();
                    }
                   
                
                return true;
            }
            catch (Exception)
            {

                throw;
            }


        }
        public Userr createUser(string  name,string surname)
        {
            try
            {
                var db = QuestionEntities.getDbEntity();
                Userr u = new Userr();
                u.Name = name;
                u.Surname = surname;
                db.Userrs.Add(u);
                db.SaveChanges();
                return u;
            }
            catch (Exception)
            {

                throw;
            }
                    
        }

        public List<UserContent> getallUserAnswerbyContentId(int id)
        {
            try
            {
                var db = QuestionEntities.getDbEntity();
                var uqp = db.UserContents.Include("Content").Include("Userr").Include("Userr.UserQuestionOptions.Option.Question").Where(x=>x.ContentId==id).ToList();
                return uqp;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public UserContent addUserContent(int uid, int cid)
        {
            try
            {
                var db = QuestionEntities.getDbEntity();
                UserContent uc = new UserContent();
                uc.UserId = uid;
                uc.ContentId = cid;
                db.UserContents.Add(uc);
                db.SaveChanges();
                return uc;
            }
            catch (Exception)
            {

                throw;
            }


        }

        public Veto addOptionVeto(string name,int cId)
        {
            try
            {
                var db = QuestionEntities.getDbEntity();
                Veto v = new Veto();
                v.Name = name;
                v.Count = 0;
                v.ContentId = cId;
                db.Vetoes.Add(v);
                db.SaveChanges();
                return v;
            }
            catch (Exception)
            {

                throw;
            }
                    

        }

        public List<Veto> getAllVetobyContentId(int cId)
        {
            try
            {
                var db = QuestionEntities.getDbEntity();
                var vList = db.Vetoes.Where(x => x.ContentId == cId).ToList();
                return vList;
            }
            catch (Exception)
            {

                throw;
            }


        }
        public Content getAllVetobyContentId2(int cId,string password)
        {
            try
            {
                var db = QuestionEntities.getDbEntity();
                var vList = db.Contents.Include("Vetoes").Where(x => x.Id == cId && x.Password == password).FirstOrDefault();
                return vList;
            }
            catch (Exception ex)
            {

                throw;
            }


        }


        public Veto PlusVetoCount(int id)
        {
            try
            {
                var db = QuestionEntities.getDbEntity();
                var v = db.Vetoes.Where(x => x.Id == id).FirstOrDefault();
                v.Count += 1;
                db.SaveChanges();
                return v;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public List<Veto> getAllVetobyVetoId(int cId)
        {
            try
            {
                var db = QuestionEntities.getDbEntity();
                var vList = db.Vetoes.Where(x => x.ContentId == cId).ToList();
                return vList;
            }
            catch (Exception)
            {

                throw;
            }


        }


        //public bool chectOption(int qid,int oid)
        //{
        //    try
        //    {
        //        var db = QuestionEntities.getDbEntity();
        //        var c = db.Options.Where(x=>x.QuestionId==qid).FirstOrDefault();
        //        if(c.Id==oid)
        //        { }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }

        //}
    }
}