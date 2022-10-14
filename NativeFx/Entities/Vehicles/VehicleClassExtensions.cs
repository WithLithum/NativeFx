namespace NativeFx.Entities.Vehicles;

using GTA;
using NativeFx.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Provides extension methods for vehicle classes.
/// </summary>
public static class VehicleClassExtensions
{
    /// <summary>
    /// Determines the estimated maximum speed of this vehicle class.
    /// </summary>
    /// <param name="c">The class to determine.</param>
    /// <returns>The estimated maximum speed.</returns>
    public static float EstimatedMaxSpeed(this VehicleClass c)
    {
        return Natives.GetVehicleClassEstimatedMaxSpeed((int)c);
    }
}
