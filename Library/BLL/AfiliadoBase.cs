using System.Collections.Generic;
using System.Data.SqlClient;
using System;
using DataBase;

namespace BLL
{
    public class AfiliadoBase
    {
        public DAL.Afiliado dalAfiliado;
        public AfiliadoBase()
        {
            dalAfiliado = new DAL.Afiliado();
        }


        public List<Model.Afiliado> FiltrarAfiliado()
        {
            try
            {
                List<Model.Afiliado> listaAfiliado = new List<Model.Afiliado>();
                dalAfiliado.conexion.AbrirConexion();

                SqlDataReader sqlDataReader = dalAfiliado.FiltrarAfiliado();
                listaAfiliado = ConversorClases.ConvertDataTable<Model.Afiliado>(sqlDataReader);

                dalAfiliado.conexion.CerrarConexion();

                return listaAfiliado;
            }
            catch
            {
                throw;
            }
        }

        public Model.Afiliado FiltrarAfiliadoxId(
   Int32 idAfiliado
        )
        {
            try
            {
                Model.Afiliado modAfiliado = new Model.Afiliado();
                dalAfiliado.conexion.AbrirConexion();

                SqlDataReader sqlDataReader = dalAfiliado.FiltrarAfiliadoxId(
        idAfiliado
                );

                modAfiliado = ConversorClases.ConvertModel<Model.Afiliado>(sqlDataReader);

                dalAfiliado.conexion.CerrarConexion();

                return modAfiliado;
            }
            catch
            {
                throw;
            }
        }

        //public Model.Afiliado InsertarAfiliado(Model.Afiliado modAfiliado)
        //{
        //    try
        //    {
        //        dalAfiliado.conexion.AbrirConexion();

        //        SqlDataReader sqlDataReader = dalAfiliado.InsertarAfiliado(modAfiliado);

        //        modAfiliado = ConversorClases.ConvertModel<Model.Afiliado>(sqlDataReader);

        //        dalAfiliado.conexion.CerrarConexion();

        //        return modAfiliado;
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}

        //public Model.Afiliado ActualizarAfiliado(Model.Afiliado modAfiliado)
        //{
        //    try
        //    {
        //        dalAfiliado.conexion.AbrirConexion();

        //        SqlDataReader sqlDataReader = dalAfiliado.ActualizarAfiliado(modAfiliado);

        //        modAfiliado = ConversorClases.ConvertModel<Model.Afiliado>(sqlDataReader);

        //        dalAfiliado.conexion.CerrarConexion();

        //        return modAfiliado;
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}

    }
}