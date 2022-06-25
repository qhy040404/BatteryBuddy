using Microsoft.Win32;

namespace BatteryBuddy.Utils
{
    internal class UIUtils
    {
        public static bool IsLightTheme()
        {
            string theme = RegistryUtils.GetKeyValue(Registry.CurrentUser, "Software\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize", false, "SystemUsesLightTheme");
            if (theme.Equals(1))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
