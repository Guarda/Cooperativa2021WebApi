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

    }
}
