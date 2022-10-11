namespace NativeFx.Interop;

using GTA.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal static partial class Natives
{
    internal static bool IsCutscenePlaying()
    {
        return Function.Call<bool>(Hash.IS_CUTSCENE_PLAYING);
    }

    internal static void RemoveCutscene()
    {
        Function.Call(Hash.REMOVE_CUTSCENE);
    }
}
