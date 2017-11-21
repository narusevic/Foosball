using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Reflection;
using System.Text;

namespace FoosballApi.Extensions
{
    public static class DataExtension
    {
        public static DataTable ToDataTable<T>(this IEnumerable<T> data)
        {
            var properties = TypeDescriptor.GetProperties(typeof(T));
            var table = new DataTable();

            foreach (PropertyDescriptor prop in properties)
            {
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }

            foreach (T item in data)
            {
                var row = table.NewRow();

                foreach (PropertyDescriptor prop in properties)
                {
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                }

                table.Rows.Add(row);
            }

            return table;
        }

        public static string ToCsvBase(this DataTable dataTable)
        {
            var result = new StringBuilder();

            foreach (DataRow row in dataTable.Rows)
            {
                for (var i = 0; i < dataTable.Columns.Count; i++)
                {
                    result.Append(/*"'" + */row[i]);
                    result.Append(/*i == dataTable.Columns.Count - 1 ? Environment.NewLine : */",");
                }
            }

            return result.ToString();
        }

        public static string ToCsvHeader(this DataTable dataTable)
        {
            var result = new StringBuilder();

            for (var i = 0; i < dataTable.Columns.Count; i++)
            {
                result.Append(dataTable.Columns[i].ColumnName);
                result.Append(/*i == dataTable.Columns.Count - 1 ? Environment.NewLine : */",");
            }

            return result.ToString();
        }
        
        public static string ToCsv(this DataTable dataTable)
        {
            return dataTable.ToCsvHeader() + dataTable.ToCsvBase();
        }
        
        public static IEnumerable<T> ExtractEntitiesFromCsv<T>(this string[] data)
            where T : class, new()
        {
            var properties = TypeDescriptor.GetProperties(typeof(T));

            for (var i = 0; i < data.Length / properties.Count; i++)
            {
                //Ignores header
                if (i == 0)
                    continue;

                T entity = new T();
                var x = 0;

                foreach (var propInfo in typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public))
                {
                    switch (Type.GetTypeCode(propInfo.PropertyType))
                    {
                        case TypeCode.Int32:
                        case TypeCode.Int64:
                            propInfo.SetValue(entity, int.Parse(data[properties.Count * i + x]), null);
                            break;
                        case TypeCode.String:
                            propInfo.SetValue(entity, data[properties.Count * i + x], null);
                            break;
                        case TypeCode.DateTime:
                            propInfo.SetValue(entity, DateTime.Parse(data[properties.Count * i + x]), null);
                            break;
                        default:
                            propInfo.SetValue(entity, null, null);
                            break;
                    }

                    x++;
                }

                yield return entity;
            }
        }
    }
}
