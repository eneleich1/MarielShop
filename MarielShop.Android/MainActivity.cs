using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using SQLite;
using System.IO;
using MarielShop.Tools;
using System.Xml.Serialization;
using Android.Content;

namespace MarielShop.Droid
{
    [Activity(Label = "MarielShop", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public static Context CurrentContext;

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            CurrentContext = this;

            var app = new App();

            App.InitShareObjects(new FileSystem_Android(), new MessageRender_Android(),
                new PathsHandler
                {
                    AppDataFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData),
                    DatabasePath= Path.Combine(Android.OS.Environment.ExternalStorageDirectory.AbsolutePath, "marielshop.db3"),
                    SettingsFileName= "settings.st"
                });

            var settingsPath = System.IO.Path.Combine(App.pathHandler.AppDataFolder, App.pathHandler.SettingsFileName);

            if (App.fileSystem.Exist(settingsPath))
            {
                App.appSettings = (AppSettings)App.fileSystem.Deserialize(settingsPath, typeof(AppSettings));
            }
            else
            {
                App.appSettings = new AppSettings { DbPath = App.pathHandler.DatabasePath };
                App.fileSystem.Serialize(settingsPath, App.appSettings, typeof(AppSettings));
            }

            LoadApplication(app);
        }
    }

    public class FileSystem_Android : FileSystem
    {
        public override object Deserialize(string filePath, Type type)
        {
            XmlSerializer serializer = new XmlSerializer(type);
            var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            var res = serializer.Deserialize(fs);
            fs.Close();

            return res;
        }

        public override bool Exist(string filePath)
        {
            return File.Exists(filePath);
        }

        public override void Serialize(string filePath, object value, Type type)
        {
            XmlSerializer serializer = new XmlSerializer(type);
            var fs = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            serializer.Serialize(fs, value);
            fs.Close();
        }
    }

    public class MessageRender_Android : MessageRender
    {
        public override void DisplayMessage(string message)
        {
            Toast.MakeText(MainActivity.CurrentContext, message, ToastLength.Long);
        }
    }

}

