using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ModelRecords
    {
        public const string FILE_PATH = "records.txt";

        /// <summary>
        /// Список рекордов игры
        /// </summary>
        public List<Record> ListRecords;

        /// <summary>
        /// Загрузить рекорды игры из файла
        /// </summary>
        public ModelRecords()
        {
            ListRecords = new List<Record>();
            if (File.Exists(FILE_PATH))
            {
                string[] records = File.ReadAllLines(FILE_PATH);
                foreach (string record in records)
                {
                    string[] values = record.Split(' ');
                    if (values.Length == 2)
                    {
                        ListRecords.Add(new Record(values[0], Int32.Parse(values[1])));
                    }
                }
            }
            else
            {
                File.Create(FILE_PATH).Close();
            }
        }

        /// <summary>
        /// Записать рекорды игры в файл
        /// </summary>
        public void WriteToFile()
        {
            FileStream fileStream = File.OpenWrite(FILE_PATH);
            ListRecords.Sort(new Comparison<Record>((a, b) => { return b.Score - a.Score; }));
            for (int i = 0; i < ListRecords.Count && i < 10; i++)
            {
                string s = string.Format("{0} {1}\r\n", ListRecords[i].Name, ListRecords[i].Score.ToString());
                byte[] bytes = Encoding.UTF8.GetBytes(s);
                fileStream.Write(bytes, 0, bytes.Length);
            }
            fileStream.Flush();
            fileStream.Close();
        }
    }
}
