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
    internal class FileIOServiceWH_CarHolderEdit
    {
        private readonly string PATH;

        public FileIOServiceWH_CarHolderEdit(string path)
        {
            PATH = path;
        }

        public BindingList<WareHouseModel> LoadDataWH_Accesories()
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

        public void SaveDataWH_WH_CarHolderModel(object wh_carholder_model)
        {
            using (StreamWriter writer = File.CreateText(PATH))
            {
                string output = JsonConvert.SerializeObject(wh_carholder_model);
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
                        first.Surface_Connect = second.Surface_Connect;
                        first.Phone_Connect = second.Phone_Connect;
                        first.Series = second.Series;
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
                        first.Surface_Connect = second.Surface_Connect;
                        first.Phone_Connect = second.Phone_Connect;
                        first.Series = second.Series;
                        first.Retail = second.Retail;
                        first.Count = second.Count;
                        first.Color = second.Color;
                    }
                }
            }
        }
    }
}
