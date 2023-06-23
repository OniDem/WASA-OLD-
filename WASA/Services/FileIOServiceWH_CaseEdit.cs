using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WASA.Models;

namespace WASA.Services
{
    internal class FileIOServiceWH_CaseEdit
    {
        private readonly string PATH;

        public FileIOServiceWH_CaseEdit(string path)
        {
            PATH = path;
        }

        public BindingList<WareHouseModel> LoadDataWH_Case()
        {
            var fileExists = File.Exists(PATH);
            if (!fileExists)
            {
                File.CreateText(PATH).Dispose();
                File.AppendAllText(PATH, "[]");
                return new BindingList<WareHouseModel>();
            }
            using (var reader = File.OpenText(PATH))
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList<WareHouseModel>>(fileText);
            }
        }

        public void SaveDataWH_Case(object wh_case_model)
        {
            using (StreamWriter writer = File.CreateText(PATH))
            {
                string output = JsonConvert.SerializeObject(wh_case_model);
                writer.WriteLine(output);
            }
        }
        public void Search(BindingList<WareHouseModel> firsts, BindingList<WareHouseModel> seconds)
        {
            foreach (var second in seconds)
            {
                foreach (var first in firsts)
                {
                    if (second.Vendor_Code == first.Vendor_Code)
                    {
                        first.Vendor_Code = second.Vendor_Code;
                        first.Series = second.Series;
                        first.Manufacturer = second.Manufacturer;
                        first.Model = second.Model;
                        first.Retail = second.Retail;
                        first.Count = second.Count;
                        first.Color = second.Color;
                    }
                }
            }
        }
        public void Edit(BindingList<WareHouseModel> firsts, BindingList<WareHouseModel> seconds)
        {
            foreach (var second in seconds)
            {
                foreach (var first in firsts)
                {
                    if (second.Vendor_Code == first.Vendor_Code)
                    {
                        first.Vendor_Code = second.Vendor_Code;
                        first.Series = second.Series;
                        first.Manufacturer = second.Manufacturer;
                        first.Model = second.Model;
                        first.Retail = second.Retail;
                        first.Count = second.Count;
                        first.Color = second.Color;
                    }
                }
            }
        }
    }
}
