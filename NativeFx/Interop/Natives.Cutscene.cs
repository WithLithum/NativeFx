namespace NativeFx.Interop;

using GTA.Native;

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
