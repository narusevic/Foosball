using System;
using System.Data.Entity;
using System.IO;
using FoosballApi.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace FoosballApi.DataAccess
{
    public class DataWriter
    {
        public static void WriteFileCsv<T>(DbSet<T> dbContext)
            where T : class
        {
            var dataTable = dbContext.ToDataTable();
            var path = $"../../FileDatabase/{typeof(T)}.txt";

            if (!File.Exists(path))
            {
                using (StreamWriter streamWriter = File.CreateText(path))
                {
                    streamWriter.Write(dataTable.ToCsv());
                }
            }
            else
            {
                using (StreamReader streamReader = File.OpenText(path))
                {
                    while (streamReader.ReadLine() != null){}
                }

                using (StreamWriter streamWriter = File.CreateText(path))
                {
                    streamWriter.Write(dataTable.ToCsvBase());
                }
            }
        }
    }
}
