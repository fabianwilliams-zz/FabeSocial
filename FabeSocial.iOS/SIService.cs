using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;

namespace FabeSocial.iOS
{
    public class SIService
    {
        static SIService instance = new SIService();

        const string applicationURL = @"https://fabesocial.azure-mobile.net/";
        const string applicationKey = @"rAboImtvZvmXQCvktvnXgtIYzJERRX45";
        const string localDbPath = "localstore.db";

        private MobileServiceClient client;
        private IMobileServiceSyncTable<SocialItem> socTable;

        private SIService()
        {
            CurrentPlatform.Init();
            SQLitePCL.CurrentPlatform.Init();

            // Initialize the Mobile Service client with your URL and key
            client = new MobileServiceClient(applicationURL, applicationKey);

            // Create an MSTable instance to allow us to work with the TodoItem table
            socTable = client.GetSyncTable<SocialItem>();
        }
        public static SIService DefaultService
        {
            get
            {
                return instance;
            }
        }
        public List<SocialItem> Items { get; private set; }
        public async Task InitializeStoreAsync()
        {
            var store = new MobileServiceSQLiteStore(localDbPath);
            store.DefineTable<SocialItem>();

            // Uses the default conflict handler, which fails on conflict
            // To use a different conflict handler, pass a parameter to InitializeAsync. For more details, see http://go.microsoft.com/fwlink/?LinkId=521416
            await client.SyncContext.InitializeAsync(store);
        }
        public async Task SyncAsync()
        {
            try
            {
                await client.SyncContext.PushAsync();
                await socTable.PullAsync("allSocItems", socTable.CreateQuery()); // query ID is used for incremental sync
            }

            catch (MobileServiceInvalidOperationException e)
            {
                Console.Error.WriteLine(@"Sync Failed: {0}", e.Message);
            }
        }
        public async Task<List<SocialItem>> RefreshDataAsync()
        {
            try
            {
                // update the local store
                // all operations on todoTable use the local database, call SyncAsync to send changes
                await SyncAsync();

                // This code refreshes the entries in the list view by querying the local TodoItems table.
                // The query excludes completed SocialItems
                Items = await socTable
                        .Where(sItem => sItem.Id != null).ToListAsync();

            }
            catch (MobileServiceInvalidOperationException e)
            {
                Console.Error.WriteLine(@"ERROR {0}", e.Message);
                return null;
            }

            return Items;
        }

        public async Task InsertSocItemAsync(SocialItem sItem)
        {
            try
            {
                await socTable.InsertAsync(sItem); // Insert a new SocialItem into the local database. 
                await SyncAsync(); // send changes to the mobile service

                Items.Add(sItem);

            }
            catch (MobileServiceInvalidOperationException e)
            {
                Console.Error.WriteLine(@"ERROR {0}", e.Message);
            }
        }
        public async Task CompleteItemAsync(SocialItem item)
        {
            try
            {
                item.Id = null;
                await socTable.UpdateAsync(item); // update social item in the local database
                await SyncAsync(); // send changes to the mobile service

                Items.Remove(item);

            }
            catch (MobileServiceInvalidOperationException e)
            {
                Console.Error.WriteLine(@"ERROR {0}", e.Message);
            }
        }

    }
}
