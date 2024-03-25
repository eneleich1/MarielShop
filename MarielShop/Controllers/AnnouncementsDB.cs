using MarielShop.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarielShop.Controllers
{
    public class AnnouncementsDB
    {
        readonly SQLiteAsyncConnection dbAsync;
        readonly SQLiteConnection db;

        public AnnouncementsDB(string dbPath)
        {
            dbAsync = new SQLiteAsyncConnection(dbPath);
            db = new SQLiteConnection(dbPath);
        }

        /// <summary>
        /// Return Table Announcement
        /// </summary>
        /// <returns></returns>
        public TableQuery<Announcement> TableAnnouncement()
        {
            var table = db.Table<Announcement>();

            return table;
        }
        /// <summary>
        /// Make a synchronized query and return the list of founds items.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public List<Announcement> QueryAnnouncement(string query)
        {
            return db.Query<Announcement>(query).ToList();
        }
        /// <summary>
        /// Make a Asynchronized query and return the results items.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public Task<List<Announcement>> QueryAnnouncementAsync(string query)
        {
            return dbAsync.QueryAsync<Announcement>(query);
        }

        //public Task<List<Announcement>> GetItemsAsync()
        //{
        //     return db.Table<Announcement>().ToListAsync();
        //}

        //private List<Announcement> QueryAnnouncement(string query)
        //{
        //    var db = new SQLiteConnection(MainPage.dbPath);
        //    return db.Query<Announcement>(query).ToList();
        //}

        //public Task<int> SaveItemAsync(Announcement item)
        //{
        //    if (item.Id != 0)
        //    {
        //        return db.UpdateAsync(item);
        //    }
        //    else
        //    {
        //        return db.InsertAsync(item);
        //    }
        //}
        //public Task<int> DeleteItemAsync(Announcement item)
        //{
        //    return db.DeleteAsync(item);
        //}
    }
}
