using Microsoft.Win32;

namespace BatteryBuddy.Utils
{
    internal class RegistryUtils
    {
        public static string GetKeyValue(RegistryKey rkey, string subkey, bool modifiability, string valueKey)
        {
            RegistryKey rk = rkey;
            RegistryKey detailedRK = rk.OpenSubKey(@subkey, modifiability);
            string returnData = detailedRK.GetValue(valueKey).ToString();
            detailedRK.Close();
            rk.Close();
            return returnData;
        }
    }
}
