using System.Data;
using System.Data.SqlClient;
using System;

namespace DAL
{
    public abstract class ServiciosBase
    {
        public DataBase.Conexion conexion;
        public ServiciosBase()
        {
            this.conexion = new DataBase.Conexion();
        }

        public SqlDataReader FiltrarServicios()
        {
            try
            {
                return conexion.FiltrarRegistro("dbo.FiltrarServicios", null);
            }
            catch
            {
                throw;
            }
        }

        public SqlDataReader FiltrarServiciosxId(
   Int32 idServicio
        )
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[] {
                                                                    new SqlParameter("@IdServicio", SqlDbType.Int),
                 };


                sqlParameters[0].Value = idServicio;

                return conexion.FiltrarRegistro("dbo.FiltrarServicioxId", sqlParameters);
            }
            catch
            {
                throw;
            }
        }

        //        internal SqlDataReader InsertarServicio(Model.Servicio modServicio)
        //        {
        //            try
        //            {
        //                SqlParameter[] sqlParameters = new SqlParameter[] {
        //                                                                    new SqlParameter("@IdCliente", SqlDbType.Int),
        //                 new SqlParameter("@IdCategoriaNegocio", SqlDbType.VarChar),
        //                 new SqlParameter("@Identificacion", SqlDbType.VarChar),
        //                 new SqlParameter("@Codigo", SqlDbType.VarChar),
        //                 new SqlParameter("@RazonSocial", SqlDbType.VarChar),
        //                 new SqlParameter("@NombreRepresentante", SqlDbType.VarChar),
        //                 new SqlParameter("@CorreoElectronico", SqlDbType.VarChar),
        //                 new SqlParameter("@Telefono", SqlDbType.VarChar),
        //                 new SqlParameter("@Direccion", SqlDbType.VarChar),
        //                 new SqlParameter("@IdUbicacion", SqlDbType.VarChar),
        //                 new SqlParameter("@EnviarSMS", SqlDbType.Bit),
        //                 new SqlParameter("@Activo", SqlDbType.Bit),
        //                 new SqlParameter("@IdUsuarioCreacion", SqlDbType.Int),
        //                 new SqlParameter("@FechaCreacion", SqlDbType.DateTime),
        //                 new SqlParameter("@IpEquipoCreacion", SqlDbType.VarChar),
        //                 new SqlParameter("@IdUsuarioModificacion", SqlDbType.Int),
        //                 new SqlParameter("@FechaModificacion", SqlDbType.DateTime),
        //                 new SqlParameter("@IpEquipoModificacion", SqlDbType.VarChar)
        //                 };


        //                sqlParameters[0].Value = modServicio.IdCliente;
        //                sqlParameters[1].Value = modServicio.IdCategoriaNegocio;
        //                sqlParameters[2].Value = modServicio.Identificacion;
        //                sqlParameters[3].Value = modServicio.Codigo;
        //                sqlParameters[4].Value = modServicio.RazonSocial;
        //                sqlParameters[5].Value = modServicio.NombreRepresentante;

        //                if (!String.IsNullOrEmpty(modServicio.NombreRepresentante))
        //                    sqlParameters[5].Value = modServicio.NombreRepresentante;
        //                else
        //                    sqlParameters[5].Value = DBNull.Value;

        //                if (!String.IsNullOrEmpty(modServicio.CorreoElectronico))
        //                    sqlParameters[6].Value = modServicio.CorreoElectronico;
        //                else
        //                    sqlParameters[6].Value = DBNull.Value;

        //                sqlParameters[7].Value = modServicio.Telefono;
        //                sqlParameters[8].Value = modServicio.Direccion;
        //                sqlParameters[9].Value = modServicio.IdUbicacion;
        //                sqlParameters[10].Value = modServicio.EnviarSMS;
        //                sqlParameters[11].Value = modServicio.Activo;

        //                if (modServicio.IdUsuarioCreacion.HasValue)
        //                    sqlParameters[12].Value = modServicio.IdUsuarioCreacion.Value;
        //                else
        //                    sqlParameters[12].Value = DBNull.Value;

        //                sqlParameters[13].Value = modServicio.FechaCreac
        //ion;
        //                sqlParameters[14].Value = modServicio.IpEquipoCreacion;

        //                if (modServicio.IdUsuarioModificacion.HasValue)
        //                    sqlParameters[15].Value = modServicio.IdUsuarioModificacion.Value;
        //                else
        //                    sqlParameters[15].Value = DBNull.Value;

        //                sqlParameters[16].Value = modServicio.FechaModificacion;
        //                sqlParameters[17].Value = modServicio.IpEquipoModificacion;


        //                return conexion.FiltrarRegistro("dbo.InsertarServicio", sqlParameters);
        //            }
        //            catch
        //            {
        //                throw;
        //            }
        //        }

        //internal SqlDataReader ActualizarServicio(Model.Servicio modServicio)
        //{
        //    try
        //    {
        //        SqlParameter[] sqlParameters = new SqlParameter[] {
        //                                                            new SqlParameter("@IdServicio", SqlDbType.Int),
        //         new SqlParameter("@IdCliente", SqlDbType.Int),
        //         new SqlParameter("@IdCategoriaNegocio", SqlDbType.VarChar),
        //         new SqlParameter("@Identificacion", SqlDbType.VarChar),
        //         new SqlParameter("@Codigo", SqlDbType.VarChar),
        //         new SqlParameter("@CodigoSISGO", SqlDbType.VarChar),
        //         new SqlParameter("@RazonSocial", SqlDbType.VarChar),
        //         new SqlParameter("@NombreRepresentante", SqlDbType.VarChar),
        //         new SqlParameter("@CorreoElectronico", SqlDbType.VarChar),
        //         new SqlParameter("@Telefono", SqlDbType.VarChar),
        //         new SqlParameter("@Direccion", SqlDbType.VarChar),
        //         new SqlParameter("@IdUbicacion", SqlDbType.VarChar),
        //         new SqlParameter("@EnviarSMS", SqlDbType.Bit),
        //         new SqlParameter("@Activo", SqlDbType.Bit),
        //         new SqlParameter("@IdUsuarioCreacion", SqlDbType.Int),
        //         new SqlParameter("@FechaCreacion", SqlDbType.DateTime),
        //         new SqlParameter("@IpEquipoCreacion", SqlDbType.VarChar),
        //         new SqlParameter("@IdUsuarioModificacion", SqlDbType.Int),
        //         new SqlParameter("@FechaModificacion", SqlDbType.DateTime),
        //         new SqlParameter("@IpEquipoModificacion", SqlDbType.VarChar)
        //         };

        //        sqlParameters[0].Value = modServicio.IdServicio;
        //        sqlParameters[1].Value = modServicio.IdCliente;
        //        sqlParameters[2].Value = modServicio.IdCategoriaNegocio;

        //        if (!String.IsNullOrEmpty(modServicio.Identificacion))
        //            sqlParameters[3].Value = modServicio.Identificacion;
        //        else
        //            sqlParameters[3].Value = DBNull.Value;

        //        sqlParameters[4].Value = modServicio.Codigo;
        //        sqlParameters[5].Value = modServicio.CodigoSISGO;
        //        sqlParameters[6].Value = modServicio.RazonSocial;

        //        if (!String.IsNullOrEmpty(modServicio.NombreRepresentante))
        //            sqlParameters[7].Value = modServicio.NombreRepresentante;
        //        else
        //            sqlParameters[7].Value = DBNull.Value;

        //        if (!String.IsNullOrEmpty(modServicio.CorreoElectronico))
        //            sqlParameters[8].Value = modServicio.CorreoElectronico;
        //        else
        //            sqlParameters[8].Value = DBNull.Value;

        //        sqlParameters[9].Value = modServicio.Telefono;
        //        sqlParameters[10].Value = modServicio.Direccion;
        //        sqlParameters[11].Value = modServicio.IdUbicacion;
        //        sqlParameters[12].Value = modServicio.EnviarSMS;
        //        sqlParameters[13].Value = modServicio.Activo;
        //        sqlParameters[14].Value = modServicio.IdUsuarioCreacion;
        //        sqlParameters[15].Value = modServicio.FechaCreacion;
        //        sqlParameters[16].Value = modServicio.IpEquipoCreacion;
        //        sqlParameters[17].Value = modServicio.IdUsuarioModificacion;
        //        sqlParameters[18].Value = modServicio.FechaModificacion;
        //        sqlParameters[19].Value = modServicio.IpEquipoModificacion;

        //        return conexion.FiltrarRegistro("dbo.ActualizarServicio", sqlParameters);
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}


    }
}
