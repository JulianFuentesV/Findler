using Findler.Models;
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
    public sealed partial class NuevosPage : Page
    {
        HttpConnection con;
        string url;
        string title;
        string back;
        string[] u = new string[3];
        JsonArray json;

        public NuevosPage()
        {
            con = new HttpConnection();
            
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            u = e.Parameter as string[];
            url = u[0];
            title = u[1];
            back = u[2];
            loadCourses();
        }

        private ObservableCollection<Curso> data;
        public ObservableCollection<Curso> Data
        {
            get
            {
                if (data == null)
                {
                    data = new ObservableCollection<Curso>();
                    
                    if (json.Count == 0)
                    {
                        aviso.Text = "No se han encontrado favoritos.";
                    } else
                    {
                        foreach (JsonValue jsonValue in json)
                        {
                            JsonObject course = jsonValue.GetObject();
                            Curso c = new Curso();
                            c.Nombre = course["nombre"].GetString();
                            c.Lenguaje = course["lenguaje"].GetString();
                            c.Framework = course["framework"].GetString();
                            c.Duracion = course["duracion"].GetString();
                            c.Nivel = course["nivel"].GetString();
                            c.Requerimientos = course["requerimientos"].GetString();
                            c.Valor = course["valor"].GetNumber();
                            c.Moneda = course["moneda"].GetString();
                            c.Certificado = course["certificado"].GetString();
                            c.Imagen = course["imagen"].GetString();
                            c.Descripcion = course["descripcion"].GetString();
                            c.Calificacion = course["calificacion"].GetNumber();

                            data.Add(c);
                        }
                    }
                }

                return data;
            }

            set
            {
                data = value;
            }
        }

        public async void loadCourses()
        {
            string rta = await con.requestByGet(url);
            json = JsonArray.Parse(rta);
            this.InitializeComponent();
            if (back == "si")
            {
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
                SystemNavigationManager.GetForCurrentView().BackRequested += Main_BackRequested;
            } else
            {
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
            }
            titulo.Text = title;
        }

        private void Main_BackRequested(object sender, BackRequestedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            if (rootFrame.CanGoBack && e.Handled == false)
            {
                e.Handled = true; rootFrame.GoBack();
            }
        }

        private void selected(object sender, SelectionChangedEventArgs e)
        {
            Curso c = data.ElementAt(list.SelectedIndex);
            Frame root = Window.Current.Content as Frame;
            root.Navigate(typeof(ContentPage), c);
        }
    }
}
