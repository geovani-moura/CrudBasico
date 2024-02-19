using CrudBasico.Core.Entity;
using CrudBasico.Core.NG;
using CrudBasico.Models;
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
			var clienteEntityColecao = new ClienteNG().Listar();
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
			var clienteEntity = new ClienteNG().Obter(id);
			var clienteModel = new ClienteModel()
			{
				Id = clienteEntity.Id,
				Nome = clienteEntity.Nome
			};
			return View(clienteModel);
		}

		// GET: Cliente/Create
		public ActionResult Create()
		{
			return View();
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
				new ClienteNG().Inserir(clienteEntity);
				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		// GET: Cliente/Edit/5
		public ActionResult Edit(int id)
		{
			var clienteEntity = new ClienteNG().Obter(id);
			var clienteModel = new ClienteModel()
			{
				Id = clienteEntity.Id,
				Nome = clienteEntity.Nome
			};
			return View(clienteModel);
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
				new ClienteNG().Atualizar(clienteEntity);
				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		// GET: Cliente/Delete/5
		public ActionResult Delete(int id)
		{
			new ClienteNG().Delete(id);
			return RedirectToAction("Index");
		}

		// POST: Cliente/Delete/5
		[HttpPost]
		public ActionResult Delete(int id, FormCollection collection)
		{
			try
			{
				// TODO: Add delete logic here

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}
	}
}
