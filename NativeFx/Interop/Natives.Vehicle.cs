namespace NativeFx.Interop;

using GTA.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal static partial class Natives
{
    internal static bool DoesVehicleHaveSearchlight(int /* Vehicle */ vehicle)
    {
        return Function.Call<bool>(Hash._DOES_VEHICLE_HAVE_SEARCHLIGHT, vehicle);
    }
}
