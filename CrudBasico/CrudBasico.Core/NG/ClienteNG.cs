using CrudBasico.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrudBasico.Core.DB;

namespace CrudBasico.Core.NG
{
	public class ClienteNG
	{
		public int Inserir(ClienteEntity cliente)
		{
			return new ClienteDB().Inserir(cliente);
		}
		public ClienteEntity Obter(int Id)
		{
			return new ClienteDB().Obter(Id);			
		}

		public ClienteEntity ObterEscondido(int Id)
		{
			var retorno = new ClienteDB().Obter(Id);

			retorno.Nome = retorno.Nome.Substring(0, 3) + "...";

			return retorno;
		}
		public List<ClienteEntity> Listar()
		{
			return new ClienteDB().Listar();
		}
		public bool Atualizar(ClienteEntity cliente)
		{
			return new ClienteDB().Atualizar(cliente);
		}
		public bool Delete(int Id)
		{
			return new ClienteDB().Delete(Id);
		}
	}
}
