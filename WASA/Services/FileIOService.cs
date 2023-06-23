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
    internal class FileIOService
    {
        GlobalData GlobalData = new GlobalData();
        
        /// <summary>
        /// Для работы с Search при ObservableCollection
        /// </summary>
        /// <param name="TempData">BindingList</param>
        /// <param name="GridData">ObservableCollection</param>
        public void Search(BindingList<WareHouseModel> firsts, ObservableCollection<WareHouseModel> seconds)
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
                        first.Singularity = second.Singularity;
                        first.Lenght = second.Lenght;
                        first.Type = second.Type;
                        first.Cable = second.Cable;
                        first.USB_Count = second.USB_Count;
                        first.Type_C_Count = second.Type_C_Count;
                        first.Surface_Connect = second.Surface_Connect;
                        first.Phone_Connect = second.Phone_Connect;
                        first.Connection = second.Connection;
                        first.Connect_In = second.Connect_In;
                        first.Connect_Out = second.Connect_Out;

                    }
                }
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
                        first.Singularity = second.Singularity;
                        first.Lenght = second.Lenght;
                        first.Type = second.Type;
                        first.Cable = second.Cable;
                        first.USB_Count = second.USB_Count;
                        first.Type_C_Count = second.Type_C_Count;
                        first.Surface_Connect = second.Surface_Connect;
                        first.Phone_Connect = second.Phone_Connect;
                        first.Connection = second.Connection;
                        first.Connect_In = second.Connect_In;
                        first.Connect_Out = second.Connect_Out;
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
                        first.Singularity = second.Singularity;
                        first.Lenght = second.Lenght;
                        first.Type = second.Type;
                        first.Cable = second.Cable;
                        first.USB_Count = second.USB_Count;
                        first.Type_C_Count = second.Type_C_Count;
                        first.Surface_Connect = second.Surface_Connect;
                        first.Phone_Connect = second.Phone_Connect;
                        first.Connection = second.Connection;
                        first.Connect_In = second.Connect_In;
                        first.Connect_Out = second.Connect_Out;
                    }
                }
            }
        }

        public BindingList<WareHouseModel> LoadTempData()
        {
            var fileExists = File.Exists(GlobalData.GetTempDataPath);
            if (!fileExists)
            {
                File.CreateText(GlobalData.GetTempDataPath).Dispose();
                File.AppendAllText(GlobalData.GetTempDataPath, "[]");
                return new BindingList<WareHouseModel>();
            }
            using (var reader = File.OpenText(GlobalData.GetTempDataPath))
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList<WareHouseModel>>(fileText);
            }
        }

        public ObservableCollection<WareHouseModel> LoadObservableData(string PATH)
        {
            var fileExists = File.Exists(PATH);
            if (!fileExists)
            {
                File.CreateText(PATH).Dispose();
                File.AppendAllText(PATH, "[]");
                return new ObservableCollection<WareHouseModel>();
            }
            using (var reader = File.OpenText(PATH))
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<ObservableCollection<WareHouseModel>>(fileText);
            }
        }

        public BindingList<WareHouseModel> LoadBindingData(string PATH)
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

        public void SaveBindingData(object warehouse_model, string PATH)
        {
            using (StreamWriter writer = File.CreateText(PATH))
            {
                string output = JsonConvert.SerializeObject(warehouse_model);
                writer.WriteLine(output);
            }
        }
    }
}
