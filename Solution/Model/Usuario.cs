﻿namespace Model
{
    public class Usuario
    {
        private int id;
        private string nome;
        private string senha;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }
        public string Senha
        {
            get { return senha; }
            set { senha = value; }
        }
    }
}
