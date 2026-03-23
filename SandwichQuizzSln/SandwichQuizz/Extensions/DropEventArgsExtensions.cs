namespace SandwichQuizz.Extensions;

public static class DropEventArgsExtensions
{
    extension(DropEventArgs eventArgs)
    {
        public async Task<string?> DroppedFilePathAsync()
            => (await eventArgs.DroppedFilePathesAsync()).FirstOrDefault();

        public async Task<IEnumerable<string>> DroppedFilePathesAsync()
        {
#if WINDOWS
            if (eventArgs.PlatformArgs?
                         .DragEventArgs
                         .DataView
                         .Contains(Windows.ApplicationModel.DataTransfer.StandardDataFormats.StorageItems)
                    is true)
            {
                return (await eventArgs.PlatformArgs.DragEventArgs.DataView.GetStorageItemsAsync())
                       .OfType<Windows.Storage.StorageFile>()
                       .Select(sf => sf.Path);
            }
#endif
            return [];
        }
    }
}
