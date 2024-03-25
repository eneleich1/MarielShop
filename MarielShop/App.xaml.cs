using MarielShop.Controllers;
using MarielShop.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace MarielShop
{
    public partial class App : Application
    {
        public static FileSystem fileSystem;
        public static MessageRender messageRender;
        public static PathsHandler pathHandler;

        public static AppSettings appSettings;

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        public static void InitShareObjects(FileSystem fs,MessageRender mr,PathsHandler ph)
        {
            fileSystem = fs;
            messageRender = mr;
            pathHandler = ph;
        }
        public static bool ExistDatabase()
        {
            return fileSystem != null && pathHandler!=null && fileSystem.Exist(pathHandler.DatabasePath);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

    }
}
