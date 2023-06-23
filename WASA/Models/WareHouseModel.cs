using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WASA.Models
{
    internal class WareHouseModel : INotifyPropertyChanged
    {
        private string _vendor_Code;
        private string _series;
        private string _manufacturer;
        private string _model;
        private int _retail;
        private int _count;
        private string _color;
        private string _singularity;
        private string _lenght;
        private string _type;
        private string _cable;
        private int _usb_count;
        private int _type_c_count;
        private string _surface_Connect;
        private string _phone_Connect;
        private string _connection;
        private string _connect_in;
        private string _connect_out;

        public string Vendor_Code
        {
            get
            {
                return _vendor_Code;
            }
            set
            {
                _vendor_Code = value;
                OnPropertyChanged("Vendor_Code");
            }

        }

        public string Series
        {
            get
            {
                return _series;
            }
            set
            {
                _series = value;
                OnPropertyChanged("Series");
            }
        }

        public string Manufacturer
        {
            get
            {
                return _manufacturer;
            }
            set
            {
                _manufacturer = value;
                OnPropertyChanged("Manufacturer");
            }
        }
        public int Retail
        {
            get
            {
                return _retail;
            }
            set
            {
                _retail = value;
                OnPropertyChanged("Retail");
            }
        }

        public string Model
        {
            get
            {
                return _model;
            }
            set
            {
                _model = value;
                OnPropertyChanged("Model");
            }
        }

        public int Count
        {
            get
            {
                return _count;
            }
            set
            {
                _count = value;
                OnPropertyChanged("Count");
            }
        }

        public string Color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
                OnPropertyChanged("Color");
            }
        }

        public string Singularity
        {
            get
            {
                return _singularity;
            }
            set
            {
                _singularity = value;
                OnPropertyChanged("Singularity");
            }
        }

        public string Lenght
        {
            get
            {
                return _lenght;
            }
            set
            {
                _lenght = value;
                OnPropertyChanged("Lenght");
            }
        }

        public string Type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
                OnPropertyChanged("Type");
            }
        }

        public string Cable
        {
            get
            {
                return _cable;
            }
            set
            {
                _cable = value;
                OnPropertyChanged("Cable");
            }
        }

        public int USB_Count
        {
            get
            {
                return _usb_count;
            }
            set
            {
                _usb_count = value;
                OnPropertyChanged("USB_Count");
            }
        }

        public int Type_C_Count
        {
            get
            {
                return _type_c_count;
            }
            set
            {
                _type_c_count = value;
                OnPropertyChanged("Type_C_Count");

            }
        }

        public string Surface_Connect
        {
            get
            {
                return _surface_Connect;
            }
            set
            {
                _surface_Connect = value;
                OnPropertyChanged("Surface_Connect");
            }
        }

        public string Phone_Connect
        {
            get
            {
                return _phone_Connect;
            }
            set
            {
                _phone_Connect = value;
                OnPropertyChanged("Phone_Connect");
            }
        }

        public string Connection
        {
            get
            {
                return _connection;
            }
            set
            {
                _connection = value;
                OnPropertyChanged("Connection");
            }
        }

        public string Connect_In
        {
            get
            {
                return _connect_in;
            }
            set
            {
                _connect_in = value;
                OnPropertyChanged("Connect_In");
            }
        }

        public string Connect_Out
        {
            get
            {
                return _connect_out;
            }
            set
            {
                _connect_out = value;
                OnPropertyChanged("Connect_Out");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
