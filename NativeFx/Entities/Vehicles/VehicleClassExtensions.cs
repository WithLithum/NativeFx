/*
 * SPDX-FileCopyrightText: 2022 WithLithum <withlithum@foxmail.com>
 *
 * SPDX-License-Identifier: Apache-2.0
 */
namespace NativeFx.Entities.Vehicles;

using GTA;
using NativeFx.Interop;

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
