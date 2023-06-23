using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WASA.Models
{
    internal class NewSellModel : INotifyPropertyChanged
    {
        public string Time { get; set; } = DateTime.Now.ToString("HH:mm");

        private bool _cash;
        private bool _acquiring;
        private string _position;
        private int _price;
        private int _discount;        

        public bool Cash
        {
            get
            {
                return _cash;
            }
            set
            {
                _cash = value;
                OnPropertyChanged("Cash");
            }

        }

        public bool Acquiring
        {
            get
            {
                return _acquiring;
            }
            set
            {
                _acquiring = value;
                OnPropertyChanged("Acquiring");
            }
        }

        public string Position
        {
            get
            {
                return _position;
            }
            set
            {
                _position = value;
                OnPropertyChanged("Position");
            }
        }
        public int Price
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
                OnPropertyChanged("Price");
            }
        }

        public int Discount
        {
            get
            {
                return _discount;
            }
            set
            {
                _discount = value;
                OnPropertyChanged("Discount");
            }
        }

        
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}

