using System;
using System.Collections.Generic;
using System.Reflection;
using System.Data.SqlClient;

namespace DAL
{
    public class Base : IBase
    {
        public int Key
        {
            get
            {
                foreach (PropertyInfo item in this.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
                {
                    OpcoesBase opcoesBase = (OpcoesBase)item.GetCustomAttribute(typeof(OpcoesBase));
                    if (opcoesBase != null && opcoesBase.ChavePrimaria)
                        return Convert.ToInt32(item.GetValue(this));
                }
                return 0;
            }
        }

        public virtual void Inserir()
        {
            using (SqlConnection sqlConnection = new SqlConnection(Conexao.StringDeConexao))
            {
                List<string> campos = new List<string>();
                List<string> valores = new List<string>();
                foreach (PropertyInfo item in this.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
                {
                    OpcoesBase opcoesBase = (OpcoesBase)item.GetCustomAttribute(typeof(OpcoesBase));
                    if (opcoesBase != null && opcoesBase.UsarNoBancoDeDados && !opcoesBase.AutoIncremento)
                    {
                        campos.Add(item.Name);
                        valores.Add("'" + item.GetValue(this) + "'");
                    }
                }

                string queryString = "INSERT INTO " + this.GetType().Name + "(" + string.Join(", ", campos.ToArray()) + ") VALUES(" + string.Join(", ", valores.ToArray()) + ")";
                SqlCommand sqlCommand = new SqlCommand(queryString, sqlConnection);
                sqlCommand.Connection.Open();
                sqlCommand.ExecuteNonQuery();
            }
        }
        public virtual void Atualizar()
        {
            using (SqlConnection sqlConnection = new SqlConnection(Conexao.StringDeConexao))
            {
                List<string> campos = new List<string>();
                string chavePrimaria = string.Empty;
                foreach (PropertyInfo item in this.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
                {
                    OpcoesBase opcoesBase = (OpcoesBase)item.GetCustomAttribute(typeof(OpcoesBase));
                    if (opcoesBase != null && opcoesBase.UsarNoBancoDeDados && !opcoesBase.ChavePrimaria)
                        campos.Add(item.Name + " = '" + item.GetValue(this) + "'");
                    if (opcoesBase != null && opcoesBase.UsarNoBancoDeDados && opcoesBase.ChavePrimaria)
                        chavePrimaria = item.Name + " = '" + item.GetValue(this) + "'";
                }
                string queryString = "UPDATE " + this.GetType().Name + " SET " +
                    string.Join(", ", campos) +
                    " WHERE " + chavePrimaria;

                SqlCommand sqlCommand = new SqlCommand(queryString, sqlConnection);
                sqlCommand.Connection.Open();
                sqlCommand.ExecuteNonQuery();
            }
        }

        public virtual void Excluir()
        {
            using (SqlConnection sqlConnection = new SqlConnection(Conexao.StringDeConexao))
            {
                string chavePrimaria = string.Empty;
                foreach (PropertyInfo item in this.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
                {
                    OpcoesBase opcoesBase = (OpcoesBase)item.GetCustomAttribute(typeof(OpcoesBase));
                    if (opcoesBase != null && opcoesBase.ChavePrimaria)
                        chavePrimaria = item.Name + " = '" + item.GetValue(this) + "'";
                }
                string queryString = "DELETE FROM " + this.GetType().Name + " WHERE " + chavePrimaria;

                SqlCommand sqlCommand = new SqlCommand(queryString, sqlConnection);
                sqlCommand.Connection.Open();
                sqlCommand.ExecuteNonQuery();
            }
        }
        public virtual List<IBase> Todos()
        {
            var retorno = new List<IBase>();
            using (SqlConnection sqlConnection = new SqlConnection(Conexao.StringDeConexao))
            {
                string queryString = "SELECT * FROM " + this.GetType().Name;
                SqlCommand sqlCommand = new SqlCommand(queryString, sqlConnection);
                sqlCommand.Connection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    var obj = (IBase)Activator.CreateInstance(this.GetType());
                    setProperty(ref obj, sqlDataReader);
                    retorno.Add(obj);
                }
            }
            return retorno;
        }
        public virtual List<IBase> Buscar()
        {
            var retorno = new List<IBase>();
            using (SqlConnection sqlConnection = new SqlConnection(Conexao.StringDeConexao))
            {
                List<string> where = new List<string>();
                string chavePrimaria = string.Empty;

                foreach (PropertyInfo item in this.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
                {
                    OpcoesBase opcoesBase = (OpcoesBase)item.GetCustomAttribute(typeof(OpcoesBase));
                    if (opcoesBase != null)
                    {
                        if (opcoesBase.ChavePrimaria)
                            chavePrimaria = item.Name;

                        if (opcoesBase.UsarParaBuscar)
                        {
                            var valor = item.GetValue(this);
                            if (valor != null && !(!opcoesBase.UsarParaBuscarMesmoZerado || opcoesBase.ChavePrimaria && (int)valor == 0))
                                where.Add(item.Name + " = '" + valor + "'");
                        }
                    }
                }
                string queryString = "SELECT * FROM " + this.GetType().Name + " WHERE " + chavePrimaria + " IS NOT NULL ";
                if (where.Count > 0)
                    queryString += " AND " + string.Join(" AND ", where.ToArray());

                SqlCommand sqlCommand = new SqlCommand(queryString, sqlConnection);
                sqlCommand.Connection.Open();

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    var obj = (IBase)Activator.CreateInstance(this.GetType());
                    setProperty(ref obj, sqlDataReader);
                    retorno.Add(obj);
                }
            }
            return retorno;
        }

        private void setProperty(ref IBase _obj, SqlDataReader _sqlDataReader)
        {
            foreach (PropertyInfo item in _obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                OpcoesBase opcoesBase = (OpcoesBase)item.GetCustomAttribute(typeof(OpcoesBase));
                if (opcoesBase != null && opcoesBase.UsarNoBancoDeDados)
                    if (item.PropertyType.Name == "Int32")
                        item.SetValue(_obj, _sqlDataReader[item.Name]);
                    else
                        item.SetValue(_obj, _sqlDataReader[item.Name].ToString());
            }
        }

        public virtual bool Existe()
        {
            bool retorno = false;
            using (SqlConnection sqlConnection = new SqlConnection(Conexao.StringDeConexao))
            {
                List<string> where = new List<string>();
                string chavePrimaria = string.Empty;

                foreach (PropertyInfo item in this.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
                {
                    OpcoesBase opcoesBase = (OpcoesBase)item.GetCustomAttribute(typeof(OpcoesBase));
                    if (opcoesBase != null)
                    {
                        if (opcoesBase.ChavePrimaria)
                            chavePrimaria = item.Name;
                        if (opcoesBase.UsarParaBuscar)
                        {
                            var valor = item.GetValue(this);
                            if (valor != null)
                                where.Add(item.Name + " = " + valor + "'");
                        }
                    }
                }

                string queryString = "SELECT TOP 1 1 FROM " + this.GetType().Name + " WHERE " + chavePrimaria + " IS NOT NULL ";
                if (where.Count > 0)
                    queryString += " AND " + string.Join(" AND ", where.ToArray());

                queryString += ") SELECT 1 AS Existe ELSE SELECT 0 AS Existe";

                SqlCommand sqlCommand = new SqlCommand(queryString, sqlConnection);
                sqlCommand.Connection.Open();

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    retorno = Convert.ToBoolean(sqlDataReader["Existe"]);
                }
            }
            return retorno;
        }

        public virtual void CriarTabela()
        {
            throw new NotImplementedException();
        }
    }
}
