using Findler.Models;
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
    public sealed partial class ContentPage : Page
    {
        HttpConnection con;

        public ContentPage()
        {
            this.InitializeComponent();
            con = new HttpConnection();
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            SystemNavigationManager.GetForCurrentView().BackRequested += Main_BackRequested;
        }

        private void Main_BackRequested(object sender, BackRequestedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            if (rootFrame.CanGoBack && e.Handled == false) { e.Handled = true; rootFrame.GoBack();
            }
        }

        public Curso curso { get; set; }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Curso c = e.Parameter as Curso;
            curso = c;

        }

        private async void addFav(object sender, RoutedEventArgs e)
        {
            ApplicationDataContainer ingreso = ApplicationData.Current.LocalSettings;
            string correo = ingreso.Values["user"] as string;
            string nombreCurso = curso.Nombre;
            string url = "http://localhost/laravel/findler/public/favs/index/" + correo + "/" + nombreCurso;
            string idFav = await con.requestByGet(url);
            if (idFav == "null")
            {
                url = "http://localhost/laravel/findler/public/favs/store/" + correo + "/" + nombreCurso;
            } else
            {
                url = "http://localhost/laravel/findler/public/favs/delete/" + idFav;
            }
            
            string rta = await con.requestByGet(url);
            textRta.Text = rta;
        }
    }
}
