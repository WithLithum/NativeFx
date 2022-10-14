namespace NativeFx.UI;

using GTA.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Provides utilities to manipulate HUD.
/// </summary>
public static class XHud
{
    /// <summary>
    /// Flashes the GPS route.
    /// </summary>
    /// <param name="flash">If <see langword="true"/>, the GPS route is flashed.</param>
    public static void FlashGpsRoute(bool flash)
    {
        Function.Call(Hash.SET_GPS_FLASHES, flash);
    }

    public static void FlashWantedDisplay(bool flash)
    {
        Function.Call(Hash.FLASH_WANTED_DISPLAY, flash);
    }
}
