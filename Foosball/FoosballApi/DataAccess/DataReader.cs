using System.Data.Entity;
using System.IO;
using Foosball.Extensions;

namespace Foosball.DataAccess
{
    public class DataReader
    {
        public static void ReadFromCsv<T>(DbSet<T> dbSet)
            where T : class, new()
        {
            var path = $"../../FileDatabase/{typeof(T)}.txt";

            if (File.Exists(path))
            {
                string[] arr = File.ReadAllText(path).Split(','); 

                foreach(var entity in arr.ExtractEntitiesFromCsv<T>())
                {
                    dbSet.Add(entity);
                }
            }
        }
    }
}
