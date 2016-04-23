using Findler.Net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class RegistroPage : Page
    {
        HttpConnection con;
        string url;

        public RegistroPage()
        {
            this.InitializeComponent();
            con = new HttpConnection();
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            SystemNavigationManager.GetForCurrentView().BackRequested += Main_BackRequested;
        }

        private void Main_BackRequested(object sender, BackRequestedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            if (rootFrame.CanGoBack && e.Handled == false)
            {
                e.Handled = true; rootFrame.GoBack();
            }
        }

        private void clickRegistrar(object sender, RoutedEventArgs e)
        {
            string correo = email.Text;
            string password = pass.Password;
            registrar(correo, password);
        }

        public async void registrar(string email, string pass)
        {
            url = "http://localhost/laravel/findler/public/register/" + email + "/" + pass;
            string rta = await con.requestByGet(url);
            if (rta == "200")
            {
                Frame rootFrame = Window.Current.Content as Frame;
                rootFrame.Navigate(typeof(LoginPage));
            }
            else
            {
                msj.Text = "Datos incorrectos.";
            }
        }
    }
}
