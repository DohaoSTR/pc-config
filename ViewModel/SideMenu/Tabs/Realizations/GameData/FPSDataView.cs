using PCConfig.Model.UserBenchmark;

namespace PCConfig.ViewModel.SideMenu.Tabs.Realizations.GameData
{
    public class FPSDataView
    {
        public FPSDataWithModels FPSData { get; set; }

        public int GridNumber { get; set; }

        public FPSDataView(FPSDataWithModels fPSData, int gridNumber)
        {
            FPSData = fPSData;
            GridNumber = gridNumber;
        }
    }
}
