using System;

using Syncfusion.XForms.DataForm;
using Xamarin.Forms;

namespace ScheduleV5
{
    public class DataFormBehaviour : Behavior<SfDataForm>
    {
        public DataFormBehaviour()
        {

        }

        SfDataForm dataForm;

        private void DataForm_AutoGeneratingDataFormItem(object sender, AutoGeneratingDataFormItemEventArgs e)
        {

            if (e.DataFormItem != null && e.DataFormItem.Name == "Date")
            {
                (e.DataFormItem as DataFormDateItem).Format = "ddd, MMM d, yyyy";
            }
        }
    }

}
