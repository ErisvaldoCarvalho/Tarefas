using BLL;
using Model;
using System;
using System.Windows.Forms;

namespace UITarefa
{
    public partial class FormCadastrarTarefa : Form
    {
        public FormCadastrarTarefa()
        {
            InitializeComponent();
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                TarefaBLL tarefaBLL = new TarefaBLL();
                Tarefa tarefa = new Tarefa();
                tarefa.Descricao = descricaoTextBox.Text;
                tarefa.Estatus = estatusTextBox.Text;
                tarefa.Id_Usuario = 1;
                tarefaBLL.Inserir(tarefa);
                MessageBox.Show("Registro salvo com sucesso!");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
