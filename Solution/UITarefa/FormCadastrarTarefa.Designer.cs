
namespace UITarefa
{
    partial class FormCadastrarTarefa
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label idLabel;
            System.Windows.Forms.Label descricaoLabel;
            System.Windows.Forms.Label estatusLabel;
            this.idTextBox = new System.Windows.Forms.TextBox();
            this.tarefaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.descricaoTextBox = new System.Windows.Forms.TextBox();
            this.estatusTextBox = new System.Windows.Forms.TextBox();
            this.buttonSalvar = new System.Windows.Forms.Button();
            this.buttonCancelar = new System.Windows.Forms.Button();
            idLabel = new System.Windows.Forms.Label();
            descricaoLabel = new System.Windows.Forms.Label();
            estatusLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tarefaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.Location = new System.Drawing.Point(12, 9);
            idLabel.Name = "idLabel";
            idLabel.Size = new System.Drawing.Size(19, 17);
            idLabel.TabIndex = 1;
            idLabel.Text = "Id";
            // 
            // idTextBox
            // 
            this.idTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tarefaBindingSource, "Id", true));
            this.idTextBox.Location = new System.Drawing.Point(15, 29);
            this.idTextBox.Name = "idTextBox";
            this.idTextBox.Size = new System.Drawing.Size(100, 22);
            this.idTextBox.TabIndex = 2;
            // 
            // tarefaBindingSource
            // 
            this.tarefaBindingSource.DataSource = typeof(Model.Tarefa);
            // 
            // descricaoLabel
            // 
            descricaoLabel.AutoSize = true;
            descricaoLabel.Location = new System.Drawing.Point(118, 9);
            descricaoLabel.Name = "descricaoLabel";
            descricaoLabel.Size = new System.Drawing.Size(71, 17);
            descricaoLabel.TabIndex = 3;
            descricaoLabel.Text = "Descrição";
            // 
            // descricaoTextBox
            // 
            this.descricaoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tarefaBindingSource, "Descricao", true));
            this.descricaoTextBox.Location = new System.Drawing.Point(121, 29);
            this.descricaoTextBox.Name = "descricaoTextBox";
            this.descricaoTextBox.Size = new System.Drawing.Size(535, 22);
            this.descricaoTextBox.TabIndex = 4;
            // 
            // estatusLabel
            // 
            estatusLabel.AutoSize = true;
            estatusLabel.Location = new System.Drawing.Point(659, 9);
            estatusLabel.Name = "estatusLabel";
            estatusLabel.Size = new System.Drawing.Size(55, 17);
            estatusLabel.TabIndex = 5;
            estatusLabel.Text = "Estatus";
            // 
            // estatusTextBox
            // 
            this.estatusTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tarefaBindingSource, "Estatus", true));
            this.estatusTextBox.Location = new System.Drawing.Point(662, 29);
            this.estatusTextBox.Name = "estatusTextBox";
            this.estatusTextBox.Size = new System.Drawing.Size(126, 22);
            this.estatusTextBox.TabIndex = 6;
            // 
            // buttonSalvar
            // 
            this.buttonSalvar.Location = new System.Drawing.Point(632, 415);
            this.buttonSalvar.Name = "buttonSalvar";
            this.buttonSalvar.Size = new System.Drawing.Size(75, 23);
            this.buttonSalvar.TabIndex = 7;
            this.buttonSalvar.Text = "Salvar";
            this.buttonSalvar.UseVisualStyleBackColor = true;
            this.buttonSalvar.Click += new System.EventHandler(this.buttonSalvar_Click);
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Location = new System.Drawing.Point(713, 415);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(75, 23);
            this.buttonCancelar.TabIndex = 8;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // FormCadastrarTarefa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.buttonSalvar);
            this.Controls.Add(estatusLabel);
            this.Controls.Add(this.estatusTextBox);
            this.Controls.Add(descricaoLabel);
            this.Controls.Add(this.descricaoTextBox);
            this.Controls.Add(idLabel);
            this.Controls.Add(this.idTextBox);
            this.Name = "FormCadastrarTarefa";
            this.Text = "Cadastro de tarefas";
            ((System.ComponentModel.ISupportInitialize)(this.tarefaBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource tarefaBindingSource;
        private System.Windows.Forms.TextBox idTextBox;
        private System.Windows.Forms.TextBox descricaoTextBox;
        private System.Windows.Forms.TextBox estatusTextBox;
        private System.Windows.Forms.Button buttonSalvar;
        private System.Windows.Forms.Button buttonCancelar;
    }
}