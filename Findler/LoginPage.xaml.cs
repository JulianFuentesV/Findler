using Findler.Net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Findler
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginPage : Page
    {
        ApplicationDataContainer ingreso = ApplicationData.Current.LocalSettings;
        HttpConnection con;
        string url;

        public LoginPage()
        {
            this.InitializeComponent();
            con = new HttpConnection();
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
            ingreso.Values["logged"] = "no";
            ingreso.Values["user"] = "no";
        }

        private void clickIngresar(object sender, RoutedEventArgs e)
        {
            string correo = email.Text;
            string pass = password.Password;
            validarLogin(correo, pass);
        }

        private void clickRegistro(object sender, RoutedEventArgs e)
        {
            progress.IsActive = true;
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(RegistroPage));
        }

        public async void validarLogin(string correo, string pass)
        {
            url = "http://localhost/laravel/findler/public/users/"+correo+"/"+pass;
            string rta = await con.requestByGet(url);
            if (rta == "200")
            {
                progress.IsActive = true;
                bool check = (bool)recordar.IsChecked;
                if (check)
                {
                    ingreso.Values["logged"] = "ok";
                }
                ingreso.Values["user"] = correo;
                Frame rootFrame = Window.Current.Content as Frame;
                rootFrame.Navigate(typeof(MainPage));
            }
            else
            {
                msj.Text = "Datos incorrectos.";
            }
        }
    }
}
