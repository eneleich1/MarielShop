using MarielShop.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MarielShop.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Settings : ContentPage
    {
        public Settings()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            dataBase_et.Text = App.pathHandler.DatabasePath;
        }

        private void checkdb_bt_Clicked(object sender, EventArgs e)
        {
            try
            {
                //setup the db connection
                var db = new SQLiteConnection(dataBase_et.Text);

                //setup a table
                var table = db.Table<Announcement>();

                var first = table.Count();

                App.pathHandler.DatabasePath = dataBase_et.Text;

                logs_lb.TextColor = Color.Green;
                logs_lb.Text = "!!Base de Datos Correcta";


                //var assembly = IntrospectionExtensions.GetTypeInfo(typeof(LoadResourceText)).Assembly;
                //Stream stream = assembly.GetManifestResourceStream("WorkingWithFiles.PCLTextResource.txt");
                //string text = "";
                //using (var reader = new System.IO.StreamReader(stream))
                //{
                //    text = reader.ReadToEnd();
                //}

                //var assembly = IntrospectionExtensions.GetTypeInfo(typeof(LoadResourceText)).Assembly;
                //Stream stream = assembly.GetManifestResourceStream("WorkingWithFiles.PCLTextResource.txt");
                //string text = "";
                //using (var reader = new System.IO.StreamReader(stream))
                //{
                //    text = reader.ReadToEnd();
                //}

                //var assembly = IntrospectionExtensions.GetTypeInfo(typeof(LoadResourceText)).Assembly;
                //Stream stream = assembly.GetManifestResourceStream("WorkingWithFiles.PCLXmlResource.xml");
                //List<Monkey> monkeys;
                //using (var reader = new System.IO.StreamReader(stream))
                //{
                //    var serializer = new XmlSerializer(typeof(List<Monkey>));
                //    monkeys = (List<Monkey>)serializer.Deserialize(reader);
                //}
                //var listView = new ListView();
                //listView.ItemsSource = monkeys;

                //MainActivity.AppSettings.DbPath = db_et.Text;
                //MainActivity.AppSettings.Save(MainActivity.settingsPath);

                //logs_tv.Text = "!!Base de Datos Correcta...!!";
            }
            catch (Exception ex)
            {
                logs_lb.TextColor = Color.Red;
                logs_lb.Text = ex.Message;
            }
        }
    }
}
