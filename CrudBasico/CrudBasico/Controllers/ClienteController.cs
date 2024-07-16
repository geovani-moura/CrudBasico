using CrudBasico.Core.Entity;
using CrudBasico.Core.NG;
using CrudBasico.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrudBasico.Controllers
{
	public class ClienteController : Controller
	{
		// GET: Cliente
		public ActionResult Index()
		{
			var clienteNG = new ClienteNG();
			var clienteEntityColecao = clienteNG.Listar();

            var clienteModelColecao = new List<ClienteModel>();
			foreach (var item in clienteEntityColecao)
			{
				clienteModelColecao.Add(new ClienteModel()
				{
					Id = item.Id,
					Nome = item.Nome
				});
			}
			return View(clienteModelColecao);
		}

		// GET: Cliente/Details/5
		public ActionResult Details(int id)
		{
			try
			{

                var clienteNG = new ClienteNG();
                var clienteEntity = clienteNG.ObterEscondido(id);
				var clienteModel = new ClienteModel()
				{
					Id = clienteEntity.Id,
					Nome = clienteEntity.Nome
				};
				return View(clienteModel);

			}
			catch (Exception ex)
			{
                var logNG = new LogNG();
                logNG.Inserir(ex.ToString());
				return RedirectToAction("Index");
			}
		}

		// GET: Cliente/Create
		public ActionResult Create()
		{
			var model = new ClienteModel();
			return View(model);
		}

		// POST: Cliente/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(ClienteModel clienteModel)
		{
			try
			{
				var clienteEntity = new ClienteEntity()
				{
					Id = clienteModel.Id,
					Nome = clienteModel.Nome
				};
                var clienteNG = new ClienteNG();
                clienteNG.Inserir(clienteEntity);
				return RedirectToAction("Index");
			}
			catch (Exception ex)
			{
                var logNG = new LogNG();
                logNG.Inserir(ex.ToString());
				return RedirectToAction("Index");
			}
		}

		// GET: Cliente/Edit/5
		public ActionResult Edit(int id)
		{
			try
			{
                var clienteNG = new ClienteNG();
                var clienteEntity = clienteNG.Obter(id);
				var clienteModel = new ClienteModel()
				{
					Id = clienteEntity.Id,
					Nome = clienteEntity.Nome
				};
				return View(clienteModel);
			}
			catch (Exception ex)
			{
                var logNG = new LogNG();
                logNG.Inserir(ex.ToString());
				return RedirectToAction("Index");
			}
		}

		// POST: Cliente/Edit/5
		[HttpPost]
		public ActionResult Edit(ClienteModel clienteModel)
		{
			try
			{
				var clienteEntity = new ClienteEntity()
				{
					Id = clienteModel.Id,
					Nome = clienteModel.Nome
				};
                var clienteNG = new ClienteNG();
                clienteNG.Atualizar(clienteEntity);
				return RedirectToAction("Index");
			}
			catch (Exception ex)
			{
                var logNG = new LogNG();
                logNG.Inserir(ex.ToString());
				return RedirectToAction("Index");
			}
		}

		// GET: Cliente/Delete/5
		public ActionResult Delete(int id)
		{
			try
			{
                var clienteNG = new ClienteNG();
                clienteNG.Delete(id);
				return RedirectToAction("Index");
			}
			catch (Exception ex)
			{
				var logNG = new LogNG();
                logNG.Inserir(ex.ToString());
				return RedirectToAction("Index");
			}
		}

	}
}
