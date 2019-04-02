using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ScheduleV5
{
    public partial class AppointmentAddPage : ContentPage
    {
        public AppointmentAddPage()
        {
            InitializeComponent();

            var nameEntry = new Entry();
            nameEntry.SetBinding(Entry.TextProperty, "Name");

            var notesEntry = new Entry();
            notesEntry.SetBinding(Entry.TextProperty, "Notes");

            var alldaySwitch = new Switch();
            alldaySwitch.SetBinding(Switch.IsToggledProperty, "All Day");

            var saveButton = new Button { Text = "Save" };
            saveButton.Clicked += async (sender, e) =>
            {
                var appointments = (Appointments)BindingContext;
                await App.Database.SaveItemAsync(appointments);
                await Navigation.PopAsync();
            };

            var deleteButton = new Button { Text = "Delete" };
            deleteButton.Clicked += async (sender, e) =>
            {
                var appointments = (Appointments)BindingContext;
                await App.Database.DeleteItemAsync(appointments);
                await Navigation.PopAsync();
            };

            var cancelButton = new Button { Text = "Cancel" };
            cancelButton.Clicked += async (sender, e) =>
            {
                await Navigation.PopAsync();
            };

            Content = new StackLayout
            {
                Margin = new Thickness(20),
                VerticalOptions = LayoutOptions.StartAndExpand,
                Children =
                {
                    new Label { Text = "Name" },
                    nameEntry,
                    new Label { Text = "Notes" },
                    notesEntry,
                    new Label { Text = "All Day" },
                    alldaySwitch,
                    saveButton,
                    deleteButton,
                    cancelButton
                }
            };
        }
    }
}
