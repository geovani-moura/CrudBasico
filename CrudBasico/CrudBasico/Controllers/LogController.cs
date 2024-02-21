using CrudBasico.Core.NG;
using CrudBasico.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrudBasico.Controllers
{
    public class LogController : Controller
    {
        // GET: Log
        public ActionResult Index()
        {
			var entityColecao = new LogNG().Listar();
			var modelColecao = new List<LogModel>();
			foreach (var item in entityColecao)
			{
				modelColecao.Add(new LogModel()
				{
					Id = item.Id,
					LogText = item.LogText,
					LogDate = item.LogDate,
				});
			}
			return View(modelColecao);
        }
    }
}