using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WASA.Models;

namespace WASA.Services
{
    internal class FIleIOServiceWH_AudioEdit
    {
        private readonly string PATH;

        public FIleIOServiceWH_AudioEdit(string path)
        {
            PATH = path;
        }

        public BindingList<WareHouseModel> LoadDataWH_Audio()
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

        public void SaveDataWH_Audio(object wh_audio_model)
        {
            using (StreamWriter writer = File.CreateText(PATH))
            {
                string output = JsonConvert.SerializeObject(wh_audio_model);
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
                        first.Type = second.Type;
                        first.Manufacturer = second.Manufacturer;
                        first.Series = second.Series;
                        first.Connection = second.Connection;
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
                        first.Type = second.Type;
                        first.Manufacturer = second.Manufacturer;
                        first.Series = second.Series;
                        first.Connection = second.Connection;
                        first.Retail = second.Retail;
                        first.Count = second.Count;
                        first.Color = second.Color;
                    }
                }
            }
        }
    }
}
