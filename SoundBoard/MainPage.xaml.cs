using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using SoundBoard.Models;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SoundBoard
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ObservableCollection<Sound> sounds;
        private List<MenuItem> menuItems;
        public MainPage()
        {
            this.InitializeComponent();
            sounds=new ObservableCollection<Sound>();
            SoundManager.GetAllSounds(sounds);

            menuItems = new List<MenuItem>()
            {
                new MenuItem {IconFile = "Assets/Icons/animals.png", SoundCategory = SoundCategory.Animals},
                new MenuItem {IconFile = "Assets/Icons/cartoon.png", SoundCategory = SoundCategory.Cartoons},
                new MenuItem {IconFile = "Assets/Icons/taunt.png", SoundCategory = SoundCategory.Taunts},
                new MenuItem {IconFile = "Assets/Icons/warning.png", SoundCategory = SoundCategory.Warnings}
            };
            BackButton.Visibility = Visibility.Collapsed;
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            SoundManager.GetAllSounds(sounds);
            CategoryTextBlock.Text = "All Sounds";
            MenuItemsListView.SelectedItem = null;
            BackButton.Visibility = Visibility.Collapsed;
        }

        private void SearchAutoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {

        }

        private void SearchAutoSuggestBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {

        }

        private void MenuItemsListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var menuItem = (MenuItem) e.ClickedItem;
            CategoryTextBlock.Text = menuItem.SoundCategory.ToString();
            SoundManager.GetSoundByCategory(sounds, menuItem.SoundCategory);
            BackButton.Visibility = Visibility.Visible;
        }

        private void SoundGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var sound = (Sound) e.ClickedItem;
            SoundMediaElement.Source=new Uri(this.BaseUri, sound.AudoFile);
        }

        private async void SoundGridView_OnDrop(object sender, DragEventArgs e)
        {
            if (e.DataView.Contains(StandardDataFormats.StorageItems))
            {
                var items = await e.DataView.GetStorageItemsAsync();
                if (items.Any())
                {
                    var storageFile = items[0] as StorageFile;
                    var contentType = storageFile.ContentType;

                    StorageFolder folder = ApplicationData.Current.LocalFolder;
                    if (contentType == "audio/wav" || contentType == "audio/,mpeg")
                    {
                        SoundMediaElement.SetSource(await storageFile.OpenAsync(FileAccessMode.Read), contentType);
                        SoundMediaElement.Play();
                    }
                }
            }
        }

        private void SoundGridView_OnDragOver(object sender, DragEventArgs e)
        {
            e.AcceptedOperation = DataPackageOperation.Copy;

            if (e.DragUIOverride != null)
            {
                e.DragUIOverride.Caption = "drop to create a custom sound and tile";
                e.DragUIOverride.IsCaptionVisible = true;
                e.DragUIOverride.IsContentVisible = true;
                e.DragUIOverride.IsGlyphVisible = true;
            }

            ;
        }
    }
}
