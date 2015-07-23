using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Uib.Mvc.Models;

namespace Uib.Mvc.Controllers
{
    public class EjemploController : Controller
    {
        // GET: Ejemplo
        public ActionResult Index(int city, string lang)
        {
            var myModel = new Models.ModeloEjemplo();
            myModel.Titulo = "Titulo del ejemplo";
            myModel.Hoteles = (List<Hotel>) new HotelController().Get(city, lang);


            //if (myModel.Hoteles.Count > 10)
            //{
            //    myModel.Hoteles = myModel.Hoteles.GetRange(0, 10);
            //}
            
            return View("Index", myModel);
        }
    }
}