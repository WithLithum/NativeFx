﻿namespace NativeFx.Interop;

using GTA.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal static partial class Natives
{
    internal static void SetPedAiBlipHasCone(int /* Ped */ ped, bool toggle)
    {
        Function.Call(Hash.SET_PED_AI_BLIP_HAS_CONE, ped, toggle);
    }
}
