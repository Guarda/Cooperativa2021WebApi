using System.Data;
using System.Data.SqlClient;
using System;

namespace DAL
{
    public abstract class AfiliadoSinAsignarBase
    {
        public DataBase.Conexion conexion;
        public AfiliadoSinAsignarBase()
        {
            this.conexion = new DataBase.Conexion();
        }

        public SqlDataReader FiltrarAfiliadosSinAsignar()
        {
            try
            {
                return conexion.FiltrarRegistro("dbo.FiltrarAfiliadosSinAsignar", null);
            }
            catch
            {
                throw;
            }
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
