using Model;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class ComentarioDAL
    {
        public Comentario Inserir(Comentario _comentario)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conexao.StringDeConexao;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Sp_InserirComentario";

                SqlParameter pid = new SqlParameter("@Id", SqlDbType.Int);
                pid.Value = _comentario.Id;
                cmd.Parameters.Add(pid);

                SqlParameter pid_Uduario = new SqlParameter("@Id_Usuario", SqlDbType.Int);
                pid_Uduario.Value = _comentario.Id_Usuario;
                cmd.Parameters.Add(pid_Uduario);

                SqlParameter pid_Tarefa = new SqlParameter("@Id_Tarefa", SqlDbType.Int);
                pid_Tarefa.Value = _comentario.Id_Tarefa;
                cmd.Parameters.Add(pid_Tarefa);
                
                SqlParameter pdescricao = new SqlParameter("@Descricao", SqlDbType.VarChar);
                pdescricao.Value = _comentario.Descricao;
                cmd.Parameters.Add(pdescricao);

                cn.Open();
                cmd.ExecuteNonQuery();

                return _comentario;
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

        public DataTable Buscar(int _id_Tarefa)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conexao.StringDeConexao;
                da.SelectCommand = new SqlCommand();
                da.SelectCommand.Connection = cn;
                da.SelectCommand.CommandText = "SP_BuscarComentario";
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter pid_Tarefa = new SqlParameter("@Id_Tarefa", SqlDbType.Int);
                pid_Tarefa.Value = _id_Tarefa;

                da.SelectCommand.Parameters.Add(pid_Tarefa);

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
    }
}
