using MarielShop.Controllers;
using MarielShop.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MarielShop.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Recently : ContentPage
    {
        public Recently()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (App.ExistDatabase())
            {
                var db = new AnnouncementsDB(App.pathHandler.DatabasePath);

                //QueryAnnouncement("select * from Announcement");
                lv.ItemsSource = db.TableAnnouncement();
            }
        }
    }
}
