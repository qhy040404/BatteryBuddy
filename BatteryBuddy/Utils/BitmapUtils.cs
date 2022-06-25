using BatteryBuddy.Properties;
using System.Drawing;

namespace BatteryBuddy.Utils
{
    internal class BitmapUtils
    {
        public static Bitmap GetBitmap(bool high, bool low, bool critical, bool plug, bool charge, bool light)
        {
            if (light)
            {
                if(high)
                {
                    if (plug)
                    {
                        if (charge)
                        {
                            return Resources.HappyCharging_2x_black;
                        }
                        return Resources.HappyNotCharging_2x_black;
                    }
                    return Resources.Happy_2x_black;
                }
                else if (low)
                {
                    if(plug)
                    {
                        if(charge)
                        {
                            return Resources.NeutralCharging_2x_black;
                        }
                        return Resources.NeutralNotCharging_2x_black;
                    }
                    return Resources.Neutral_2x_black;
                }
                else
                {
                    if (plug)
                    {
                        if(charge)
                        {
                            return Resources.SadCharging_2x_black;
                        }
                        return Resources.SadNotCharging_2x_black;
                    }
                    return Resources.Sad_2x_black;
                }
            }
            else
            {
                if (high)
                {
                    if (plug)
                    {
                        if (charge)
                        {
                            return Resources.HappyCharging_2x_white;
                        }
                        return Resources.HappyNotCharging_2x_white;
                    }
                    return Resources.Happy_2x_white;
                }
                else if (low)
                {
                    if (plug)
                    {
                        if (charge)
                        {
                            return Resources.NeutralCharging_2x_white;
                        }
                        return Resources.NeutralNotCharging_2x_white;
                    }
                    return Resources.Neutral_2x_white;
                }
                else
                {
                    if (plug)
                    {
                        if (charge)
                        {
                            return Resources.SadCharging_2x_white;
                        }
                        return Resources.SadNotCharging_2x_white;
                    }
                    return Resources.Sad_2x_white;
                }
            }
        }
    }
}
