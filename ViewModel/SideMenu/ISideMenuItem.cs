namespace PCConfig.ViewModel.SideMenu
{
    public interface ISideMenuItem
    {
        string Kind { get; set; }

        string Text { get; set; }

        bool IsSelected { get; set; }
    }
}
