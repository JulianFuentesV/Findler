using Findler.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
        public MainPage()
        {
            this.InitializeComponent();
        }

        private ObservableCollection<Curso> data;
        public ObservableCollection<Curso> Data
        {
            get
            {
                if(data == null)
                {
                    data = new ObservableCollection<Curso>();
                    Curso c1 = new Curso()
                    {
                        Nombre = "Android Basico",
                        Lenguaje = "Java",
                        Framework = "AndroidStudio",
                        Duracion = "40 horas",
                        Nivel = "Principiante",
                        Requerimientos = "Bases en java",
                        Valor = "Gratis",
                        Certificado = "No"
                    };

                    Curso c2 = new Curso()
                    {
                        Nombre = "Ruby on Rails",
                        Lenguaje = "Ruby",
                        Framework = "Rails",
                        Duracion = "60 horas",
                        Nivel = "Avanzado",
                        Requerimientos = "Ruby basico",
                        Valor = "USD 99.99",
                        Certificado = "Si"
                    };

                    Curso c3 = new Curso()
                    {
                        Nombre = "Desarrollo web",
                        Lenguaje = "PHP",
                        Framework = "Laravel",
                        Duracion = "60 horas",
                        Nivel = "Intermedio",
                        Requerimientos = "N/A",
                        Valor = "USD 39.99",
                        Certificado = "Si"
                    };

                    data.Add(c1);
                    data.Add(c2);
                    data.Add(c3);
                }
                return data;
            }
            set
            {
                data = value;
            }
        }
    }
}
