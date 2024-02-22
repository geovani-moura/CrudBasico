using MVC_SQL_CRUD.CORE.DB;
using MVC_SQL_CRUD.CORE.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_SQL_CRUD.CORE.NG
{
	public class PedidoNG
	{
		public List<PedidoEntity> Listar()
		{
			var retornoLista = new PedidoDB().Listar();
			var retorno = new List<PedidoEntity>();
			foreach (var item in retornoLista)
			{
				if(item.Numero != 34)
				{
					retorno.Add(item);
				}
			}
			return retorno;
		}
	}
}
