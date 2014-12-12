using MongoDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication5.Models
{
    public class FormDataModel
    {
        public Oid Id { get; private set; }
        public string Candidatename { get; set; }
        public string Projectname { get; set; }
        public string PracticeArea { get; set; }
        public string Requester { get; set; }
        public string Interviewername { get; set; }
        public string Signature { get; set; }
        public DateTime? Date { get; set; }
        public IList<Skills> SkillsReff1 { get; set; }
        public IList<Skills> SkillsReff2 { get; set; }
        public string comments { get; set; }
    }
    public class Skills
    {
        public string SkillName { get; set; }
        public string Interviewrating { get; set; }
        public string Jrssrating { get; set; }
    }
}