using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ScheduleV5
{
    public partial class TaskItemPage : ContentPage
    {
        public TaskItemPage()
        {
            InitializeComponent();
        }

        async void OnSaveClicked(object sender, EventArgs e)
        {
            var task = (TaskItem)BindingContext;
            await App.Database.SaveItemAsync(task);
            await Navigation.PopAsync();
        }

        async void OnDeleteClicked (object sender, EventArgs e)
        {
            var task = (TaskItem)BindingContext;
            await App.Database.DeleteItemAsync(task);
            await Navigation.PopAsync();
        }

        async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
