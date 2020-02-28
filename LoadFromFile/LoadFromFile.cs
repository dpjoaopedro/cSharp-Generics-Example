using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LoadFromFile
{
    class LoadObjectFromFile<T> where T: class, new()
    {
        public List<T> LoadToList(string path)
        {
            var lines = File.ReadAllLines(path).ToList();
            List<T> output = new List<T>();
            T entry = new T();
            var cols = entry.GetType().GetProperties();

            // Verify if the file has at least the header and one registry
            if (lines.Count < 2) throw new IndexOutOfRangeException("The file was either empity or missing.");

            // Split the header into one column header per entry
            var headers = lines[0].Split(';');

            // Removes the header so whe have only the data
            lines.RemoveAt(0);

            foreach (var row in lines)
            {
                entry = new T();

                // Split the row into individual column.
                var vals =  row.Split(';');

                for (int i = 0; i < headers.Length; i++)
                {
                    foreach (var col in cols)
                    {
                        if(col.Name == headers[i])
                        {
                            col.SetValue(entry, Convert.ChangeType(vals[i], col.PropertyType));
                        }
                    }
                }

                output.Add(entry);
            }

            return output;
        }  
    }

}
