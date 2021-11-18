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

        public SqlDataReader FiltrarAgentexId(
  Int32 idAgente
       )
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[] {
                                                                    new SqlParameter("@IdAgente", SqlDbType.Int),
                 };


                sqlParameters[0].Value = idAgente;

                return conexion.FiltrarRegistro("dbo.FiltrarAgentesxId", sqlParameters);
            }
            catch
            {
                throw;
            }
        }

        internal SqlDataReader ActualizarAgente(Model.Agente modAgente)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[] {

                 new SqlParameter("@IdAfiliado", SqlDbType.Int),
                 new SqlParameter("@IdAgente", SqlDbType.Int),
                 new SqlParameter("@NombreAgente", SqlDbType.VarChar),
                 new SqlParameter("@ApellidoAgente", SqlDbType.VarChar),                 
                 new SqlParameter("@FechaContrato", SqlDbType.Date),
                 new SqlParameter("@IdEstado", SqlDbType.Int)                 
                 };

                sqlParameters[0].Value = modAgente.IdAfiliado;
                sqlParameters[1].Value = modAgente.IdAgente;
                sqlParameters[2].Value = modAgente.NombreAgente;
                sqlParameters[3].Value = modAgente.ApellidoAgente;                
                sqlParameters[4].Value = modAgente.FechaContrato;
                sqlParameters[5].Value = modAgente.IdEstado;
                         

                return conexion.FiltrarRegistro("dbo.ActualizarAgente", sqlParameters);
            }
            catch
            {
                throw;
            }
        }

        internal SqlDataReader PromoverAfiliado(Model.Agente modAgente)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[] {

                 new SqlParameter("@IdAfiliado", SqlDbType.Int),
                 new SqlParameter("@FechaContrato", SqlDbType.Date)

                 };

                sqlParameters[0].Value = modAgente.IdAfiliado;
                sqlParameters[1].Value = modAgente.FechaContrato;

                return conexion.FiltrarRegistro("dbo.PromoverAfiliado", sqlParameters);
            }
            catch
            {
                throw;
            }
        }
    }
}
