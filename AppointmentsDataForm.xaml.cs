using System;
using System.Collections.Generic;
using Syncfusion.XForms.DataForm;
using Syncfusion.XForms.Buttons;


using Xamarin.Forms;

namespace ScheduleV5
{
    public partial class AppointmentsDataForm : ContentPage
    {


        public AppointmentsDataForm()
        {
            InitializeComponent();


            dataForm.AutoGeneratingDataFormItem += DataForm_AutoGeneratingDataFormItem;


        }

        private void DataForm_AutoGeneratingDataFormItem(object sender, AutoGeneratingDataFormItemEventArgs e)
        {
            if (e.DataFormItem != null && e.DataFormItem.Name == "StartDate")
            {
                (e.DataFormItem as DataFormDateItem).Format = "ddd, MMM d, yyyy";
                (e.DataFormItem as DataFormDateItem).MinimumDate = DateTime.Now;
            }
            
            if (e.DataFormItem != null && e.DataFormItem.Name == "EndDate")
            {
                (e.DataFormItem as DataFormDateItem).Format = "ddd, MMM d, yyyy";
                (e.DataFormItem as DataFormDateItem).MinimumDate = DateTime.Now;
            }

            if (e.DataFormItem != null && e.DataFormItem.Name == "StartTime")
            {
                (e.DataFormItem as DataFormTimeItem).Format = "HH:mm";
            }

            if (e.DataFormItem != null && e.DataFormItem.Name == "EndTime")
            {
                (e.DataFormItem as DataFormTimeItem).Format = "HH:mm";
            }

        }
    }
}
