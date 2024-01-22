using PCConfig.Model.PcPartPicker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCConfig.ViewModel.SideMenu.Tabs.Realizations.GenerationModel
{
    public class SelectionPartViewData
    {
        public int Index { get; set; }

        public PartShortData PartShortData { get; set; }

        public string GetSelectionString 
        {
            get
            {
                int? averagePrice = ((int?)((PartShortData.CitilinkPrice.Price + PartShortData.DNSPrice.Price) / 2));
                int? averageMetric = ((PartShortData.GamingPercentage + PartShortData.DesktopPercentage + PartShortData.WorkstationPercentage) / 2);

                string space = averagePrice.HasValue || averageMetric.HasValue ? ", " : ".";

                string priceString = averagePrice.HasValue ? averagePrice.ToString() + "₽" : string.Empty;
                string metricString = averageMetric.HasValue ? averageMetric.ToString() + "%." : string.Empty;

                string space1 = averagePrice.HasValue && averageMetric.HasValue ? ", " : "";

                return $"{Index}. {PartShortData.Part.Name}{space}{priceString}{space1}{metricString}";
            }
        }
    }
}
