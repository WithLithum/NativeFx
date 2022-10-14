namespace NativeFx.Interop;

using GTA.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal static partial class Natives
{
    internal static void SetEntityHasGravity(int /* Entity */ entity, bool toggle)
    {
        Function.Call(Hash.SET_ENTITY_HAS_GRAVITY, entity, toggle);
    }

    internal static int GetEntityMaxHealth(int /* Entity */ entity)
    {
        return Function.Call<int>(Hash.GET_ENTITY_MAX_HEALTH, entity);
    }

    internal static void SetEntityMaxHealth(int /* Entity */ entity, int value)
    {
        Function.Call(Hash.SET_ENTITY_MAX_HEALTH, entity, value);
    }

    internal static bool IsEntityAttachedToAnyVehicle(int /* Entity */ entity)
    {
        return Function.Call<bool>(Hash.IS_ENTITY_ATTACHED_TO_ANY_VEHICLE, entity);
    }

    internal static bool IsEntityInWater(int /* Entity */ entity)
    {
        return Function.Call<bool>(Hash.IS_ENTITY_IN_WATER, entity);
    }

    internal static void FreezeEntityPosition(int /* Entity */ entity, bool freeze)
    {
        Function.Call(Hash.FREEZE_ENTITY_POSITION, entity, freeze);
    }

    internal static bool DoesEntityHaveDrawable(int /* Entity */ entity)
    {
        return Function.Call<bool>(Hash.DOES_ENTITY_HAVE_DRAWABLE, entity);
    }

    internal static float GetEntityHeading(int /* Entity */ entity)
    {
        return Function.Call<float>(Hash.GET_ENTITY_HEADING, entity);
    }

    internal static void SetEntityHeading(int entity, float heading)
    {
        Function.Call(Hash.SET_ENTITY_HEADING, entity, heading);
    }

    internal static bool DoesEntityHavePhysics(int /* Entity */ entity)
    {
        return Function.Call<bool>(Hash.DOES_ENTITY_HAVE_PHYSICS, entity);
    }
}
