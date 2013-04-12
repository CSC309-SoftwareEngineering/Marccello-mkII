using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Marccello;
namespace Marccello.Models
{
    public class MajorModel
    {
         majorDataContext db;

        public IEnumerable<MyMajor> Maj()
        {
         
        db = new majorDataContext();
        List<MyMajor> maj = (from b in db.majors
                                select new MyMajor { department = b.name.ToString()}).Distinct().ToList();
        if (maj != null)
        {
            var omajor = from mj in maj
                         select mj;

            return omajor;
        }
        else
            return null;
        }

        public class MyMajor
        {
            public string department {get; set;}
           
        }
    
    }
}