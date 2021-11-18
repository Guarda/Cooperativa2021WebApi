using System.Collections.Generic;
using System.Data.SqlClient;
using System;
using DataBase;

namespace BLL
{
    public class AfiliadoSinAsignarBase
    {
        public DAL.AfiliadoSinAsignar dalAfiliado;
        public AfiliadoSinAsignarBase()
        {
            dalAfiliado = new DAL.AfiliadoSinAsignar();
        }

        public List<Model.Afiliado> FiltrarAfiliadoSinAsignar()
        {
            try
            {
                List<Model.Afiliado> listaAfiliado = new List<Model.Afiliado>();
                dalAfiliado.conexion.AbrirConexion();

                SqlDataReader sqlDataReader = dalAfiliado.FiltrarAfiliadosSinAsignar();
                listaAfiliado = ConversorClases.ConvertDataTable<Model.Afiliado>(sqlDataReader);

                dalAfiliado.conexion.CerrarConexion();

                return listaAfiliado;
            }
            catch
            {
                throw;
            }
        }

        public List<Model.Agente> FiltrarAgente()
        {
            try
            {
                List<Model.Agente> listaAgente = new List<Model.Agente>();
                dalAfiliado.conexion.AbrirConexion();

                SqlDataReader sqlDataReader = dalAfiliado.FiltrarAgente();
                listaAgente = ConversorClases.ConvertDataTable<Model.Agente>(sqlDataReader);

                dalAfiliado.conexion.CerrarConexion();

                return listaAgente;
            }
            catch
            {
                throw;
            }
        }
    }
}
