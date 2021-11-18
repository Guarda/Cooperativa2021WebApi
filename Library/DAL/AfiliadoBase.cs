using System.Data;
using System.Data.SqlClient;
using System;

namespace DAL
{
    public abstract class AfiliadoBase
    {
        public DataBase.Conexion conexion;
        public AfiliadoBase()
        {
            this.conexion = new DataBase.Conexion();
        }

        public SqlDataReader FiltrarAfiliado()
        {
            try
            {
                return conexion.FiltrarRegistro("dbo.FiltrarAfiliado", null);
            }
            catch
            {
                throw;
            }
        }

        public SqlDataReader FiltrarAfiliadoxId(
   Int32 idAfiliado
        )
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[] {
                                                                    new SqlParameter("@IdAfiliado", SqlDbType.Int),
                 };


                sqlParameters[0].Value = idAfiliado;

                return conexion.FiltrarRegistro("dbo.FiltrarAfiliadoxId", sqlParameters);
            }
            catch
            {
                throw;
            }
        }

        public SqlDataReader FiltrarAfiliadoxNombreUsuario(
   String NombreUsuario
        )
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[] {
                                                                    new SqlParameter("@NombreUsuario", SqlDbType.VarChar),
                 };


                sqlParameters[0].Value = NombreUsuario;

                return conexion.FiltrarRegistro("dbo.FiltrarAfiliadoxNombreUsuario", sqlParameters);
            }
            catch
            {
                throw;
            }
        }


        internal SqlDataReader InsertarAfiliado(Model.Afiliado modAfiliado)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[] {
                                    new SqlParameter("@IdReferente", SqlDbType.Int),
                                     new SqlParameter("@NombreAfiliado", SqlDbType.VarChar),
                                     new SqlParameter("@ApellidoAfiliado", SqlDbType.VarChar),
                                     new SqlParameter("@Celular", SqlDbType.Int),
                                     new SqlParameter("@TelefonoDomicilio", SqlDbType.Int),
                                     new SqlParameter("@CorreoElectronico", SqlDbType.VarChar),
                                     new SqlParameter("@Cedula", SqlDbType.VarChar),
                                     new SqlParameter("@Direccion1", SqlDbType.VarChar),
                                     new SqlParameter("@Direccion2", SqlDbType.VarChar),
                                     new SqlParameter("@fechainscripcion", SqlDbType.Date),
                                     new SqlParameter("@IdEstado", SqlDbType.Int),
                                     new SqlParameter("@IdCargo", SqlDbType.Int),
                                     new SqlParameter("@NombreUsuario", SqlDbType.VarChar),
                                     new SqlParameter("@Contraseña", SqlDbType.VarChar),
                                     
                 };


                sqlParameters[0].Value = modAfiliado.IdReferente;
                sqlParameters[1].Value = modAfiliado.NombreAfiliado;
                sqlParameters[2].Value = modAfiliado.ApellidoAfiliado;
                sqlParameters[3].Value = modAfiliado.Celular;
                sqlParameters[4].Value = modAfiliado.TelefonoDomicilio;
                sqlParameters[5].Value = modAfiliado.CorreoElectronico;
                sqlParameters[6].Value = modAfiliado.Cedula;
                sqlParameters[7].Value = modAfiliado.Direccion1;
                sqlParameters[8].Value = modAfiliado.Direccion2;
                sqlParameters[9].Value = modAfiliado.FechaInscripcion;
                sqlParameters[10].Value = modAfiliado.IdEstado;
                sqlParameters[11].Value = modAfiliado.IdCargo;
                sqlParameters[12].Value = modAfiliado.NombreUsuario;
                sqlParameters[13].Value = modAfiliado.Contraseña;

                if (!String.IsNullOrEmpty(modAfiliado.NombreAfiliado))
                    sqlParameters[5].Value = modAfiliado.NombreAfiliado;
                else
                    sqlParameters[5].Value = DBNull.Value;

                if (!String.IsNullOrEmpty(modAfiliado.CorreoElectronico))
                    sqlParameters[6].Value = modAfiliado.CorreoElectronico;
                else
                    sqlParameters[6].Value = DBNull.Value;


                return conexion.FiltrarRegistro("dbo.InsertarAfiliado", sqlParameters);
            }
            catch
            {
                throw;
            }
        }

        internal SqlDataReader ActualizarAfiliado(Model.Afiliado modAfiliado)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[] {
                                                                    
                 new SqlParameter("@IdAfiliado", SqlDbType.Int),
                 new SqlParameter("@IdReferente", SqlDbType.Int),
                 new SqlParameter("@NombreAfiliado", SqlDbType.VarChar),
                 new SqlParameter("@ApellidoAfiliado", SqlDbType.VarChar),
                 new SqlParameter("@Celular", SqlDbType.Int),
                 new SqlParameter("@TelefonoDomicilio", SqlDbType.Int),
                 new SqlParameter("@CorreoElectronico", SqlDbType.VarChar),
                 new SqlParameter("@Cedula", SqlDbType.VarChar),
                 new SqlParameter("@Direccion1", SqlDbType.VarChar),
                 new SqlParameter("@Direccion2", SqlDbType.VarChar),
                 new SqlParameter("@FechaInscripcion", SqlDbType.Date),                 
                 new SqlParameter("@IdEstado", SqlDbType.Int),
                 new SqlParameter("@IdCargo", SqlDbType.Int),
                 new SqlParameter("@NombreUsuario", SqlDbType.VarChar),
                 new SqlParameter("@Contraseña", SqlDbType.VarChar),
                 };

                sqlParameters[0].Value = modAfiliado.IdAfiliado;
                sqlParameters[1].Value = modAfiliado.IdReferente;
                sqlParameters[2].Value = modAfiliado.NombreAfiliado;
                sqlParameters[3].Value = modAfiliado.ApellidoAfiliado;
                sqlParameters[4].Value = modAfiliado.Celular;
                sqlParameters[5].Value = modAfiliado.TelefonoDomicilio;
                sqlParameters[6].Value = modAfiliado.CorreoElectronico;
                sqlParameters[7].Value = modAfiliado.Cedula;
                sqlParameters[8].Value = modAfiliado.Direccion1;
                sqlParameters[9].Value = modAfiliado.Direccion2;
                sqlParameters[10].Value = modAfiliado.FechaInscripcion;               
                sqlParameters[11].Value = modAfiliado.IdEstado;
                sqlParameters[12].Value = modAfiliado.IdCargo;
                sqlParameters[13].Value = modAfiliado.NombreUsuario;
                sqlParameters[14].Value = modAfiliado.Contraseña;

                return conexion.FiltrarRegistro("dbo.ActualizarAfiliado", sqlParameters);
            }
            catch
            {
                throw;
            }
        }

        internal SqlDataReader PromoverAfiliado(Model.Afiliado modAfiliado)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[] {

                 new SqlParameter("@IdAfiliado", SqlDbType.Int),                 
                 new SqlParameter("@FechaContrato", SqlDbType.Date)
                
                 };

                sqlParameters[0].Value = modAfiliado.IdAfiliado;
                sqlParameters[1].Value = modAfiliado.FechaContrato;                

                return conexion.FiltrarRegistro("dbo.PromoverAfiliado", sqlParameters);
            }
            catch
            {
                throw;
            }
        }



    }
}
