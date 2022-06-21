using Model;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class TarefaDAL
    {
        public Tarefa Inserir(Tarefa _tarefa)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conexao.StringDeConexao;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Sp_InserirTarefa";

                SqlParameter pid = new SqlParameter("@Id", SqlDbType.Int);
                pid.Value = IncrementaID();
                cmd.Parameters.Add(pid);

                SqlParameter pid_Uduario = new SqlParameter("@Id_Usuario", SqlDbType.Int);
                pid_Uduario.Value = _tarefa.Id_Usuario;
                cmd.Parameters.Add(pid_Uduario);

                SqlParameter pdescricao = new SqlParameter("@Descricao", SqlDbType.VarChar);
                pdescricao.Value = _tarefa.Descricao;
                cmd.Parameters.Add(pdescricao);

                SqlParameter pestatus = new SqlParameter("@Estatus", SqlDbType.VarChar);
                pestatus.Value = _tarefa.Estatus;
                cmd.Parameters.Add(pestatus);

                cn.Open();
                cmd.ExecuteNonQuery();

                return _tarefa;
            }
            catch (SqlException ex)
            {
                throw new Exception("Servidor SQL Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        private int IncrementaID()
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conexao.StringDeConexao;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT ISNULL(MAX(ID), 0) + 1 FROM Tarefa";
                cn.Open();
                return (int)cmd.ExecuteScalar();
            }
            finally
            {
                cn.Close();
            }
        }

        public DataTable Buscar(string _filtro)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conexao.StringDeConexao;
                da.SelectCommand = new SqlCommand();
                da.SelectCommand.Connection = cn;
                da.SelectCommand.CommandText = "SP_BuscarTarefa";
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter pfiltro = new SqlParameter("@Filtro", SqlDbType.VarChar);
                pfiltro.Value = _filtro;

                da.SelectCommand.Parameters.Add(pfiltro);

                cn.Open();
                da.Fill(dt);

                return dt;
            }
            catch (SqlException ex)
            {
                throw new Exception("Servidor SQL Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        public bool Excluir(int _id)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conexao.StringDeConexao;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Sp_ExcluirTarefa";

                SqlParameter pid = new SqlParameter("@Id", SqlDbType.Int);
                pid.Value = _id;

                cmd.Parameters.Add(pid);

                cn.Open();
                int resultado = cmd.ExecuteNonQuery();
                if (resultado <= 0)
                    throw new Exception("Não foi possível excluir a tarefa: " + _id.ToString());

                return true;
            }
            catch (SqlException ex)
            {
                throw new Exception("Servidor SQL Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }
    }
}
