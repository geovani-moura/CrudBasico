using MVC_SQL_CRUD.CORE.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_SQL_CRUD.CORE.DB
{
	internal class PedidoDB : BaseDB
	{
		public List<PedidoEntity> Listar()
		{
			var retorno = new List<PedidoEntity>();
			string query = "SELECT Id, Numero FROM TB_Pedido";
			var dataTable = Reads(query);
			if (dataTable != null && dataTable.Rows != null && dataTable.Rows.Count > 0)
			{
				foreach (DataRow row in dataTable.Rows)
				{
					retorno.Add(new PedidoEntity()
					{
						Id = Convert.ToInt32(row["Id"]),
						Numero = Convert.ToInt32(row["Numero"]),
					});
				}
			}
			return retorno;
		}

	}
}
