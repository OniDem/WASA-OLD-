using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using Newtonsoft.Json;
using WASA.Models;

namespace WASA.Services
{
    internal class FileIOServiceNewSell
    {
        private GlobalData globalSettings = new GlobalData();

        private int _all_accouting = 0;
        //private readonly string PATH;

        /*
        public FileIOServiceNewSell(string path)
        {
            PATH = path;
        }
        */
        public BindingList<NewSellModel> LoadDataSell()
        {
            string PATH = globalSettings.GetPath(globalSettings.Day_Of_Year + ".json");
            var fileExists = File.Exists(PATH);
            if (!fileExists)
            {
                File.CreateText(PATH).Dispose();
                File.AppendAllText(PATH, "[]");
                return new BindingList<NewSellModel>();
            }
            using (var reader = File.OpenText(PATH))
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList<NewSellModel>>(fileText);
            }
        }

        public BindingList<AccoutingModel> LoadDataAccouting()
        {
            string PATH = globalSettings.GetPath("Accouting.json");
            var fileExists = File.Exists(PATH);
            if (!fileExists)
            {
                File.CreateText(PATH).Dispose();
                File.AppendAllText(PATH, "[]");
                return new BindingList<AccoutingModel>();
            }
            using (var reader = File.OpenText(PATH))
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList<AccoutingModel>>(fileText);
            }
        }

        public BindingList<AccoutingModel> ReadFile()
        {
            string PATH = globalSettings.GetPath("Accouting.json");
            var fileExists = File.Exists(PATH);
            if (!fileExists)
            {
                string json = File.ReadAllText(PATH);
                File.AppendAllText(PATH, "[]");
                return JsonConvert.DeserializeObject<BindingList<AccoutingModel>>(json);
            }
            using (var reader = File.OpenText(PATH))
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList<AccoutingModel>>(fileText);
            }

        }

       
        public string All_Accouting(BindingList<NewSellModel> elements)
        {
            foreach (var element in elements)
            {
                if (element.Acquiring == true || element.Cash == true)
                {
                    _all_accouting += (element.Price - element.Discount);
                }
            }
            return Convert.ToString(_all_accouting);
        }

        public string Cash_Accouting(BindingList<NewSellModel> elements)
        {
           int  _cash_accouting = 0;

            foreach (var element in elements)
            {
                if (element.Cash == true)
                {
                    _cash_accouting += (element.Price - element.Discount);
                }
            }

            return Convert.ToString(_cash_accouting);
        }

        public string Acquiring_Accouting(BindingList<NewSellModel> elements)
        {
            int _acq_accouting = 0;
           
            foreach (var element in elements)
            {
                if (element.Acquiring == true)
                {
                    _acq_accouting += (element.Price - element.Discount);
                }
            }

            return Convert.ToString(_acq_accouting);
        }

        public string Payments()
        {
            int pay = 900;
            int _payments = 0;

            if (_all_accouting > pay)
            {
                _payments = pay + (_all_accouting - pay) / 100 * 10;
            }
            else
                _payments = pay;              
            
            return Convert.ToString(_payments);
        }

        public void SaveDataAccouting(object accoutingmodel)
        {
            string PATH = globalSettings.GetPath("Accouting.json");
            using (StreamWriter writer = File.CreateText(PATH))
            {
                string output = JsonConvert.SerializeObject(accoutingmodel);
                writer.WriteLine(output);
            }
        }

        public void SaveDataSell(object sellmodel)
        {
            string PATH = globalSettings.GetPath(globalSettings.Day_Of_Year + ".json");
            using (StreamWriter writer = File.CreateText(PATH))
            {
                string output = JsonConvert.SerializeObject(sellmodel);
                writer.WriteLine(output);
            }
        }
    }
}
