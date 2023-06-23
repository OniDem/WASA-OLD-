using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WASA.Models;

namespace WASA.Services
{
    internal class FileIOServiceDefect
    {
        private readonly string PATH;

        public FileIOServiceDefect(string path)
        {
            PATH = path;
        }

        public BindingList<DefectModel> LoadDataDefect()
        {
            var fileExists = File.Exists(PATH);
            if (!fileExists)
            {
                File.CreateText(PATH).Dispose();
                File.AppendAllText(PATH, "[]");
                return new BindingList<DefectModel>();
            }
            using (var reader = File.OpenText(PATH)) 
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList<DefectModel>>(fileText);
            }
        }

        public void SaveDataDefect(object defectmodel)
        {
            using (StreamWriter writer = File.CreateText(PATH))
            {
                string output = JsonConvert.SerializeObject(defectmodel);
                writer.WriteLine(output);
            }
        }

        public void DeleteDataDefect()
        {
            File.Delete(PATH);
        }
    }
}
