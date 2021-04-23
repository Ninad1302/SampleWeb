using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RESTWebAPI.Models
{
    public class DBModel
    {
        public int strID { get; set; }
        public DateTime dtDate { get; set; }
        public string strDetails { get; set; }
        public double dblDebit { get; set; }
        public double dblCredit { get; set; }

    }
}