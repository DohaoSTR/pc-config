using PCConfig.Model.UsersData;

namespace PCConfig.ViewModel.AccountSettings
{
    public class LogView
    {
        public Log Log { get; set; }

        public int GridNumber { get; set; }

        public LogView(Log log, int gridNumber)
        {
            Log = log;
            GridNumber = gridNumber;
        }
    }
}
