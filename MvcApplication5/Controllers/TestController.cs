using MongoDB;
using MvcApplication5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;

namespace MvcApplication5.Controllers
{
   
        //
        // GET: /Test/
         [EnableCors(origins: "*", headers: "*", methods: "*")]
        public class TestController : ApiController
        {
            Mongo mongo = new Mongo();
            public ICursor<FormDataModel> GetAll()
            {
                var db = mongo.GetDatabase("UserFormDB");
                var collection = db.GetCollection<FormDataModel>();
                var AllData = collection.FindAll();
                return AllData;
            }

            public HttpResponseMessage Post([FromBody] FormDataModel user)
            {
                mongo.Connect();
                if (ModelState.IsValid)
                {
                    var db = mongo.GetDatabase("UserFormDB");
                    var collection = db.GetCollection<FormDataModel>();
                    FormDataModel formDataObject = new FormDataModel();
                    formDataObject.SkillsReff1 = new List<Skills>();
                    formDataObject.SkillsReff2 = new List<Skills>();
                    formDataObject.Candidatename = user.Candidatename;
                    formDataObject.Projectname = user.Projectname;
                    formDataObject.PracticeArea = user.PracticeArea;
                    formDataObject.Requester = user.Requester;
                    formDataObject.Interviewername = user.Interviewername;
                    formDataObject.Signature = user.Signature;
                    formDataObject.Date = user.Date;

                    for (var i = 0; i < user.SkillsReff1.Count; i++)
                    {
                        formDataObject.SkillsReff1.Add(new Skills());
                        formDataObject.SkillsReff1[i].SkillName = user.SkillsReff1[i].SkillName;
                        formDataObject.SkillsReff1[i].Interviewrating = user.SkillsReff1[i].Interviewrating;
                        formDataObject.SkillsReff1[i].Jrssrating = user.SkillsReff1[i].Jrssrating;
                    }             
                        
                    for (var i = 0; i < user.SkillsReff2.Count; i++)
                     {
                        formDataObject.SkillsReff2.Add(new Skills());
                        formDataObject.SkillsReff2[i].SkillName = user.SkillsReff2[i].SkillName;
                        formDataObject.SkillsReff2[i].Interviewrating = user.SkillsReff2[i].Interviewrating;
                        formDataObject.SkillsReff2[i].Jrssrating = user.SkillsReff2[i].Jrssrating;
                     }
                   
                    formDataObject.comments = user.comments;
                    collection.Save(formDataObject);
                    return new HttpResponseMessage()
                    {
                        Content = new StringContent("POST: Success")
                    };
                }
                    return new HttpResponseMessage()
                    {
                        Content = new StringContent("Inavalid Model")
                    };
                }

                public HttpResponseMessage Put()
                {
                    return new HttpResponseMessage()
                    {
                        Content = new StringContent("PUT: Test message")
                    };
                }
        }

    }

