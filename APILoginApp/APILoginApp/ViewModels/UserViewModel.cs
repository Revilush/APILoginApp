using APILoginApp.Models;
using APILoginApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace APILoginApp.ViewModels
{
    class UserViewModel : ViewModelBase
    {
        private UserInfo _User;
        private ObservableCollection<UserInfo> _Users;
        private UserServices userService;
        private bool _IsAddEnabled;

        public UserViewModel()
        {
            #region Instantiate public properties and service objects
            User = new UserInfo();
            Users = new ObservableCollection<UserInfo>();
            userService = new UserServices();
            _IsAddEnabled = false;
            #endregion

            #region Configure Command Properties by passing private method references to it
            //GetProductsCommand = new Command(GetData);
            AddUserCommand = new Command(AddUser);
            NavigateCommand = new Command(Navigate);
            PassControlCommand = new Command(PassControl);
            #endregion
        }

        #region Command Properties
        public ICommand GetProductsCommand { get; private set; }
        public ICommand AddUserCommand { get; private set; }
        public ICommand NavigateCommand { get; private set; }
        public ICommand PassControlCommand { get; private set; }
        #endregion


        #region Public Propertie for Private declarations 
        public UserInfo User
        {
            get
            {
                return _User;
            }
            set
            {
                _User = value;
                OnProprtyChanged("User");
            }
        }

        public ObservableCollection<UserInfo> Users
        {
            get
            {
                return _Users;
            }
            set
            {
                _Users = value;
                OnProprtyChanged("Users");
            }
        }

        public bool IsAddEnabled
        {
            get
            {
                return _IsAddEnabled;
            }
            set
            {
                _IsAddEnabled = value;
                OnProprtyChanged("IsAddEnabled");
            }
        }
        #endregion


        //#region Private one-way methods. These method will call to Services for Read/Write operations
        //private async void GetData()
        //{
        //    // clear the Products collection
        //    Users.Clear();
        //    var productsResponse = await userService.GetProductInfoDataAsync();
        //    foreach (UserInfo usr in productsResponse)
        //    {
        //        _Users.Add(usr); // call CollectionChanged and then PropertyChanged on ObservableCollection
        //    }
        //    if (_Users.Count >= 0)
        //    {
        //        IsAddEnabled = true;
        //    }
        //}

        private async void AddUser()
        {
            User = await userService.PostProductInfoAsync(User);
            if (User.UserId > 0)
            {
                // navigate to the Product List View
                await App.Current.MainPage.Navigation.PopModalAsync();
            }
        }

        private async void Navigate()
        {
            // naigate to Add Product Page
            // App.Current.MainPage, the current page object
            await App.Current.MainPage.Navigation.PushModalAsync(new Views.AddProduct());
        }


        private async void PassControl()
        {
            // naigate to Add Product Page
            // App.Current.MainPage, the current page object
            await App.Current.MainPage.Navigation.PushModalAsync(new Views.Register());
        }




    }
}
