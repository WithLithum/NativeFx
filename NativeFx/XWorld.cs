/*
 * SPDX-FileCopyrightText: 2022 WithLithum <withlithum@foxmail.com>
 *
 * SPDX-License-Identifier: Apache-2.0
 */

namespace NativeFx;

using GTA.Math;
using NativeFx.Interop;

/// <summary>
/// Provides methods and properties to manipulate the in-game world environment.
/// </summary>
public static class XWorld
{
    /// <summary>
    /// Gets or sets the intensity of the ocean waves (otherwise known as 'deep ocean scaler').
    /// </summary>
    ///<value>
    /// The intensity of the ocean waves. The default value, by most cases, is <c>1.0</c>.
    /// </value>
    public static float OceanWaveIntensity
    {
        get => Natives.GetDeepOceanScaler();
        set => Natives.SetDeepOceanScaler(value);
    }

    /// <summary>
    /// Resets the value of <see cref="OceanWaveIntensity"/> to its default value.
    /// </summary>
    public static void ResetOceanWaveIntensity()
    {
        Natives.ResetDeepOceanScaler();
    }

    /// <summary>
    /// Disables all emissive textures on the world that is considered "artificial".
    /// </summary>
    /// <remarks>
    /// <para>
    ///     A light source or an emissive texture is considered "artificial" if it is not:
    ///     <list type="bullet">
    ///         <item>The sun light and the moon light;</item>
    ///         <item>The torch weapon and the torch component on weapons;</item>
    ///         <item>Fires and explosions;</item>
    ///         <item>Lights and emissive from particles.</item>
    ///     </list>
    /// </para>
    /// </remarks>
    /// <param name="disable">If <see langword="true"/>, all emissive textures considered "artificial" is disabled.</param>
    public static void DisableArtificalLights(bool disable)
    {
        Natives.SetArtificialLightsState(disable);
    }

    /// <summary>
    /// Disables all emissive textures on the world that is considered "artificial".
    /// </summary>
    /// <param name="disable">If <see langword="true"/>, all emissive textures considered "artificial" is disabled.</param>
    /// <param name="affectVehicles">If <see langword="true"/>, vehicles are affected; otherwise, <see langword="false"/>.</param>
    /// <remarks>
    /// <para>
    ///     A light source or an emissive texture is considered "artificial" if it is not:
    ///     <list type="bullet">
    ///         <item>The sun light and the moon light;</item>
    ///         <item>The torch weapon and the torch component on weapons;</item>
    ///         <item>Fires and explosions;</item>
    ///         <item>Lights and emissive from particles.</item>
    ///     </list>
    ///     And, if <paramref name="affectVehicles"/> set to <see langword="false"/>, lights and emissive from vehicles.
    /// </para>
    /// <para>
    /// The difference of this overload is that this uses a new engine feature introduced in build 2060 to allow the caller to ignore
    /// vehicle lights when disabling artificial lights. Hence, calls to this overload requires game build 2060; otherwise, you must use
    /// <see cref="DisableArtificalLights(bool)"/>.
    /// </para>
    /// </remarks>
    public static void DisableArtificalLights(bool disable, bool affectVehicles)
    {
        Natives.SetArtificialLightsState(disable);
        Natives.SetArtificialVehicleLightsState(affectVehicles);
    }

    public static bool TryGetGroundLevel(Vector3 vector, out float result, bool ignoreWater = true)
    {
        bool success;
        float x = 0f;

        unsafe
        {
            success = Natives.GetGroundZFor3dCoord(vector.X, vector.Y, vector.Z, ref x, ignoreWater, false);
        }

        result = x;
        return success;
    }

    /// <summary>
    /// Summons a lightning flash at a random position.
    /// </summary>
    /// <remarks>
    /// Lightning flash never appears in the world; they are just visual effects shown on the
    /// sky-box.
    /// </remarks>
    public static void SummonLightning()
    {
        Natives.ForceLightningFlash();
    }

    /// <summary>
    /// Populates the world immediately.
    /// </summary>
    /// <remarks>
    /// This methods causes the game engine to spawn random NPCs, vehicles and animals in the world
    /// outside player view, given the case applies.
    /// </remarks>
    public static void Populate()
    {
        Natives.PopulateNow();
    }

    /// <summary>
    /// Modifies the height of the water within the specified radius from the specified centre position.
    /// </summary>
    /// <param name="centre">The centre point of the area to modify the water height.</param>
    /// <param name="radius">The radius of the area to modify the water height.</param>
    /// <param name="height">The water height to set.</param>
    public static void ModifyWaterHeight(Vector2 centre, float radius, float height)
    {
        Natives.ModifyWater(centre.X, centre.Y, height, radius);
    }

    public static void SetSnowLevel(float level)
    {
        Natives.SetSnow(level);
    }

    /// <summary>
    /// Overrides the water strength/intensity around the local player.
    /// </summary>
    /// <param name="intensity">The intensity. At <c>1.0f</c>, the water is calm; at <c>3.0f</c>, the water is extremely intensified.</param>
    public static void OverrideWaterStrength(float intensity)
    {
        Natives.WaterOverrideSetStrength(intensity);
    }

    public static bool IsAnyCopVehicleInArea(Vector3 corner1, Vector3 corner2)
    {
        return Natives.IsCopVehicleInArea3d(corner1.X, corner2.X, corner1.Y, corner2.Y, corner1.Z, corner2.Z);
    }


}
