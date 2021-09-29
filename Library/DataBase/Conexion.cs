using System;
using System.Data;
using System.Data.SqlClient;

namespace DataBase
{
    public class Conexion
    {
        string CooperativaConnectionString = "Data Source=.;Initial Catalog=SICT; Integrated Security=True";

        public SqlConnection _conexion = new SqlConnection();

        public Conexion()
        {
            this.CooperativaConnectionString = Environment.GetEnvironmentVariable("CooperativaConnection");

            _conexion.ConnectionString = CooperativaConnectionString;
        }

        public void AbrirConexion()
        {
            try
            {
                _conexion.Open();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public void CerrarConexion()
        {
            try
            {
                _conexion.Close();
            }
            catch (Exception e)
            {
                throw;
            }
        }


        public SqlDataReader FiltrarRegistro(
            String procedimientoAlmacenado,
            SqlParameter[] sqlParameterCollection
            )
        {
            using SqlCommand sqlCommand = new SqlCommand(procedimientoAlmacenado, _conexion);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            Console.WriteLine($"Ejecutando procedimiento: {procedimientoAlmacenado}");

            if (sqlParameterCollection != null)
                sqlCommand.Parameters.AddRange(sqlParameterCollection);

            return sqlCommand.ExecuteReader();
        }
    }
}
