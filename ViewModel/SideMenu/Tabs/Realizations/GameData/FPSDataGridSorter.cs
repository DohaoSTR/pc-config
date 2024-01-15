using PCConfig.Model.UsersData;
using PCConfig.ViewModel.AccountSettings;
using System.Collections;
using System.ComponentModel;

namespace PCConfig.ViewModel.SideMenu.Tabs.Realizations.GameData
{
    public class FPSDataGridSorter
    {
        private List<FPSDataView> _data;

        public FPSDataGridSorter(IEnumerable<FPSDataView> data)
        {
            _data = new List<FPSDataView>(data);
        }

        public List<FPSDataView> Sort(string propertyName, ListSortDirection sortDirection)
        {
            switch (propertyName)
            {
                case "GridNumber":
                    _data = SortGridNumberColumn(_data, sortDirection);
                    break;
                case "FPSData.FPS":
                    _data = SortFPSColumn(_data, sortDirection);
                    break;
                case "FPSData.Samples":
                    _data = SortSamplesColumn(_data, sortDirection);
                    break;
                case "FPSData.Resolution":
                    _data = SortResolutionColumn(_data, sortDirection);
                    break;
                case "FPSData.GameSettings":
                    _data = SortGameSettingsColumn(_data, sortDirection);
                    break;
                case "FPSData.CPUModel":
                    _data = SortCPUModelColumn(_data, sortDirection);
                    break;
                case "FPSData.GPUModel":
                    _data = SortGPUModelColumn(_data, sortDirection);
                    break;
            }

            return _data;
        }

        private List<FPSDataView> SortGridNumberColumn(List<FPSDataView> list, ListSortDirection direction)
        {
            List<FPSDataView> sortedList = [];

            sortedList = direction == ListSortDirection.Descending
                ? list.OrderByDescending(item => item.GridNumber).ToList()
                : list.OrderBy(item => item.GridNumber).ToList();

            return sortedList;
        }

        private List<FPSDataView> SortFPSColumn(List<FPSDataView> list, ListSortDirection direction)
        {
            List<FPSDataView> sortedList = [];

            sortedList = direction == ListSortDirection.Descending
                ? list.OrderByDescending(item => item.FPSData.FPS).ToList()
                : list.OrderBy(item => item.FPSData.FPS).ToList();

            return sortedList;
        }

        private List<FPSDataView> SortSamplesColumn(List<FPSDataView> list, ListSortDirection direction)
        {
            List<FPSDataView> sortedList = [];

            sortedList = direction == ListSortDirection.Descending
                ? list.OrderByDescending(item => item.FPSData.Samples).ToList()
                : list.OrderBy(item => item.FPSData.Samples).ToList();

            return sortedList;
        }

        private List<FPSDataView> SortResolutionColumn(List<FPSDataView> list, ListSortDirection direction)
        {
            List<FPSDataView> sortedList = [];

            sortedList = direction == ListSortDirection.Descending
                ? list.OrderByDescending(item => item.FPSData.Resolution).ToList()
                : list.OrderBy(item => item.FPSData.Resolution).ToList();

            return sortedList;
        }

        private List<FPSDataView> SortGameSettingsColumn(List<FPSDataView> list, ListSortDirection direction)
        {
            List<FPSDataView> sortedList = [];

            sortedList = direction == ListSortDirection.Descending
                ? list.OrderByDescending(item => item.FPSData.GameSettings).ToList()
                : list.OrderBy(item => item.FPSData.GameSettings).ToList();

            return sortedList;
        }

        private List<FPSDataView> SortCPUModelColumn(List<FPSDataView> list, ListSortDirection direction)
        {
            List<FPSDataView> sortedList = [];

            sortedList = direction == ListSortDirection.Descending
                ? list.OrderByDescending(item => item.FPSData.CPUModel).ToList()
                : list.OrderBy(item => item.FPSData.CPUModel).ToList();

            return sortedList;
        }

        private List<FPSDataView> SortGPUModelColumn(List<FPSDataView> list, ListSortDirection direction)
        {
            List<FPSDataView> sortedList = [];

            sortedList = direction == ListSortDirection.Descending
                ? list.OrderByDescending(item => item.FPSData.GPUModel).ToList()
                : list.OrderBy(item => item.FPSData.GPUModel).ToList();

            return sortedList;
        }

        private int Compare(LogView x, LogView y, string propertyName, ListSortDirection sortDirection)
        {
            System.Reflection.PropertyInfo? propertyInfo = typeof(Log).GetProperty(propertyName);
            object? valueX = propertyInfo?.GetValue(x, null);
            object? valueY = propertyInfo?.GetValue(y, null);

            if (valueX == null && valueY == null)
            {
                return 0;
            }
            if (valueX == null)
            {
                return sortDirection == ListSortDirection.Descending ? -1 : 1;
            }
            if (valueY == null)
            {
                return sortDirection == ListSortDirection.Descending ? 1 : -1;
            }

            int result = Comparer.Default.Compare(valueX, valueY);

            return sortDirection == ListSortDirection.Descending ? result : -result;
        }
    }
}
