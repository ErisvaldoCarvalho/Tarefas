using BLL;
using Infra;
using System;
using System.Data;
using System.Windows.Forms;

namespace UITarefa
{
    public partial class FormLogin : Form
    {
        public bool Logou;
        public FormLogin()
        {
            InitializeComponent();
            Logou = false;
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonEntrar_Click(object sender, EventArgs e)
        {
            try
            {

                UsuarioBLL usuarioBLL = new UsuarioBLL();
                BindingSource usuarioBindingSource = new BindingSource();
                usuarioBindingSource.DataSource = usuarioBLL.BuscarUsuarioPorNome(textBoxUsuario.Text);

                if (usuarioBindingSource.Count != 0)
                {
                    string nome = ((DataRowView)usuarioBindingSource.Current).Row["Nome"].ToString();
                    string senha = ((DataRowView)usuarioBindingSource.Current).Row["Senha"].ToString();

                    if (nome == textBoxUsuario.Text && senha == textBoxSenha.Text)
                    {
                        Logou = true;
                        Arquivo.GravarLog("O usuário logou no sistema.");
                        Close();
                    }
                    else
                    {
                        Arquivo.GravarLog("O usuário informou um nome de usuário ou senha incorreta.");
                        MessageBox.Show("Usuário ou senha incorreta!");
                        textBoxSenha.Text = "";
                        textBoxSenha.Focus();
                    }
                }
                else
                {
                    Arquivo.GravarLog("O usuário informou um nome de usuário ou senha incorreta.");
                    MessageBox.Show("Usuário ou senha incorreta!");
                    textBoxSenha.Text = "";
                    textBoxSenha.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            Arquivo.GravarLog("A tela de login foi aberta.");
        }
    }
}
