namespace NativeFx.Interop;

using GTA.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal static partial class Natives
{
    internal static bool DoesVehicleHaveSearchlight(int /* Vehicle */ vehicle)
    {
        return Function.Call<bool>(Hash._DOES_VEHICLE_HAVE_SEARCHLIGHT, vehicle);
    }

    internal static bool ArePlaneWingsIntact(int /* Vehicle */ plane)
    {
        return Function.Call<bool>(Hash._ARE_PLANE_WINGS_INTACT, plane);
    }

    internal static int GetVehicleBombCount(int /* Vehicle */ aircraft)
    {
        return Function.Call<int>(Hash._GET_VEHICLE_BOMB_COUNT, aircraft);
    }

    internal static void SetVehicleBombCount(int /* Vehicle */ aircraft, int bombCount)
    {
        Function.Call(Hash._SET_VEHICLE_BOMB_COUNT, aircraft, bombCount);
    }

    internal static void SetVehicleCanBeUsedByFleeingPeds(int /* Vehicle */ vehicle, bool toggle)
    {
        Function.Call(Hash.SET_VEHICLE_CAN_BE_USED_BY_FLEEING_PEDS, vehicle, toggle);
    }

    internal static void SetVehicleControlsInverted(int /* Vehicle */ vehicle, bool state)
    {
        Function.Call(Hash._SET_VEHICLE_CONTROLS_INVERTED, vehicle, state);
    }

    internal static void SetVehicleWheelsDealDamage(int /* Vehicle */ vehicle, bool toggle)
    {
        Function.Call(Hash._SET_VEHICLE_WHEELS_DEAL_DAMAGE, vehicle, toggle);
    }

    internal static void TriggerSiren(int /* Vehicle */ vehicle)
    {
        Function.Call(Hash._TRIGGER_SIREN, vehicle);
    }
}
