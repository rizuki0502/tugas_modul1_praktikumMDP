using Kelompok5.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Kelompok5.View
{
    public class HalamanDeleteData : ContentPage
    {
        private ListView _listView;
        private Button _hapus;

        DataMahasiswa _datamahasiswa = new DataMahasiswa();

        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db4");

        private async void _hapus_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);
            db.Table<DataMahasiswa>().Delete(x => x.Id == _datamahasiswa.Id);
            await DisplayAlert(null, "Data " + _datamahasiswa.Nama + " berhasil dihapus", "Done");
            await Navigation.PopAsync();
        }

        private void _listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            _datamahasiswa = (DataMahasiswa)e.SelectedItem;

        }

        private void _button_Clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public HalamanDeleteData()
        {
            this.Title = "Hapus Data Mahasiswa";

            var db = new SQLiteConnection(_dbPath);

            StackLayout stackLayout = new StackLayout();

            _listView = new ListView();
            _listView.ItemsSource = db.Table<DataMahasiswa>().OrderBy(x => x.Nama).ToList();
            _listView.ItemSelected += _listView_ItemSelected;
            stackLayout.Children.Add(_listView);

            _hapus = new Button();
            _hapus.Text = "Hapus Data";
            _hapus.Clicked += _hapus_Clicked;
            stackLayout.Children.Add(_hapus);

            Content = stackLayout;
        }
    }
}