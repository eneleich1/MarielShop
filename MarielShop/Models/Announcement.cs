using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarielShop.Models
{
    public class Announcement
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Header { get; set; }
        public string Body { get; set; }
        public string Location { get; set; }
        public float Price { get; set; }
        public bool IsRelevant { get; set; }
        public string Date { get; set; }
        public string Category { get; set; }
        public string Coin { get; set; }
        public string Condition { get; set; }
        public byte[] Image1 { get; set; }
        public byte[] Image2 { get; set; }
        public byte[] Image3 { get; set; }

        public string FormatedPrice
        {
            get { return string.Format("{0:C} {1}", Price, Coin.ToLower()); }
        }

        public Announcement() { }
        public Announcement(Announcement item)
        {
            Body = item.Body;
            Date = item.Date;
            Header = item.Header;
            IsRelevant = item.IsRelevant;
            Location = item.Location;
            Price = item.Price;
            Category = item.Category;
            Coin = item.Coin;
        }


        public override string ToString()
        {
            return string.Format("{0} {1}  {2}", Price, Coin, Header);
        }
    }
}
