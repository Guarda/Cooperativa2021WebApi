using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;

namespace DataBase
{
    public static class ConversorClases
    {
        public static T ConvertModel<T>(SqlDataReader sqlDataReader)
        {
            DataTable dt = new DataTable();
            dt.Load(sqlDataReader);

            if (dt.Rows.Count > 0)
                return GetItem<T>(dt.Rows[0]);


            return (T)Activator.CreateInstance(typeof(T), null);
        }

        public static List<T> ConvertDataTable<T>(SqlDataReader sqlDataReader)
        {
            DataTable dt = new DataTable();
            dt.Load(sqlDataReader);

            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }

            return data;
        }

        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                    {
                        if (dr[column.ColumnName].GetType().ToString() == "System.DBNull")
                            pro.SetValue(obj, null, null);
                        else
                            pro.SetValue(obj, dr[column.ColumnName], null);

                        break;
                    }
                    else
                        continue;
                }
            }
            return obj;
        }

        public static DataTable ToDataTable<T>(IList<T> data)
        {
            FieldInfo[] myFieldInfo;
            Type myType = typeof(T);
            // Get the type and fields of FieldInfoClass.
            myFieldInfo = myType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance
                | BindingFlags.Public);

            DataTable dt = new DataTable();
            for (int i = 0; i < myFieldInfo.Length; i++)
            {
                FieldInfo property = myFieldInfo[i];
                dt.Columns.Add(property.Name, property.FieldType);
            }
            object[] values = new object[myFieldInfo.Length];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = myFieldInfo[i].GetValue(item);
                }
                dt.Rows.Add(values);
            }
            return dt;
        }

        public static DataTable ToListaIdentificador<T>(IList<T> data)
        {
            FieldInfo[] myFieldInfo;
            Type myType = typeof(T);
            // Get the type and fields of FieldInfoClass.
            myFieldInfo = myType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance
                | BindingFlags.Public);

            DataTable dt = new DataTable();
            for (int i = 0; i < myFieldInfo.Length; i++)
            {
                FieldInfo property = myFieldInfo[i];
                dt.Columns.Add("Identificador", property.FieldType);
            }
            object[] values = new object[myFieldInfo.Length];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = myFieldInfo[i].GetValue(item);
                }
                dt.Rows.Add(values);
            }
            return dt;
        }

    }
}