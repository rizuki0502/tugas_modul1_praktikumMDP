using Kelompok5.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Kelompok5
{
    public class HalamanUtama : ContentPage
    {
        public HalamanUtama()
        {
            this.Title = "Data Mahasiswa";

            StackLayout stacklayout = new StackLayout();
            Button button = new Button();
            button.Text = "Tambah Data";
            button.Clicked += Button_Tambah_Clicked;
            stacklayout.Children.Add(button);

            button = new Button();
            button.Text = "Lihat Data";
            button.Clicked += Button_Lihat_Clicked;
            stacklayout.Children.Add(button);

            button = new Button();
            button.Text = "Sunting Data";
            button.Clicked += Button_Sunting_Clicked;
            stacklayout.Children.Add(button);

            button = new Button();
            button.Text = "Delete Data";
            button.Clicked += Button_Hapus_Clicked;
            stacklayout.Children.Add(button);

            Content = stacklayout;
        }

        private async void Button_Hapus_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HalamanDeleteData());
        }
        private async void Button_Sunting_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HalamanEditData());
        }
        private async void Button_Tambah_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HalamanTambahData());
        }
        private async void Button_Lihat_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HalamanLihatData());
        }

    }
}