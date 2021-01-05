using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace APILoginApp.Models
{
    public class UserInfo
    {
        public int _UserId;
        public string _UserName;
        public string _UserPassword ;


        public int UserId
        {
            get
            {
                return _UserId;
            }
            set
            {
                _UserId = value;
                OnPropertyChanged("UserId");
            }
        }

        
        public string UserName
        {
            get
            {
                return _UserName;
            }
            set
            {
                _UserName = value;
                OnPropertyChanged("UserName");
            }
        }
        
        public string UserPassword
        {
            get
            {
                return _UserPassword;
            }
            set
            {
                _UserPassword = value;
                OnPropertyChanged("UserPassword");
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
