using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using MusicStore.Messages;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using MusicStore.Models;
using System.Linq;

namespace MusicStore.ViewModels
{
    public partial class MainWindowViewModel : ObservableObject
    {
        public MainWindowViewModel()
        {
            LoadAlbums();
            WeakReferenceMessenger.Default.Register<CheckAlbumAlreadyExistsMessage>(this, (v, m) =>
            {
                m.Reply(Albums.Contains(m.Album));
            });
        }

        [RelayCommand]
        private async Task AddAlbumAsync()
        {
            var album = await WeakReferenceMessenger.Default.Send(new PurchaseAlbumMessage());
            if (album is not null)
            {
                Albums.Add(album);
                await album.SaveToDiskAsync();
            }
        }

        private async void LoadAlbums()
        {
            var albums = (await Album.LoadCachedAsync()).Select(x => new AlbumViewModel(x)).ToList();
            foreach (var album in albums)
            {
                Albums.Add(album);
            }
        }


        public ObservableCollection<AlbumViewModel> Albums { get; } = new();
    }
}