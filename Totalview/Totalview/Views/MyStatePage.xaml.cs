using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Totalview.View
{
    public partial class MyStatePage : INotifyPropertyChanged

    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.DataDummy.GetUserAsync();
        }

        public MyStatePage()
        {
            InitializeComponent();
        }

        async void OnButtonClicked(object sender, EventArgs e)
        {
            listView.ItemsSource = await App.DataDummy.GetUserAsync();
        }

    }
}