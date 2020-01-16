using SistemaFesta.Models;
using System.Linq;

namespace SistemaFesta.DAO
{
    public class AdiministradorDAO
    {
        public FestaContext contexto = new FestaContext();
        public Administrador BuscarAdministrador(string login, string senha)
        {
            return contexto.Administrador.FirstOrDefault(x => x.NomeUsuario == login && x.Senha == senha);
        }
    }
}