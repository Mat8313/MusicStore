using CommunityToolkit.Mvvm.Messaging.Messages;
using MusicStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicStore.Messages
{
    public class CheckAlbumAlreadyExistsMessage : RequestMessage<bool>
    {
        public AlbumViewModel Album { get; }

        public CheckAlbumAlreadyExistsMessage(AlbumViewModel album)
        {
            Album = album;
        }
    }
}
