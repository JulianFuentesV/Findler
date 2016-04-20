using Findler.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            datos = new string[2] { url, title};
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

                    menu.Add(opc1);
                    menu.Add(opc2);
                    menu.Add(opc3);
                    menu.Add(opc4);
                    menu.Add(opc5);
                    menu.Add(opc6);

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
                    datos = new string[2] { url, title };
                    contenido.Navigate(typeof(NuevosPage), datos);
                    split.IsPaneOpen = !split.IsPaneOpen;
                    break;

                case 1:
                    url = "http://localhost/laravel/findler/public/trends";
                    title = "Tendencias";
                    datos = new string[2] { url, title };
                    contenido.Navigate(typeof(NuevosPage), datos);
                    split.IsPaneOpen = !split.IsPaneOpen;
                    break;
            }
        }

        //private ObservableCollection<Curso> data;
        //public ObservableCollection<Curso> Data
        //{
        //    get
        //    {
        //        if(data == null)
        //        {
        //            data = new ObservableCollection<Curso>();
        //            Curso c1 = new Curso()
        //            {
        //                Nombre = "Android Basico",
        //                Lenguaje = "Java",
        //                Framework = "AndroidStudio",
        //                Duracion = "40 horas",
        //                Nivel = "Principiante",
        //                Requerimientos = "Bases en java",
        //                Valor = "Gratis",
        //                Certificado = "No",
        //                Imagen = "http://1.bp.blogspot.com/-UGrENgc-ec8/VIJsFPD19aI/AAAAAAAABBk/ICFczO1O6mU/s1000/studio-logo.png",
        //                Categoria = "Gratis"
        //            };

        //            Curso c2 = new Curso()
        //            {
        //                Nombre = "Ruby on Rails",
        //                Lenguaje = "Ruby",
        //                Framework = "Rails",
        //                Duracion = "60 horas",
        //                Nivel = "Avanzado",
        //                Requerimientos = "Ruby basico",
        //                Valor = "USD 99.99",
        //                Certificado = "Si",
        //                Imagen = "http://programacion.net/files/article/20151023121029_rubyrails.png",
        //                Categoria = "Gratis"
        //            };

        //            Curso c3 = new Curso()
        //            {
        //                Nombre = "Desarrollo web",
        //                Lenguaje = "PHP",
        //                Framework = "Laravel",
        //                Duracion = "60 horas",
        //                Nivel = "Intermedio",
        //                Requerimientos = "N/A",
        //                Valor = "USD 39.99",
        //                Certificado = "Si",
        //                Imagen = "http://danielmlozano.com/wp-content/uploads/2016/01/laravel-2.jpg",
        //                Categoria = "Pago"
        //            };

        //            data.Add(c1);
        //            data.Add(c2);
        //            data.Add(c3);
        //        }
        //        return data;
        //    }
        //    set
        //    {
        //        data = value;
        //    }
        //}
    }
}
