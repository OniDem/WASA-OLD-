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
    internal class FileIOServiceWH_ChargeEdit
    {
        private readonly string PATH;

        public FileIOServiceWH_ChargeEdit(string path)
        {
            PATH = path;
        }

        public BindingList<WareHouseModel> LoadDataWH_ChargeEdit()
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

        public void SaveDataWH_ChargeEdit(object wh_charge_model)
        {
            using (StreamWriter writer = File.CreateText(PATH))
            {
                string output = JsonConvert.SerializeObject(wh_charge_model);
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
                        first.Type = second.Type;
                        first.Manufacturer = second.Manufacturer;
                        first.Cable = second.Cable;
                        first.Retail = second.Retail;
                        first.Count = second.Count;
                        first.USB_Count = second.USB_Count;
                        first.Type_C_Count = second.Type_C_Count;
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
                        first.Type = second.Type;
                        first.Manufacturer = second.Manufacturer;
                        first.Cable = second.Cable;
                        first.Retail = second.Retail;
                        first.Count = second.Count;
                        first.USB_Count = second.USB_Count;
                        first.Type_C_Count = second.Type_C_Count;
                        first.Color = second.Color;
                    }
                }
            }
        }
    }
}
