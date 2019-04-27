using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Content;

namespace ScheduleV5.Droid
{
    [Activity(Label = "ScheduleV5", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public Appointments appointments;
        EditText _eventName;
        EditText _from;
        EditText _To;
        Button _saveButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Nzc0NjNAMzEzNjJlMzQyZTMwQndZaGU5Rk1TdS9DSmpMWmY4eEkrZEZVeXdxRHExNDloaUhlU0k5RVlDcz0=");

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }

        /*#region SaveDetails
        void SaveRecords (Object sender, EventArgs eventArgs)
        {
            appointments.EventName = _eventName.Text;

            if (Validate())
            {
                DateTime currentDt = DateTime.Now;
                DateTime selectedDt = Convert.ToDateTime(appointments.From + " " + appointments.To);

                if (selectedDt > currentDt)
                {
                    ScheduleHelper.InsertScheduleData(this, appointments);
                    var appointmentAdded = new Intent(this, typeof(AppointmentAdded )) //appointment added is the class that handles the addition of an appointment but i couldnt find the part that handles that so it needs replacing 
                }
            }
        }
        #endregion

        bool Validate()
        {
            if (appointments.From.ToLongDateString() == string.Empty || appointments.To.ToLongDateString() == string.Empty || appointments.EventName == string.Empty)
            {
                Toast.MakeText(this, "Enter the details for all fields", ToastLength.Short).Show();
            }
        }*/
    }
}