﻿using PCConfig.Model.Contexts;
using PCConfig.View.Tabs.Products;
using PCConfig.ViewModel.SideMenu.Tabs.Realizations.Products;
using System.Windows.Controls;

namespace PCConfig.ViewModel.SideMenu.Tabs.Strategies
{
    public class GPUTabStrategy : ITabStrategy
    {
        public event Action<ProductsListItemViewModel> ProductItemClicked;

        public Control HandleTab(SideMenuItemViewModel item)
        {
            PCPartPickerContext context = new PCPartPickerContext();

            string partType = "video-card";
            var parts = context.GetGPUShortData();

            ProductControl control = new ProductControl(partType, parts);
            control.ProductClicked += ProductItemClicked;

            return control;
        }
    }
}
