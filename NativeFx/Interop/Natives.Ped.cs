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

    internal static void SetPedSeeingRange(int ped, float range)
    {
        Function.Call(Hash.SET_PED_SEEING_RANGE, ped, range);
    }

    internal static void SetPedCanBeKnockedOffVehicle(int /* Ped */ ped, int state)
    {
        Function.Call(Hash.SET_PED_CAN_BE_KNOCKED_OFF_VEHICLE, ped, state);
    }

    internal static void SetPedHearingRange(int ped, float range)
    {
        Function.Call(Hash.SET_PED_HEARING_RANGE, ped, range);
    }

    internal static bool IsPedInjured(int ped)
    {
        return Function.Call<bool>(Hash.IS_PED_INJURED, ped);
    }

    internal static void SetPedTargetLossResponse(int ped, int responseType)
    {
        Function.Call(Hash.SET_PED_TARGET_LOSS_RESPONSE, ped, responseType);
    }

    internal static bool IsPedFacingPed(int /* Ped */ ped, int /* Ped */ otherPed, float angle)
    {
        return Function.Call<bool>(Hash.IS_PED_FACING_PED, ped, otherPed, angle);
    }

    internal static bool IsPedInFlyingVehicle(int ped)
    {
        return Function.Call<bool>(Hash.IS_PED_IN_FLYING_VEHICLE, ped);
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
