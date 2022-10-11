namespace NativeFx.Interop;

using GTA.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal static partial class Natives
{
    internal static bool NetworkIsHostOfThisScript()
    {
        return Function.Call<bool>(Hash.NETWORK_IS_HOST_OF_THIS_SCRIPT);
    }
}
