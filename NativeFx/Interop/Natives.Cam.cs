﻿namespace NativeFx.Interop;

using GTA.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal static partial class Natives
{
    internal static void SetGameplayCamRelativePitch(float angle, float scalingFactor)
    {
        Function.Call(Hash.SET_GAMEPLAY_CAM_RELATIVE_PITCH, angle, scalingFactor);
    }

    internal static float GetGameplayCamRelativePitch()
    {
        return Function.Call<float>(Hash.GET_GAMEPLAY_CAM_RELATIVE_PITCH);
    }
}
