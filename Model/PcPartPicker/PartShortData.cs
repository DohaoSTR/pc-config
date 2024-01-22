using PCConfig.Model.PcPartPicker.Entities;
using PCConfig.Model.Prices.Citilink;
using PCConfig.Model.Prices.DNS;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Media.Imaging;

namespace PCConfig.Model.PcPartPicker
{
    public class PartShortData
    {
        public Part? Part { get; set; }

        public PartViewData? PartViewData { get; set; }

        public IEnumerable<ShortSpecification>? Specifications { get; set; }

        public IEnumerable<string>? ImagesUrls { get; set; }


        public DNSAvailable DNSAvailable { get; set; }

        public DNSPrice DNSPrice { get; set; }

        public CitilinkAvailable CitilinkAvailable { get; set; }

        public CitilinkPrice CitilinkPrice { get; set; }

        public string? CitilinkLink { get; set; }

        public string? DNSLink { get; set; }


        public int? GamingPercentage { get; set; }

        public int? DesktopPercentage { get; set; }

        public int? WorkstationPercentage { get; set; }

        public BitmapImage ImageSource
        {
            get
            {
                if (ImagesUrls?.Count() == 0 || ImagesUrls == null)
                {
                    string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;

                    DirectoryInfo parentDirectory = Directory.GetParent(currentDirectory).Parent.Parent.Parent;

                    string parentPath = parentDirectory.FullName;
                    string relativePath = Path.Combine(parentPath, "product_without_image.jpg");
                    string filePath = Path.Combine(currentDirectory, relativePath);

                    Uri imageUri = new(filePath, UriKind.Absolute);
                    BitmapImage bitmapImage = new(imageUri);

                    return bitmapImage;
                }
                else
                {
                    return Images[0];
                }
            }
        }

        public ObservableCollection<BitmapImage> Images
        {
            get
            {
                ObservableCollection<BitmapImage> list = [];
                foreach (string url in ImagesUrls)
                {
                    try
                    {
                        Uri imageUri = new(url, UriKind.Absolute);
                        BitmapImage bitmapImage = new(imageUri);
                        list.Add(bitmapImage);
                    }
                    catch (UriFormatException) { }
                }

                return list;
            }
        }
    }
}
