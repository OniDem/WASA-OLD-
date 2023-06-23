﻿using Newtonsoft.Json;
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
    internal class FileIOServiceWH_HeadphonesEdit
    {
        private readonly string PATH;

        public FileIOServiceWH_HeadphonesEdit(string path)
        {
            PATH = path;
        }

        public BindingList<WareHouseModel> LoadDataWH_HeadphonesEdit()
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

        public void SaveDataWH_HeadphonesEdit(object wh_headphones_model)
        {
            using (StreamWriter writer = File.CreateText(PATH))
            {
                string output = JsonConvert.SerializeObject(wh_headphones_model);
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
                        first.Series = second.Series;
                        first.Manufacturer = second.Manufacturer;
                        first.Model = second.Model;
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
