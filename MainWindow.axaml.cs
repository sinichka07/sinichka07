using Avalonia.Controls;
using Avalonia.Interactivity;
using MusicAlbumManager;
using musicalbums;
using System;
using System.Collections.Generic;

namespace MusicAlbumManager.Views
{
    public partial class MainWindow : Window
    {
        private readonly AlbumController _controller;
        public object AlbumListBox_Items { get; private set; }
        public object AlbumListBox { get; private set; }
        public Album AlbumListBox_SelectedItem { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
            _controller = new AlbumController(new InMemoryAlbumRepository());
            LoadAlbums();
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }

        private void LoadAlbums()
        {
            var albums = _controller.GetAllAlbums();
            AlbumListBox_Items = albums;
        }

        private async void AddAlbumButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new AlbumDialog();
            var result = await dialog.ShowDialog<Album>(this);
            if (result != null)
            {
                _controller.AddAlbum(result.Title, result.Artist, result.ReleaseYear, result.Tracks);
                LoadAlbums();
            }
        }

        private async void EditAlbumButton_Click(object sender, RoutedEventArgs e)
        {
            if (AlbumListBox_SelectedItem is Album selectedAlbum)
            {
                var dialog = new AlbumDialog
                {
                    AlbumTitle = selectedAlbum.Title,
                    Artist = selectedAlbum.Artist,
                    ReleaseYear = selectedAlbum.ReleaseYear,
                    Tracks = string.Join(", ", selectedAlbum.Tracks)
                };
                var result = await dialog.ShowDialog<Album>(this);
                if (result != null)
                {
                    _controller.EditAlbum(selectedAlbum.Id, result.Title, result.Artist, result.ReleaseYear, result.Tracks);
                    LoadAlbums();
                }
            }
        }

        private void DeleteAlbumButton_Click(object sender, RoutedEventArgs e)
        {
            if (AlbumListBox_SelectedItem is Album selectedAlbum)
            {
                _controller.DeleteAlbum(selectedAlbum.Id);
                LoadAlbums();
            }
        }
    }
}
