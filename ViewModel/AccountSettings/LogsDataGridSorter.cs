using PCConfig.Model.UsersData;
using System.Collections;
using System.ComponentModel;

namespace PCConfig.ViewModel.AccountSettings
{
    public class LogsDataGridSorter
    {
        private List<LogView> _data;

        public LogsDataGridSorter(IEnumerable<LogView> data)
        {
            _data = new List<LogView>(data);
        }

        public List<LogView> Sort(string propertyName, ListSortDirection sortDirection)
        {
            switch (propertyName)
            {
                case "GridNumber":
                    _data = SortGridNumberColumn(_data, sortDirection);
                    break;
                case "Log.Name":
                    _data = SortNameColumn(_data, sortDirection);
                    break;
                case "Log.DateTime":
                    _data = SortDateTimeColumn(_data, sortDirection);
                    break;
                case "Log.City":
                    _data = SortCityColumn(_data, sortDirection);
                    break;
                case "Log.CountryCode":
                    _data = SortCountryCodeColumn(_data, sortDirection);
                    break;
                case "Log.Timezone":
                    _data = SortTimeZoneColumn(_data, sortDirection);
                    break;
                case "Log.IpAddress":
                    _data = SortIpAddressColumn(_data, sortDirection);
                    break;
            }

            return _data;
        }

        private List<LogView> SortDateTimeColumn(List<LogView> list, ListSortDirection direction)
        {
            List<LogView> sortedList = [];

            sortedList = direction == ListSortDirection.Descending
                ? list.OrderByDescending(item => item.Log.DateTime).ToList()
                : list.OrderBy(item => item.Log.DateTime).ToList();

            return sortedList;
        }

        private List<LogView> SortNameColumn(List<LogView> list, ListSortDirection direction)
        {
            List<LogView> sortedList = [];

            sortedList = direction == ListSortDirection.Descending
                ? list.OrderByDescending(item => item.Log.Name).ToList()
                : list.OrderBy(item => item.Log.Name).ToList();

            return sortedList;
        }

        private List<LogView> SortGridNumberColumn(List<LogView> list, ListSortDirection direction)
        {
            List<LogView> sortedList = [];

            sortedList = direction == ListSortDirection.Descending
                ? list.OrderByDescending(item => item.Log.Id).ToList()
                : list.OrderBy(item => item.Log.Id).ToList();

            return sortedList;
        }

        private List<LogView> SortCityColumn(List<LogView> list, ListSortDirection direction)
        {
            List<LogView> sortedList = [];

            sortedList = direction == ListSortDirection.Descending
                ? list.OrderByDescending(item => item.Log.City).ToList()
                : list.OrderBy(item => item.Log.City).ToList();

            return sortedList;
        }

        private List<LogView> SortCountryCodeColumn(List<LogView> list, ListSortDirection direction)
        {
            List<LogView> sortedList = [];

            sortedList = direction == ListSortDirection.Descending
                ? list.OrderByDescending(item => item.Log.CountryCode).ToList()
                : list.OrderBy(item => item.Log.CountryCode).ToList();

            return sortedList;
        }

        private List<LogView> SortTimeZoneColumn(List<LogView> list, ListSortDirection direction)
        {
            List<LogView> sortedList = [];

            sortedList = direction == ListSortDirection.Descending
                ? list.OrderByDescending(item => item.Log.TimeZone).ToList()
                : list.OrderBy(item => item.Log.TimeZone).ToList();

            return sortedList;
        }

        private List<LogView> SortIpAddressColumn(List<LogView> list, ListSortDirection direction)
        {
            List<LogView> sortedList = [];

            sortedList = direction == ListSortDirection.Descending
                ? list.OrderByDescending(item => item.Log.IpAddress).ToList()
                : list.OrderBy(item => item.Log.IpAddress).ToList();

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
