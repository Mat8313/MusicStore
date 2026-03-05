using MusicStore.ViewModels;
using CommunityToolkit.Mvvm.Messaging.Messages;
using MusicStore.Views;

namespace MusicStore.Messages;

public class PurchaseAlbumMessage : AsyncRequestMessage<AlbumViewModel?>;