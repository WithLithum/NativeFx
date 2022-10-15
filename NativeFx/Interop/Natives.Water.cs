namespace NativeFx.Interop;

using GTA.Native;

internal static partial class Natives
{
    internal static float GetDeepOceanScaler()
    {
        return Function.Call<float>(Hash.GET_DEEP_OCEAN_SCALER);
    }

    internal static void SetDeepOceanScaler(float intensity)
    {
        Function.Call(Hash.SET_DEEP_OCEAN_SCALER, intensity);
    }

    internal static void ResetDeepOceanScaler()
    {
        Function.Call(Hash.RESET_DEEP_OCEAN_SCALER);
    }

    internal static void ModifyWater(float x, float y, float height, float radius)
    {
        Function.Call(Hash.MODIFY_WATER, x, y, height, radius);
    }
}
