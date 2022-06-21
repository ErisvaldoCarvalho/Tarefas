using BLL;
using Model;
using System;
using System.Windows.Forms;

namespace UITarefa
{
    public partial class FormCadastrarComentario : Form
    {
        private int id_Tarefa;
        private int id_Usuario;
        public FormCadastrarComentario(int _id_Tarefa, int _id_Usuario)
        {
            InitializeComponent();
            id_Tarefa = _id_Tarefa;
            id_Usuario = _id_Usuario;
        }


        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                ComentarioBLL comentarioBLL = new ComentarioBLL();
                Comentario comentario = new Comentario();
                comentario.Descricao = descricaoTextBox.Text;
                comentario.Id_Tarefa = id_Tarefa;
                comentario.Id_Usuario = id_Usuario;
                comentarioBLL.Inserir(comentario);
                MessageBox.Show("Comentário inserido com sucesso!");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
