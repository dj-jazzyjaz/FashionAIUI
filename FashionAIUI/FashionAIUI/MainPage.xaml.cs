﻿using System;
using System.Collections.Generic;
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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace FashionAIUI
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
       

            Boolean pic1;
            Boolean pic2;
            public MainPage()
            {
                this.InitializeComponent();
                Button1.Visibility = Visibility.Visible;
                Button2.Visibility = Visibility.Visible;
                MixBtn.Visibility = Visibility.Collapsed;
                pic1 = false;
                pic2 = false;
            }



            private async void UploadPic(object sender, RoutedEventArgs e)
            {
                var picker = new Windows.Storage.Pickers.FileOpenPicker();
                picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
                picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.PicturesLibrary;
                picker.FileTypeFilter.Add(".jpg");
                picker.FileTypeFilter.Add(".jpeg");
                picker.FileTypeFilter.Add(".png");

                Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();
                if (file != null)
                {

                    // Application now has read/write access to the picked file 
                    //imagePath.Text = file.Path;

                    // Open a stream for the selected file. 
                    // The 'using' block ensures the stream is disposed 
                    // after the image is loaded. 
                    using (Windows.Storage.Streams.IRandomAccessStream fileStream =
                        await file.OpenAsync(Windows.Storage.FileAccessMode.Read))
                    {
                        // Set the image source to the selected bitmap. 
                        BitmapImage bitmapImage = new BitmapImage();
                        bitmapImage.SetSource(fileStream);
                        uploadedImage.Source = bitmapImage;
                        Button1.Visibility = Visibility.Collapsed;
                        pic1 = true;

                        if (pic1 && pic2)
                        {
                            MixBtn.Visibility = Visibility.Visible;
                        }

                    }
                }

            }

            private async void UploadPic2(object sender, RoutedEventArgs e)
            {
                var picker = new Windows.Storage.Pickers.FileOpenPicker();
                picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
                picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.PicturesLibrary;
                picker.FileTypeFilter.Add(".jpg");
                picker.FileTypeFilter.Add(".jpeg");
                picker.FileTypeFilter.Add(".png");

                Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();
                if (file != null)
                {

                    // Application now has read/write access to the picked file 
                    //imagePath.Text = file.Path;

                    // Open a stream for the selected file. 
                    // The 'using' block ensures the stream is disposed 
                    // after the image is loaded. 
                    using (Windows.Storage.Streams.IRandomAccessStream fileStream =
                        await file.OpenAsync(Windows.Storage.FileAccessMode.Read))
                    {
                        BitmapImage bitmapImage = new BitmapImage();
                        bitmapImage.SetSource(fileStream);
                        uploadedImage2.Source = bitmapImage;
                        Button2.Visibility = Visibility.Collapsed;
                        pic2 = true;

                        if (pic1 && pic2)
                        {
                            MixBtn.Visibility = Visibility.Visible;
                        }
                    }
                }

            }

            public void Reset(object sender, RoutedEventArgs e)
            {
                Button1.Visibility = Visibility.Visible;
                Button2.Visibility = Visibility.Visible;
                uploadedImage.Source = null;
                uploadedImage2.Source = null;
                pic1 = false;
                pic2 = false;
                MixBtn.Visibility = Visibility.Collapsed;
            }

        }
    
}