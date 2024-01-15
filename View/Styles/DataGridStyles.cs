using System.Windows.Controls;
using System.Windows.Input;

namespace PCConfig.View.Styles
{
    public partial class DataGridStyles
    {
        private void DataGridRow_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is DataGridRow row)
            {
                row.IsSelected = true;
                e.Handled = true;
            }
        }
    }
}
