using System;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Storage;

namespace persistence_component
{
    public sealed class Startup
    {
        public IAsyncAction InitializeDatabase()
        {
            return CreateDatabaseHelper().AsAsyncAction();
        }

        private async Task CreateDatabaseHelper()
        {
            var storageItem = await ApplicationData.Current.LocalFolder.TryGetItemAsync("remembrance.db");

            if (storageItem == null)
            {
                //var localFolder = ApplicationData.Current.LocalFolder;
                //await localFolder.CreateFileAsync("default-connection-string.txt", CreationCollisionOption.ReplaceExisting);
                //var file = await localFolder.GetFileAsync("default-connection-string.txt");
                var settings = ApplicationData.Current.LocalSettings.Values;
                string connectionString = (string)settings["defaultConnectionString"];
                string createTablesCommand = (string)settings["createTablesCommand"];
                //await FileIO.WriteTextAsync(file, connectionString);

                //string createTablesCommand = await FileIO.ReadTextAsync(
                //    await StorageFile.GetFileFromApplicationUriAsync(
                //        new Uri("ms-appx:///create-tables.sql")));

                new AppDatabase(connectionString, createTablesCommand);
            }
        }
    }
}
