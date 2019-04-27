using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ScheduleV5
{
    public partial class TaskListPage : ContentPage
    {
        public TaskListPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            //shows the previously saved state of the list 
            ((App)App.Current).ResumeAtTaskId = -1;
            listView.ItemsSource = await App.Database.GetItemAsync();
        }

        async void OnItemAdded(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TaskItemPage
            {
                BindingContext = new TaskItem()
            });
        }

        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new TaskItemPage
                {
                    BindingContext = e.SelectedItem as TaskItem
                });
            }
        }
    }
}
