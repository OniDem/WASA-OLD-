using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Shapes;
using WASA.Models;

namespace WASA
{
    class GlobalData
    {
        private readonly string _date = DateTime.Now.ToString("dd.MM.yyyy");
        public string Date
        {
            get 
            {
                return _date; 
            }
        }

        private readonly string _day_of_week = DateTime.Now.ToString("dddd");
        public string Day_Of_Week
        {
            get
            {
                return _day_of_week;
            }
        }

        private readonly string _day_of_year = DateTime.Now.DayOfYear.ToString();
        public string Day_Of_Year
        {
            get
            {
                return _day_of_year;
            }
        }

        private readonly string _datapath = "C:\\WASA\\Data\\WareHouse\\";
        public string GetDataPath(string path)
        {
            path = _datapath + path;
            return path;
        }

        private readonly string _temp_datapath = "C:\\WASA\\Data\\WareHouse\\Temp_Data.json";
        public string GetTempDataPath
        {
            get 
            {
                return _temp_datapath; 
            }

        }

        private readonly string _otherpath = "C:\\WASA\\Data\\";
        public string GetPath(string path)
        {
            path = _otherpath + path;
            return path;
        }

        

    }
}
