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
    internal class FileIOServiceWH_AdapterEdit
    {
        private readonly string PATH;

        public FileIOServiceWH_AdapterEdit(string path)
        {
            PATH = path;
        }

        public BindingList<WareHouseModel> LoadDataWH_Adapter()
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

        public void SaveDataWH_Adapter(object wh_adapter_model)
        {
            using (StreamWriter writer = File.CreateText(PATH))
            {
                string output = JsonConvert.SerializeObject(wh_adapter_model);
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
                        first.Manufacturer = second.Manufacturer;
                        first.Model = second.Model;
                        first.Connection = second.Connection;
                        first.Retail = second.Retail;
                        first.Count = second.Count;
                        first.Color = second.Color;
                        first.Lenght = second.Lenght;
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
                        first.Manufacturer = second.Manufacturer;
                        first.Model = second.Model;
                        first.Connection = second.Connection;
                        first.Retail = second.Retail;
                        first.Count = second.Count;
                        first.Color = second.Color;
                        first.Lenght = second.Lenght;
                    }
                }
            }
        }
    }
}
