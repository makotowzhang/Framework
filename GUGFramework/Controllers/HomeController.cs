using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.IO;
using System.Xml;
using System.Text;
using System.Xml.Serialization;

namespace GUGFramework.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Test()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            ds.Tables.Add(dt);
            dt.Columns.Add("c1", typeof(string));
            dt.Columns.Add("c2", typeof(string));
            dt.Columns.Add("c3", typeof(string));
            dt.Columns.Add("c4", typeof(string));
            DataRow dr = dt.NewRow();
            dr["c1"] = "测试1";
            dr["c2"] = DBNull.Value;
            dr["c3"] = "test";
            dr["c4"] = null;
            dt.Rows.Add(dr);
            string outputXml = "";
            //using (StringWriter sw = new StringWriter())
            //{ 
            //    ds.WriteXml(sw);
            //    outputXml = sw.ToString();
            //}
            XmlSerializer xs = new XmlSerializer(typeof(DataSet));
            using (MemoryStream stream = new MemoryStream())
            {
                XmlTextWriter writer = new XmlTextWriter(stream, Encoding.UTF8);
                xs.Serialize(writer, ds);
                using (StreamReader sr = new StreamReader(stream))
                {
                    stream.Seek(0L,SeekOrigin.Begin);
                    outputXml = sr.ReadToEnd();
                }
            }


            return Content(DateTime.Now.ToString());
        }
    }
}