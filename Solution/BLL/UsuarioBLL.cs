using DAL;
using System.Data;

namespace BLL
{
    public class UsuarioBLL
    {
        public DataTable BuscarUsuarioPorNome(string _nome)
        {
            UsuarioDAL usuarioDAL = new UsuarioDAL();
            return usuarioDAL.BuscarUsuarioPorNome(_nome);
        }
    }
}
