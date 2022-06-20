using DAL;
using Model;
using System.Data;

namespace BLL
{
    public class ComentarioBLL
    {
        public Comentario Inserir(Comentario _comentario)
        {
            ComentarioDAL comentarioDAL = new ComentarioDAL();
            return comentarioDAL.Inserir(_comentario);
        }
        public DataTable Buscar(int _id_tarefa)
        {
            ComentarioDAL comentarioDAL = new ComentarioDAL();
            return comentarioDAL.Buscar(_id_tarefa);
        }
    }
}
