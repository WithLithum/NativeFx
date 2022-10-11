namespace NativeFx.Interop;

using GTA.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal static partial class Natives
{
    internal static void PauseDeathArrestRestart(bool toggle)
    {
        Function.Call(Hash.PAUSE_DEATH_ARREST_RESTART, toggle);
    }

    internal static unsafe bool GetGroundZFor_3dCoord(float x, float y, float z, ref float groundZ, bool ignoreWater)
    {
        var xz = groundZ;

        var result = Function.Call<bool>(Hash.GET_GROUND_Z_FOR_3D_COORD, x, y, z, &xz, ignoreWater);

        groundZ = xz;
        return result;
    }
}
