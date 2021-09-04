﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.ComponentModel;
using Sklep_WPF.DAL.Repozytoria;

namespace Sklep_WPF.ViewModel
{
    using BaseClass;
    using Sklep_WPF.CurrentSession;
    using Sklep_WPF.Model;
    using Sklep_WPF.Navigation;
    using System.ComponentModel;

    class CheckoutViewModel : ViewModelBase
    {
        private readonly AccountStore _accountStore;
        private readonly CartProductStore _productStore;
        private readonly Navigate _navigate;

        public List<Address> addresses { get; set; }

        public CheckoutViewModel(AccountStore accountStore, CartProductStore productStore, Navigate navigate)
        {
            _accountStore = accountStore;
            _productStore = productStore;
            _navigate = navigate;

            Price = _productStore.ShowPrice();

            Name = _accountStore.CurrentAccount?.imie;
            Surname = _accountStore.CurrentAccount?.nazwisko;
            PhoneNumber = _accountStore?.CurrentAccount?.nr_tel;

            addresses = AddressRepo.getAllAddresses().Result;
        }

        public string Price { get; set; }


        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                onPropertyChanged(nameof(Name));
            }
        }

        private string _surname;
        public string Surname
        {
            get { return _surname; }
            set
            {
                _surname = value;
                onPropertyChanged(nameof(Surname));
            }
        }

        private string _phoneNumber;
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                _phoneNumber = value;
                onPropertyChanged(nameof(PhoneNumber));
            }
        }

        private string _street;
        public string Street
        {
            get { return _street; }
            set
            {
                _street = value;
                onPropertyChanged(nameof(Street));
            }
        }

        private string _number;
        public string Number
        {
            get { return _number; }
            set
            {
                _number = value;
                onPropertyChanged(nameof(Number));
            }
        }

        private string _apartmentNumber;
        public string ApartmentNumber
        {
            get { return _apartmentNumber; }
            set
            {
                _apartmentNumber = value;
                onPropertyChanged(nameof(ApartmentNumber));
            }
        }

        private string _postalCode;
        public string PostalCode
        {
            get { return _postalCode; }
            set
            {
                _postalCode = value;
                onPropertyChanged(nameof(PostalCode));
            }
        }

        private string _city;
        public string City
        {
            get { return _city; }
            set
            {
                _city = value;
                onPropertyChanged(nameof(City));
            }
        }

        private ICommand _chooseAddress;
        public ICommand ChooseAddress
        {
            get
            {
                return _chooseAddress ?? (_chooseAddress = new RelayCommand((p) =>
                {
                    Address selectedAddress = new Address();
                    selectedAddress = (Address)p;
                    Street = selectedAddress.ulica;
                    Number = selectedAddress.nr.ToString();
                    ApartmentNumber = selectedAddress.nr_mieszkania.ToString();
                    PostalCode = selectedAddress.kod_pocztowy;
                    City = selectedAddress.miejscowosc;

                }, p => true));
            }
        }

        private ICommand _placeOrder;
        public ICommand PlaceOrder
        {
            get
            {
                return _placeOrder ?? (_placeOrder = new RelayCommand((p) =>
                {
                    if (string.IsNullOrWhiteSpace(Name)|| string.IsNullOrWhiteSpace(Surname) || string.IsNullOrWhiteSpace(Street) || string.IsNullOrWhiteSpace(Number) || string.IsNullOrWhiteSpace(ApartmentNumber) || string.IsNullOrWhiteSpace(PostalCode) || string.IsNullOrWhiteSpace(City) || string.IsNullOrWhiteSpace(PhoneNumber))
                        MessageBox.Show("Pola nie mogą być puste");
                    else
                    {
                        _productStore.ClearCart();
                        _navigate.CurrentPage = new CartViewModel(_accountStore, _productStore, _navigate);

                        MessageBox.Show("Zamówienie złożono pomyślnie\n" + " " + Name + " " + Surname + " " + Street + " " + Number + " " + ApartmentNumber + " " + PostalCode + " " + City + " " + PhoneNumber);
                    }

                    /*
                     Do zaimplementowania
                     
                    Number i ApartmentNumber konwersja na long
                    Gdy nowy adres zostanie wpisany zostanie dodany do bazy zapamiętanych adresów 

                     */

                }, p => true));
            }
        }
    }
}
