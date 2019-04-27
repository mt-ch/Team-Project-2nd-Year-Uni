using System;

using Xamarin.Forms;

namespace ScheduleV5
{
    public class TaskItemPageContent : ContentPage
    {
        public TaskItemPageContent()
        {
            Title = "Task Item";

            var taskEntry = new Entry();
            taskEntry.SetBinding(Entry.TextProperty, "Task");

            var notesEntry = new Entry();
            notesEntry.SetBinding(Entry.TextProperty, "Notes");

            var doneSwitch = new Switch();
            doneSwitch.SetBinding(Switch.IsToggledProperty, "Done");

            var saveButton = new Button { Text = "Save" };
            saveButton.Clicked += async (sender, e) =>
            {
                var taskItem = (TaskItem)BindingContext;
                await App.Database.SaveItemAsync(taskItem);
                await Navigation.PopAsync();
            };

            var deleteButton = new Button { Text = "Delete" };
            deleteButton.Clicked += async (sender, e) =>
            {
                var taskItem = (TaskItem)BindingContext;
                await App.Database.DeleteItemAsync(taskItem);
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
                    new Label { Text = "Name"},
                    taskEntry,
                    new Label { Text = "Notes"},
                    notesEntry,
                    new Label { Text = "Done"},
                    doneSwitch,
                    saveButton,
                    deleteButton,
                    cancelButton

                }
            };
        }
    }
}

