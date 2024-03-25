using MarielShop.Controllers;
using MarielShop.Pages;
using MarielShop.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Xamarin.Forms;

namespace MarielShop
{
    public partial class MainPage : ContentPage
    {
        bool first = true;

        public MainPage()
        {
            InitializeComponent();
        }

        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            if (first)
            {
                if (App.fileSystem.Exist(App.pathHandler.DatabasePath))
                    DisplayAlert("Configuración de BaseDatos", "Ruta de BaseDatos Correcta", "Aceptar");
                else
                    DisplayAlert("Configuración de BaseDatos", "La Ruta de la BaseDatos no existe.\nPara establecer  ir a [Configuración].", "Aceptar");

                first = false;
            }
        }

        async void isnert_bt_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new Recently());
        }

        async void recently_bt_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Recently());
        }

        async void relevants_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Relevants());
        }

        async void search_bt_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Search());
        }

        async void settings_bt_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Settings());
        }

        async void about_bt_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new About());
        }

    }
}
