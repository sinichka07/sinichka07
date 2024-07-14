using Avalonia.Controls;
using Avalonia.Interactivity;
using MusicAlbumManager;
using System.Collections.Generic;

namespace MusicAlbumManager.Views
{
    public partial class AlbumDialog : Window
    {
        public string AlbumTitle { get => TitleTextBox.Text; set => TitleTextBox.Text = value; }
        public string Artist { get => ArtistTextBox.Text; set => ArtistTextBox.Text = value; }
        public int ReleaseYear { get => int.Parse(ReleaseYearTextBox.Text); set => ReleaseYearTextBox.Text = value.ToString(); }
        public string Tracks { get => TracksTextBox.Text; set => TracksTextBox.Text = value; }

        public AlbumDialog()
        {
            InitializeComponent();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            var tracks = new List<string>(Tracks.Split(new[] { ',' }, System.StringSplitOptions.RemoveEmptyEntries));
            var album = new Album
            {
                Title = AlbumTitle,
                Artist = Artist,
                ReleaseYear = ReleaseYear,
                Tracks = tracks
            };
            Close(album);
        }
    }
}
