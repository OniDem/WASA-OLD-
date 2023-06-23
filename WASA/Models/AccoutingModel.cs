using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WASA.Models
{
    internal class AccoutingModel 
    {
        private int _payments;
        private int _all_Accouting;
        private int _cash_Accouting;
        private int _acq_Accountin;
        private int _pay;

        public int Payments
        {
            get
            {
                return _payments;
            }
            set
            {
                _payments = value;
            }
        }
        public int All_Accouting
        {
            get 
            {
                return _all_Accouting;
            }
            set 
            {
                _all_Accouting = value;
            }
        }

        public int Cash_Accouting
        {
            get
            {
                return _cash_Accouting;
            }
            set 
            {
                _cash_Accouting = value;
            }
        }

        public int Acquiring_Accouting
        {
            get
            {
                return _acq_Accountin;
            }
            set 
            {
                _acq_Accountin = value;
            }
        }

        public int Pay
        {
            get
            {
                return _pay;
            }
            set
            {
                _pay = value;
            }
        }
    }
}
