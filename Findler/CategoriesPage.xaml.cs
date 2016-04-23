using Findler.Net;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Data.Json;
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
    public sealed partial class CategoriesPage : Page
    {
        HttpConnection con;
        string url = "http://localhost/laravel/findler/public/categories";
        JsonArray json;

        public CategoriesPage()
        {
            con = new HttpConnection();
            loadCategories();
        }

        private List<string> data;
        public List<string> Data
        {
            get
            {
                if (data == null)
                {
                    data = new List<string>();
                    foreach (JsonValue jsonValue in json)
                    {
                        string nombre = jsonValue.GetString();
                        data.Add(nombre);
                    }
                }

                return data;
            }

            set
            {
                data = value;
            }
        }

        public async void loadCategories()
        {
            string rta = await con.requestByGet(url);
            json = JsonArray.Parse(rta);
            this.InitializeComponent();
        }

        private void seleccion(object sender, SelectionChangedEventArgs e)
        {
            string categoria = data.ElementAt(list.SelectedIndex);
            string url = "http://localhost/laravel/findler/public/categories/"+categoria;
            string back = "si";
            string[] datos = new string[] { url, categoria, back };
            Frame root = Window.Current.Content as Frame;
            root.Navigate(typeof(NuevosPage), datos);
        }
    }
}
