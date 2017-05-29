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
                string connectionString = await FileIO.ReadTextAsync(
                    await StorageFile.GetFileFromApplicationUriAsync(
                        new Uri("ms-appx:///default-connection-string.txt")));
                string createTablesCommand = await FileIO.ReadTextAsync(
                    await StorageFile.GetFileFromApplicationUriAsync(
                        new Uri("ms-appx:///create-tables.sql")));

                new AppDatabase(connectionString, createTablesCommand);
            }
        }
    }
}
