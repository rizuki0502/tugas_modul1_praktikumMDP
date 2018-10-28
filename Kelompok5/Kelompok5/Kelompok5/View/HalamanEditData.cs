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
    public class HalamanEditData : ContentPage
    {
        private ListView _listView;
        private Entry _name;
        private Entry _departemen;
        private Button _save;

        DataMahasiswa _datamahasiswa = new DataMahasiswa();

        string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db4");

        private void _listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            _datamahasiswa = (DataMahasiswa)e.SelectedItem;
            _name.Text = _datamahasiswa.Nama;
            _departemen.Text = _datamahasiswa.Jurusan;
        }

        private async void _save_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);
            DataMahasiswa dataMahasiswa = new DataMahasiswa()
            {
                Id = _datamahasiswa.Id,
                Nama = _name.Text,
                Jurusan = _departemen.Text
            };
            db.Update(dataMahasiswa);
            await DisplayAlert(null, "Data " + dataMahasiswa.Nama + " telah disunting", "Done");
            await Navigation.PopAsync();
        }

        public HalamanEditData()
        {
            this.Title = "Edit Data Mahasiswa";

            var db = new SQLiteConnection(_dbPath);

            StackLayout stackLayout = new StackLayout();

            _listView = new ListView();
            _listView.ItemsSource = db.Table<DataMahasiswa>().OrderBy(x => x.Nama).ToList();
            _listView.ItemSelected += _listView_ItemSelected;
            stackLayout.Children.Add(_listView);

            _name = new Entry();
            _name.Keyboard = Keyboard.Text;
            _name.Placeholder = "Nama";
            stackLayout.Children.Add(_name);

            _departemen = new Entry();
            _departemen.Keyboard = Keyboard.Text;
            _departemen.Placeholder = "Jurusan";
            stackLayout.Children.Add(_departemen);

            _save = new Button();
            _save.Text = "Sunting";
            _save.Clicked += _save_Clicked;
            stackLayout.Children.Add(_save);

            Content = stackLayout;
        }
    }
}
