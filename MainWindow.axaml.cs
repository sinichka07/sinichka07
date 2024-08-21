using System;
using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System.Linq;
using System.Reflection;

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
                    view.AlbumListBox.Items.Add($"{album.Title} - {album.Artist}({album.Year})");
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
            DeleteAlbumIdTextBox = this.FindControl<TextBox>("DeleteAlbumIdTextBox");
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

        private void DeleteAlbum_Click(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(DeleteAlbumIdTextBox.Text);
            controller.RemoveAlbum(id);
            DeleteAlbumIdTextBox.Text = string.Empty;
            if (DeleteAlbumIdTextBox == null)
            {
                throw new Exception("DeleteAlbumIdTextBox is not initialized");
            }

            if (DeleteAlbumIdTextBox.Text != null)
            {
                Console.WriteLine("Album was succesfully deleted!");
            }
            else
            {
                Console.WriteLine("Album was not found");
            }

        }
        private void EditAlbum_Click(object sender, RoutedEventArgs e)
        {
            if (EditAlbumIdTextBox == null)
            {
                throw new Exception("EditAlbumIdTextBox is not initialized");
            }

            int id;
            if (!int.TryParse(EditAlbumIdTextBox.Text, out id))
            {
                Console.WriteLine("Invalid Album ID");
                return;
            }

            if (EditedTitleTextBox == null || EditedArtistTextBox == null || EditedYearTextBox == null)
            {
                throw new Exception("EditedTitleTextBox or EditedArtistTextBox or EditedYearTextBox is not initialized");
            }

            Album updatedAlbum = new Album
            {
                Title = EditedTitleTextBox.Text,
                Artist = EditedArtistTextBox.Text,
                Year = EditedYearTextBox.Text
            };

            albumController.EditAlbum(id, updatedAlbum);

            Console.WriteLine("Album was successfully edited");
        }
        private void SaveAlbum_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}



    
    

