using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;

namespace Foosball.Extensions
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
                    result.Append("'" + row[i]);
                    result.Append(i == dataTable.Columns.Count - 1 ? Environment.NewLine : ",");
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
                result.Append(i == dataTable.Columns.Count - 1 ? Environment.NewLine : ",");
            }

            return result.ToString();
        }
        
        public static string ToCsv(this DataTable dataTable)
        {
            return dataTable.ToCsvHeader() + dataTable.ToCsvBase();
        }
    }
}
