using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WASA.Models
{
    internal class DefectModel : INotifyPropertyChanged
    {
        public string Time { get; set; } = DateTime.Now.ToString("dd.MM HH:mm");

        private string _article;
        private string _name;
        private string _reason;

        public string Article
        {
            get
            {
                return _article;
            }
            set
            {
                _article = value;
                OnPropertyChanged("Article");
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            { 
                _name = value; 
                OnPropertyChanged("Name");
            }
        }

        public string Reason
        {
            get
            {
                return _reason;
            }
            set
            {
                _reason = value;
                OnPropertyChanged("Reason");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
