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
    internal class FileIOServiceWH_BatteryEdit
    {
        private readonly string PATH;

        public FileIOServiceWH_BatteryEdit(string path)
        {
            PATH = path;
        }

        public BindingList<WareHouseModel> LoadDataWH_Battery()
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

        public void SaveDataWH_Battery(object wh_battery_model)
        {
            using (StreamWriter writer = File.CreateText(PATH))
            {
                string output = JsonConvert.SerializeObject(wh_battery_model);
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
                        first.Model = second.Model;
                        first.Manufacturer = second.Manufacturer;
                        first.Type = second.Type;
                        first.Retail = second.Retail;
                        first.Count = second.Count;
                        first.Connect_In = second.Connect_In;
                        first.Connect_Out = second.Connect_Out;
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
                        first.Model = second.Model;
                        first.Manufacturer = second.Manufacturer;
                        first.Type = second.Type;
                        first.Retail = second.Retail;
                        first.Count = second.Count;
                        first.Connect_In = second.Connect_In;
                        first.Connect_Out = second.Connect_Out;
                        first.Color = second.Color;
                    }
                }
            }
        }
    }
}
