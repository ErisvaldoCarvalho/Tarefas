using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class UsuarioDAL
    {
        public DataTable BuscarUsuarioPorNome(string _nome)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Conexao.StringDeConexao;
                da.SelectCommand = new SqlCommand();
                da.SelectCommand.Connection = cn;
                da.SelectCommand.CommandText = "SP_BuscarUsuarioPorNome";
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter pnome = new SqlParameter("@Nome", SqlDbType.VarChar);
                pnome.Value = _nome;

                da.SelectCommand.Parameters.Add(pnome);

                cn.Open();
                da.Fill(dt);

                return dt;
            }
            catch(SqlException ex)
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
