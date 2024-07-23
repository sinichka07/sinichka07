using System;
using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System.Linq;

namespace LatestVersionOfMusicAlbums
{

    public class AlbumController
    {
        private AlbumModel model;
        private MainWindow view;

        public AlbumController(AlbumModel model, MainWindow view)
        {
            this.model = model;
            this.view = view;
        }

        public void AddAlbum(string title, string artist, int year)
        {
            var newAlbum = new Album
            {
                Id = model.GetAlbums().Count + 1,
                Title = title,
                Artist = artist,
                Year = year
            };
            model.AddAlbum(newAlbum);
            LoadAlbums();
        }

        public void RemoveAlbum(int id)
        {
            model.RemoveAlbum(id);
            LoadAlbums();
        }

        public void LoadAlbums()
        {
            if (view.AlbumListBox != null)
            {
                view.AlbumListBox.Items.Clear();
                foreach (var album in model.GetAlbums())
                {
                    view.AlbumListBox.Items.Add($"{album.Title} - {album.Artist}");
                }
            }
        }
        

    }
    public partial class MainWindow : Window
    {
        private AlbumController controller;

        public MainWindow()
        {
            InitializeComponent();
            var model = new AlbumModel();
            controller = new AlbumController(model, this);
            controller.LoadAlbums();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            TitleTextBox = this.FindControl<TextBox>("TitleTextBox");
            ArtistTextBox = this.FindControl<TextBox>("ArtistTextBox");
            YearTextBox = this.FindControl<TextBox>("YearTextBox");
            AlbumListBox = this.FindControl<ListBox>("AlbumListBox");
        }

        private void AddAlbum_Click(object sender, RoutedEventArgs e)
        {
            if (TitleTextBox == null || ArtistTextBox == null || YearTextBox == null)
            {
                throw new Exception("TitleTextBox or ArtistTextBox or YearTextBox is not initialized.");
            }

            controller.AddAlbum(TitleTextBox.Text, ArtistTextBox.Text, int.Parse(YearTextBox.Text));
            TitleTextBox.Text = string.Empty;
            ArtistTextBox.Text = string.Empty;
            YearTextBox.Text = string.Empty;
        }

        private void DeleteAlbum(int id)
        {
            Album album = null;
            foreach (var a in albums)
            {
                if (a.Id == 2)
                {
                    album = a;
                    break;
                }
            }

            if (album != null)
            {
                Console.WriteLine($"Found album: {album.Title} by {album.Artist}");
            }
            else
            {
                Console.WriteLine("Album not found.");
            }
        }


    }
    

}
