namespace Model
{
    public class Tarefa
    {
        private int id;
        private int id_Usuario;
        private string descricao;
        private string estatus;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public int Id_Usuario
        {
            get { return id_Usuario; }
            set { id_Usuario = value; }
        }
        public string Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }
        public string Estatus
        {
            get { return estatus; }
            set { estatus = value; }
        }
    }
}