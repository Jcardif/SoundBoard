﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SearchAutoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {

        }

        private void SearchAutoSuggestBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {

        }

        private void MenuItemsListView_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void SoundGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var sound = (Sound) e.ClickedItem;
            SoundMediaElement.Source=new Uri(this.BaseUri, sound.AudoFile);
        }
    }
}
