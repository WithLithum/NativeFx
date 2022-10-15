namespace NativeFx.Interop;

using GTA.Native;

internal static partial class Natives
{
    internal static bool NetworkIsHostOfThisScript()
    {
        return Function.Call<bool>(Hash.NETWORK_IS_HOST_OF_THIS_SCRIPT);
    }
}
