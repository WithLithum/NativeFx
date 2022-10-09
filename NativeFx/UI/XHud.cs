namespace NativeFx.UI;

using GTA.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class XHud
{
    public static void FlashGpsRoute(bool flash)
    {
        Function.Call(Hash.SET_GPS_FLASHES, flash);
    }

    public static void FlashWantedDisplay(bool flash)
    {
        Function.Call(Hash.FLASH_WANTED_DISPLAY, flash);
    }
}
