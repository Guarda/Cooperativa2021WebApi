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

//        internal SqlDataReader InsertarAfiliado(Model.Afiliado modAfiliado)
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


//                sqlParameters[0].Value = modAfiliado.IdCliente;
//                sqlParameters[1].Value = modAfiliado.IdCategoriaNegocio;
//                sqlParameters[2].Value = modAfiliado.Identificacion;
//                sqlParameters[3].Value = modAfiliado.Codigo;
//                sqlParameters[4].Value = modAfiliado.RazonSocial;
//                sqlParameters[5].Value = modAfiliado.NombreRepresentante;

//                if (!String.IsNullOrEmpty(modAfiliado.NombreRepresentante))
//                    sqlParameters[5].Value = modAfiliado.NombreRepresentante;
//                else
//                    sqlParameters[5].Value = DBNull.Value;

//                if (!String.IsNullOrEmpty(modAfiliado.CorreoElectronico))
//                    sqlParameters[6].Value = modAfiliado.CorreoElectronico;
//                else
//                    sqlParameters[6].Value = DBNull.Value;

//                sqlParameters[7].Value = modAfiliado.Telefono;
//                sqlParameters[8].Value = modAfiliado.Direccion;
//                sqlParameters[9].Value = modAfiliado.IdUbicacion;
//                sqlParameters[10].Value = modAfiliado.EnviarSMS;
//                sqlParameters[11].Value = modAfiliado.Activo;

//                if (modAfiliado.IdUsuarioCreacion.HasValue)
//                    sqlParameters[12].Value = modAfiliado.IdUsuarioCreacion.Value;
//                else
//                    sqlParameters[12].Value = DBNull.Value;

//                sqlParameters[13].Value = modAfiliado.FechaCreac
//ion;
//                sqlParameters[14].Value = modAfiliado.IpEquipoCreacion;

//                if (modAfiliado.IdUsuarioModificacion.HasValue)
//                    sqlParameters[15].Value = modAfiliado.IdUsuarioModificacion.Value;
//                else
//                    sqlParameters[15].Value = DBNull.Value;

//                sqlParameters[16].Value = modAfiliado.FechaModificacion;
//                sqlParameters[17].Value = modAfiliado.IpEquipoModificacion;


//                return conexion.FiltrarRegistro("dbo.InsertarAfiliado", sqlParameters);
//            }
//            catch
//            {
//                throw;
//            }
//        }

        //internal SqlDataReader ActualizarAfiliado(Model.Afiliado modAfiliado)
        //{
        //    try
        //    {
        //        SqlParameter[] sqlParameters = new SqlParameter[] {
        //                                                            new SqlParameter("@IdAfiliado", SqlDbType.Int),
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

        //        sqlParameters[0].Value = modAfiliado.IdAfiliado;
        //        sqlParameters[1].Value = modAfiliado.IdCliente;
        //        sqlParameters[2].Value = modAfiliado.IdCategoriaNegocio;

        //        if (!String.IsNullOrEmpty(modAfiliado.Identificacion))
        //            sqlParameters[3].Value = modAfiliado.Identificacion;
        //        else
        //            sqlParameters[3].Value = DBNull.Value;

        //        sqlParameters[4].Value = modAfiliado.Codigo;
        //        sqlParameters[5].Value = modAfiliado.CodigoSISGO;
        //        sqlParameters[6].Value = modAfiliado.RazonSocial;

        //        if (!String.IsNullOrEmpty(modAfiliado.NombreRepresentante))
        //            sqlParameters[7].Value = modAfiliado.NombreRepresentante;
        //        else
        //            sqlParameters[7].Value = DBNull.Value;

        //        if (!String.IsNullOrEmpty(modAfiliado.CorreoElectronico))
        //            sqlParameters[8].Value = modAfiliado.CorreoElectronico;
        //        else
        //            sqlParameters[8].Value = DBNull.Value;

        //        sqlParameters[9].Value = modAfiliado.Telefono;
        //        sqlParameters[10].Value = modAfiliado.Direccion;
        //        sqlParameters[11].Value = modAfiliado.IdUbicacion;
        //        sqlParameters[12].Value = modAfiliado.EnviarSMS;
        //        sqlParameters[13].Value = modAfiliado.Activo;
        //        sqlParameters[14].Value = modAfiliado.IdUsuarioCreacion;
        //        sqlParameters[15].Value = modAfiliado.FechaCreacion;
        //        sqlParameters[16].Value = modAfiliado.IpEquipoCreacion;
        //        sqlParameters[17].Value = modAfiliado.IdUsuarioModificacion;
        //        sqlParameters[18].Value = modAfiliado.FechaModificacion;
        //        sqlParameters[19].Value = modAfiliado.IpEquipoModificacion;

        //        return conexion.FiltrarRegistro("dbo.ActualizarAfiliado", sqlParameters);
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}



    }
}
