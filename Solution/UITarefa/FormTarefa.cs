using BLL;
using System;
using System.Data;
using System.Windows.Forms;

namespace UITarefa
{
    public partial class FormTarefa : Form
    {
        public FormTarefa()
        {
            InitializeComponent();
        }

        private void FormTarefa_Load(object sender, EventArgs e)
        {
            Login();
        }

        private void Login()
        {
            using (FormLogin frm = new FormLogin())
            {
                frm.ShowDialog();
                if (!frm.Logou)
                    Application.Exit();
            }
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                TarefaBLL tarefaBLL = new TarefaBLL();
                tarefaBindingSource.DataSource = tarefaBLL.Buscar(textBoxBuscar.Text);
                CarregarComentarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            using (FormCadastrarTarefa frm = new FormCadastrarTarefa())
            {
                frm.ShowDialog();
            }
            buttonBuscar_Click(null, null);
        }

        private void buttonExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (tarefaBindingSource.Count < 1 || MessageBox.Show("Você realmente deseja excluir esta tarefa?", "", MessageBoxButtons.YesNo) == DialogResult.No)
                    return;

                TarefaBLL tarefaBLL = new TarefaBLL();
                int id = Convert.ToInt32(((DataRowView)tarefaBindingSource.Current).Row["Id"]);
                tarefaBLL.Excluir(id);
                buttonBuscar_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonAdicionarComentario_Click(object sender, EventArgs e)
        {
            if (tarefaBindingSource.Count < 1)
            {
                MessageBox.Show("Selecione uma tarefa para adicionar o comentário.");
                return;
            }

            int id_Tarefa = Convert.ToInt32(((DataRowView)tarefaBindingSource.Current).Row["Id"]);
            int id_Usuario = Convert.ToInt32(((DataRowView)tarefaBindingSource.Current).Row["Id_Usuario"]);
            using (FormCadastrarComentario frm = new FormCadastrarComentario(id_Tarefa, id_Usuario))
            {
                frm.ShowDialog();
            }
            CarregarComentarios();
        }

        private void tarefaBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            CarregarComentarios();
        }

        private void CarregarComentarios()
        {
            if (tarefaBindingSource.Count > 0)
            {
                ComentarioBLL comentarioBLL = new ComentarioBLL();
                int id_Tarefa = Convert.ToInt32(((DataRowView)tarefaBindingSource.Current).Row["Id"]);
                comentarioBindingSource.DataSource = comentarioBLL.Buscar(id_Tarefa);
            }
            else
                comentarioBindingSource.DataSource = null;
        }
    }
}
