using Newtonsoft.Json;
using System.Net;

namespace PCConfig.Model.Access
{
    public static class IpDataManager
    {
        public static string GetPublicIpAddress()
        {
            using WebClient client = new();
            return client.DownloadString("https://api64.ipify.org");
        }

        public static string GetGeoLocationInfo(string ipAddress)
        {
            using WebClient client = new();
            return client.DownloadString($"https://ipinfo.io/{ipAddress}");
        }

        public static IpInfo ConvertStringToIpInfo(string ipInfoString)
        {
            return JsonConvert.DeserializeObject<IpInfo>(ipInfoString);
        }

        public static IpInfo GetAllUserData()
        {
            string ipAddress = GetPublicIpAddress();
            string ipInfoString = GetGeoLocationInfo(ipAddress);

            return ConvertStringToIpInfo(ipInfoString);
        }
    }
}
