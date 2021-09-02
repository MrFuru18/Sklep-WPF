using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Sklep_WPF.ViewModel;
using Sklep_WPF.Navigation;
using Sklep_WPF.CurrentSession;

namespace Sklep_WPF
{
    /// <summary>
    /// Logika interakcji dla klasy App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            AccountStore accountStore = new AccountStore();
            CartProductStore productStore = new CartProductStore();
            Navigate navigate = new Navigate();

            navigate.CurrentPage = new LoginViewModel(accountStore, navigate);

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(accountStore, productStore, navigate)
            };

            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}
