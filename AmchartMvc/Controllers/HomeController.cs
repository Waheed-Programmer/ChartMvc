using AmchartMvc.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace AmchartMvc.Controllers
{
    public class HomeController : Controller
    {
        HdMvcEntities DB = new HdMvcEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Pie()
        {
            var context = new HdMvcEntities();
            ArrayList xValue = new ArrayList();
            ArrayList yValue = new ArrayList();
            var result = (from c in context.Countries select c);
            result.ToList().ForEach(rs => xValue.Add(rs.CountryName));
            result.ToList().ForEach(rs => yValue.Add(rs.Papulation));

            new Chart(width: 600, height: 400, theme: ChartTheme.Vanilla)
                .AddTitle("Chart For Growth [Coulum chart]")
                .AddSeries("Default", chartType: "Pie", xValue: xValue, yValues: yValue)
                .Write("bmp");
            return null;
        }
        public ActionResult Column()
        {
            var context = new HdMvcEntities();
            ArrayList xValue = new ArrayList();
            ArrayList yValue = new ArrayList();
            var result = (from c in context.Countries select c);
            result.ToList().ForEach(rs => xValue.Add(rs.CountryName));
            result.ToList().ForEach(rs => yValue.Add(rs.Papulation));

            new Chart(width: 600, height: 400, theme: ChartTheme.Vanilla)
                .AddTitle("Chart For Growth [Coulum chart]")
                .AddSeries("Default", chartType: "Column", xValue: xValue, yValues: yValue)
                .Write("bmp");
            return null;
        }
        public ActionResult BubbleBreak()
        {
            var context = new HdMvcEntities();
            ArrayList xValue = new ArrayList();
            ArrayList yValue = new ArrayList();
            var result = (from c in context.Countries select c);
            result.ToList().ForEach(rs => xValue.Add(rs.CountryName));
            result.ToList().ForEach(rs => yValue.Add(rs.Papulation));

            new Chart(width: 600, height: 400, theme: ChartTheme.Blue)
                .AddTitle("Chart For Growth [BubbleBreak]")
                .AddSeries("Default", chartType: "Candlestick", xValue: xValue, yValues: yValue)
                .Write("bmp");
            return null;
        }
        //public JsonResult GetChartData()
        //{
        //    var data = DB.Countries.ToList();
        //    return Json(data, JsonRequestBehavior.AllowGet);
        //}


    }
}