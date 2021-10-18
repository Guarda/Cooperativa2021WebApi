using System.Collections.Generic;
using System.Data.SqlClient;
using System;
using DataBase;

namespace BLL
{
    public class ServiciosBase
    {
        public DAL.Servicios dalServicios;
        public ServiciosBase()
        {
            dalServicios = new DAL.Servicios();
        }


        public List<Model.Servicios> FiltrarServicios()
        {
            try
            {
                List<Model.Servicios> listaServicios = new List<Model.Servicios>();
                dalServicios.conexion.AbrirConexion();

                SqlDataReader sqlDataReader = dalServicios.FiltrarServicios();
                listaServicios = ConversorClases.ConvertDataTable<Model.Servicios>(sqlDataReader);

                dalServicios.conexion.CerrarConexion();

                return listaServicios;
            }
            catch
            {
                throw;
            }
        }

        public Model.Servicios FiltrarServiciosxId(
   Int32 idServicios
        )
        {
            try
            {
                Model.Servicios modServicios = new Model.Servicios();
                dalServicios.conexion.AbrirConexion();

                SqlDataReader sqlDataReader = dalServicios.FiltrarServiciosxId(
        idServicios
                );

                modServicios = ConversorClases.ConvertModel<Model.Servicios>(sqlDataReader);

                dalServicios.conexion.CerrarConexion();

                return modServicios;
            }
            catch
            {
                throw;
            }
        }

        //public Model.Servicios InsertarServicios(Model.Servicios modServicios)
        //{
        //    try
        //    {
        //        dalServicios.conexion.AbrirConexion();

        //        SqlDataReader sqlDataReader = dalServicios.InsertarServicios(modServicios);

        //        modServicios = ConversorClases.ConvertModel<Model.Servicios>(sqlDataReader);

        //        dalServicios.conexion.CerrarConexion();

        //        return modServicios;
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}

        //public Model.Servicios ActualizarServicios(Model.Servicios modServicios)
        //{
        //    try
        //    {
        //        dalServicios.conexion.AbrirConexion();

        //        SqlDataReader sqlDataReader = dalServicios.ActualizarServicios(modServicios);

        //        modServicios = ConversorClases.ConvertModel<Model.Servicios>(sqlDataReader);

        //        dalServicios.conexion.CerrarConexion();

        //        return modServicios;
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}

    }
}
