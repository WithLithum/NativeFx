namespace NativeFx.Interop;

using GTA.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal static partial class Natives
{
    internal static void SetPedComponentVariation(int /* Ped */ ped, int componentId, int drawableId, int textureId, int paletteId)
    {
        Function.Call(Hash.SET_PED_COMPONENT_VARIATION, ped, componentId, drawableId, textureId, paletteId);
    }

    internal static bool IsPedFacingPed(int /* Ped */ ped, int /* Ped */ otherPed, float angle)
    {
        return Function.Call<bool>(Hash.IS_PED_FACING_PED, ped, otherPed, angle);
    }

    internal static bool CanPedSpeak(int /* Ped */ ped, string speechName, bool unk)
    {
        return Function.Call<bool>(Hash._CAN_PED_SPEAK, ped, speechName, unk);
    }

    internal static bool IsPedInAnyTaxi(int /* Ped */ ped)
    {
        return Function.Call<bool>(Hash.IS_PED_IN_ANY_TAXI, ped);
    }

    internal static bool IsPedComponentVariationValid(int /* Ped */ ped, int componentId, int drawableId, int textureId)
    {
        return Function.Call<bool>(Hash.IS_PED_COMPONENT_VARIATION_VALID, ped, componentId, drawableId, textureId);
    }
}
