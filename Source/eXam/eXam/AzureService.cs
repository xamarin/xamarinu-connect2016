using System;
using System.Collections.Generic;
using System.IO;
using Xamarin.Forms;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;
using System.Threading.Tasks;
using System.Diagnostics;
using eXam;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;

[assembly: Dependency(typeof(AzureService))]
namespace eXam
{
    public class AzureService
    {
        MobileServiceClient client { get; set; }
        
        IMobileServiceSyncTable<QuizQuestion> table;

        public async Task Initialize()
        {
            if (client?.SyncContext?.IsInitialized ?? false)
                return;

            var azureUrl = "http://vsconnectxam.azurewebsites.net/";

            //Create our client
            client = new MobileServiceClient(azureUrl);

            //InitialzeDatabase for path
            var path = "questions.db";
            path = Path.Combine(MobileServiceClient.DefaultDatabasePath, path);


            //setup our local sqlite store and intialize our table
            var store = new MobileServiceSQLiteStore(path);

            //Define table
            store.DefineTable<QuizQuestion>();

            //Initialize SyncContext
            await client.SyncContext.InitializeAsync(store, new MobileServiceSyncHandler());

            table = client.GetSyncTable<QuizQuestion>();
        }

        public async Task<List<QuizQuestion>> GetQuestions()
        {
            await Initialize();
            await SyncQuestions();
            return await table.ToListAsync();
        }


        public async Task SyncQuestions()
        {
            try
            {
                await client.SyncContext.PushAsync();
                await table.PullAsync("allQuizQuestions", table.CreateQuery());
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Unable to sync, using offline capabilities: " + ex);
            }

        }
    }
}