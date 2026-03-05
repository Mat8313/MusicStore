using MusicStore.Messages;
using MusicStore.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using MusicStore.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MusicStore.ViewModels
{
    public partial class MusicStoreViewModel : ViewModelBase
    {
        [ObservableProperty]
        public partial string? SearchText { get; set; }

        [ObservableProperty]
        public partial bool IsBusy { get; private set; }

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(BuyMusicCommand))]
        public partial AlbumViewModel? SelectedAlbum { get; set; }
        public ObservableCollection<AlbumViewModel> SearchResults { get; } = new();

        private async Task DoSearch(string? term)
        {
            IsBusy = true;
            SearchResults.Clear();

            var albums = await Album.SearchAsync(term);

            foreach (var album in albums)
            {
                var vm = new AlbumViewModel(album);
                SearchResults.Add(vm);
            }

            IsBusy = false;
        }

        [RelayCommand(CanExecute = nameof(CanBuyMusic))]
        private void BuyMusic()
        {
            if (SelectedAlbum != null)
            {
                var album_exists = WeakReferenceMessenger.Default.Send(new CheckAlbumAlreadyExistsMessage(SelectedAlbum));
                if (album_exists)
                {
                    WeakReferenceMessenger.Default.Send(new NotificationMessage("This album was already added"));
                }
                else
                {
                    WeakReferenceMessenger.Default.Send(new MusicStoreClosedMessage(SelectedAlbum));
                }
            }
        }
        
        private bool CanBuyMusic() => SelectedAlbum != null;

        partial void OnSearchTextChanged(string? value)
        {
            _ = DoSearch(SearchText);
        }
    }
}