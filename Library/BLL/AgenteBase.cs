using System.Collections.Generic;
using System.Data.SqlClient;
using System;
using DataBase;


namespace BLL
{
    public class AgenteBase
    {
        public DAL.Agente dalAgente;
        public AgenteBase()
        {
            dalAgente = new DAL.Agente();
        }

        public List<Model.Agente> FiltrarAgente()
        {
            try
            {
                List<Model.Agente> listaAgente = new List<Model.Agente>();
                dalAgente.conexion.AbrirConexion();

                SqlDataReader sqlDataReader = dalAgente.FiltrarAgente();
                listaAgente = ConversorClases.ConvertDataTable<Model.Agente>(sqlDataReader);

                dalAgente.conexion.CerrarConexion();

                return listaAgente;
            }
            catch
            {
                throw;
            }
        }

        public Model.Agente FiltrarAgentexId(
  Int32 idAgente
       )
        {
            try
            {
                Model.Agente modAgente = new Model.Agente();
                dalAgente.conexion.AbrirConexion();

                SqlDataReader sqlDataReader = dalAgente.FiltrarAgentexId(
        idAgente
                );

                modAgente = ConversorClases.ConvertModel<Model.Agente>(sqlDataReader);

                dalAgente.conexion.CerrarConexion();

                return modAgente;
            }
            catch
            {
                throw;
            }
        }

        public Model.Agente ActualizarAgente(Model.Agente modAgente)
        {
            try
            {
                dalAgente.conexion.AbrirConexion();

                SqlDataReader sqlDataReader = dalAgente.ActualizarAgente(modAgente);

                modAgente = ConversorClases.ConvertModel<Model.Agente>(sqlDataReader);

                dalAgente.conexion.CerrarConexion();

                return modAgente;
            }
            catch
            {
                throw;
            }
        }

        public Model.Agente PromoverAfiliado(Model.Agente modAgente)
        {
            try
            {
                dalAgente.conexion.AbrirConexion();

                SqlDataReader sqlDataReader = dalAgente.PromoverAfiliado(modAgente);

                modAgente = ConversorClases.ConvertModel<Model.Agente>(sqlDataReader);

                dalAgente.conexion.CerrarConexion();

                return modAgente;
            }
            catch
            {
                throw;
            }
        }
    }
}
