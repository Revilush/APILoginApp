using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace APILoginApp.Models
{
    public class ProductInfo : INotifyPropertyChanged
    {
        private int _ProductRowId;
        private string _ProductId;
        private string _ProductName;
        private string _CategoryName;
        private string _Manufacturer;
        private string _Description;
        private int _BasePrice;
        private int _Uid;

        public int ProductRowId
        {
            get
            {
                return _ProductRowId;
            }
            set
            {
                _ProductRowId = value;
                OnPropertyChanged("ProductRowId");
            }
        }


        public string ProductId
        {
            get
            {
                return _ProductId;
            }
            set
            {
                _ProductId = value;
                OnPropertyChanged("ProductId");
            }
        }

        public string ProductName
        {
            get
            {
                return _ProductName;
            }
            set
            {
                _ProductName = value;
                OnPropertyChanged("ProductName");
            }
        }
        
        public string CategoryName
        {
            get
            {
                return _CategoryName;
            }
            set
            {
                _CategoryName = value;
                OnPropertyChanged("CategoryName");
            }
        }

        public string Manufacturer
        {
            get
            {
                return _Manufacturer;
            }
            set
            {
                _Manufacturer = value;
                OnPropertyChanged("Manufacturer");
            }
        }
        
        public string Description
        {
            get
            {
                return _Description;
            }
            set
            {
                _Description = value;
                OnPropertyChanged("Description");
            }
        }


        public int BasePrice
        {
            get
            {
                return _BasePrice;
            }
            set
            {
                _BasePrice = value;
                OnPropertyChanged("BasePrice");
            }
        }

        public int Uid
        {
            get
            {
                return _Uid;
            }
            set
            {
                _Uid = value;
                OnPropertyChanged("Uid");
            }
        }




        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string pName)
        {
            if (PropertyChanged != null)
                // the current object will raise the event and 
                // pass the property name that is updated / changed
                PropertyChanged(this, new PropertyChangedEventArgs(pName));
        }
    

    }
}
  