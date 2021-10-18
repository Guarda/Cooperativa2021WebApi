using System.Data;
using System.Data.SqlClient;
using System;


namespace DAL
{
    public abstract class AgenteBase
    {
        public DataBase.Conexion conexion;
        public AgenteBase()
        {
            this.conexion = new DataBase.Conexion();
        }

        public SqlDataReader FiltrarAgente()
        {
            try
            {
                return conexion.FiltrarRegistro("dbo.FiltrarAgentes", null);
            }
            catch
            {
                throw;
            }
        }
    }
}
