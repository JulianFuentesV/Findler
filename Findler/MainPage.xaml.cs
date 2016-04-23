using Findler.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Findler
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        string url;
        string title;
        string[] datos;

        public MainPage()
        {
            this.InitializeComponent();
            this.Loaded += MainPage_Loaded;
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            url = "http://localhost/laravel/findler/public/courses";
            title = "Novedades";
            datos = new string[3] { url, title, "no"};
            contenido.Navigate(typeof(NuevosPage), datos);
        }

        private ObservableCollection<MenuItem> menu;
        public ObservableCollection<MenuItem> Menu
        {
            get
            {
                if (menu == null)
                {
                    menu = new ObservableCollection<MenuItem>();
                    MenuItem opc1 = new MenuItem()
                    {
                        Icon = "Pictures",
                        Label = "Nuevos"
                    };
                    MenuItem opc2 = new MenuItem()
                    {
                        Icon = "Like",
                        Label = "Tendencias"
                    };
                    MenuItem opc3 = new MenuItem()
                    {
                        Icon = "Library",
                        Label = "Categorias"
                    };
                    MenuItem opc4 = new MenuItem()
                    {
                        Icon = "OutlineStar",
                        Label = "Mis cursos"
                    };
                    MenuItem opc5 = new MenuItem()
                    {
                        Icon = "Setting",
                        Label = "Configuracion"
                    };
                    MenuItem opc6 = new MenuItem()
                    {
                        Icon = "Link",
                        Label = "Quiero aparecer en findler"
                    };
                    MenuItem opc7 = new MenuItem()
                    {
                        Icon = "Cancel",
                        Label = "Cerrar Sesion"
                    };

                    menu.Add(opc1);
                    menu.Add(opc2);
                    menu.Add(opc3);
                    menu.Add(opc4);
                    menu.Add(opc5);
                    menu.Add(opc6);
                    menu.Add(opc7);

                }
                return menu;
            }
            set { menu = value; }
        }

        private void clickMenu(object sender, RoutedEventArgs e)
        {
            split.IsPaneOpen = !split.IsPaneOpen;
        }

        private void itemSelected(object sender, SelectionChangedEventArgs e)
        {
            switch (list.SelectedIndex)
            {
                case 0:
                    url = "http://localhost/laravel/findler/public/courses";
                    title = "Novedades";
                    datos = new string[3] { url, title, "no" };
                    contenido.Navigate(typeof(NuevosPage), datos);
                    split.IsPaneOpen = !split.IsPaneOpen;
                    break;

                case 1:
                    url = "http://localhost/laravel/findler/public/trends";
                    title = "Tendencias";
                    datos = new string[3] { url, title, "no" };
                    contenido.Navigate(typeof(NuevosPage), datos);
                    split.IsPaneOpen = !split.IsPaneOpen;
                    break;

                case 2:
                    contenido.Navigate(typeof(CategoriesPage));
                    split.IsPaneOpen = !split.IsPaneOpen;
                    break;

                case 3:
                    ApplicationDataContainer ingreso = ApplicationData.Current.LocalSettings;
                    string correo = ingreso.Values["user"] as string;
                    url = "http://localhost/laravel/findler/public/favs/"+correo;
                    title = "Favoritos";
                    datos = new string[3] { url, title, "no" };
                    contenido.Navigate(typeof(NuevosPage), datos);
                    split.IsPaneOpen = !split.IsPaneOpen;
                    break;

                case 4:
                    string texto = "Aceptamos todo tipo de mensajes de nuestros usuarios, consejos, sugerencias, felicitaciones, reclamos, quejas, etc. Dinos lo que desees, pero hazlo con respeto. Tus mensajes nos permiten crecer, dejanos una en nuestra web.";
                    contenido.Navigate(typeof(AparecerPage), texto);
                    split.IsPaneOpen = !split.IsPaneOpen;
                    break;

                case 5:
                    string texto1 = "Si deseas que tu curso online aparezca en Findler debes diligenciar el formulario que se encuentra en nuestra web, tu curso sera evaluado y si consideramos que cumple todas nuestras politicas y restricciones, nos comunicaremos contigo.";
                    contenido.Navigate(typeof(AparecerPage), texto1);
                    split.IsPaneOpen = !split.IsPaneOpen;
                    break;

                case 6:
                    Frame rootFrame = Window.Current.Content as Frame;
                    rootFrame.Navigate(typeof(LoginPage));
                    break;
            }
        }
    }
}
