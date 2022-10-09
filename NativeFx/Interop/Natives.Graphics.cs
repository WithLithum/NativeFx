namespace NativeFx.Interop;

using GTA.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal static partial class Natives
{
    internal static void SetArtificialLightsState(bool state)
    {
        Function.Call(Hash.SET_ARTIFICIAL_LIGHTS_STATE, state);
    }

    internal static void SetArtificialLightsStateAffectsVehicles(bool toggle)
    {
        Function.Call(Hash._SET_ARTIFICIAL_LIGHTS_STATE_AFFECTS_VEHICLES, toggle);
    }
}
