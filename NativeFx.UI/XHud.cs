/*
 * SPDX-FileCopyrightText: 2022 WithLithum <withlithum@foxmail.com>
 *
 * SPDX-License-Identifier: Apache-2.0
 */

namespace NativeFx.UI;

using GTA;
using GTA.Math;
using GTA.UI;
using System.Drawing;

public static class XHud
{
    private static Blip _mainBlip;

    public static bool FakeSpectatorMode
    {
        get => Natives.GetFakeSpectatorMode();
        set => Natives.SetFakeSpectatorMode(value);
    }

    public static Blip MainPlayerBlip
    {
        get
        {
            var id = Natives.GetMainPlayerBlipId();

            if (_mainBlip != null && _mainBlip.Exists() && id == _mainBlip.Handle)
            {
                return _mainBlip;
            }
            else
            {
                _mainBlip = new Blip(id);
                return _mainBlip;
            }
        }
    }

    /// <summary>
    /// Gets the amount of blips currently active.
    /// </summary>
    /// <returns>The amount of blips currently active.</returns>
    public static int CountActiveBlips()
    {
        return Natives.GetNumberOfActiveBlips();
    }

    /// <summary>
    /// Creates an instance of <see cref="Color"/> class which represents the current colour value of the specified
    /// HUD colour.
    /// </summary>
    /// <param name="hudId">The ID of the HUD colour. The ID is a zero-based index of the colour in <c>hudcolor.dat</c>.</param>
    /// <returns>An instance of <see cref="Color"/> class which represents the current colour value of the specified
    /// HUD colour.</returns>
    public static Color GetColour(int hudId)
    {
        int r = 0, g = 0, b = 0, a = 0;

        Natives.GetHudColour(hudId, ref r, ref g, ref b, ref a);
        return Color.FromArgb(a, r, g, b);
    }

    public static PointF GetComponentPosition(HudComponent component)
    {
        var vector = Natives.GetHudComponentPosition((int)component);
        return new PointF(vector.X, vector.Y);
    }

    /// <summary>
    /// Determines whether the specified position is revealed on the map (not occluded by Fog of War).
    /// </summary>
    /// <param name="position">The position to determine.</param>
    /// <returns><see langword="true"/> if the specified position is not occluded by Fog of War; otherwise, <see langword="false"/>.</returns>
    public static bool IsPositionRevealed(Vector3 position)
    {
        return Natives.GetMinimapFowCoordinateIsRevealed(position.X, position.Y, position.Z);
    }

    /// <summary>
    /// Sets a fake player position in the pause map for the current tick.
    /// </summary>
    /// <param name="vector">The position.</param>
    public static void OverridePauseMapPlayerPosition(Vector2 vector)
    {
        Natives.SetFakePausemapPlayerPositionThisFrame(vector.X, vector.Y);
    }

    /// <summary>
    /// Removes the current waypoint.
    /// </summary>
    public static void RemoveWaypoint()
    {
        Natives.SetWaypointOff();
    }

    /// <summary>
    /// Replaces the specified HUD colour with the specified custom colour.
    /// </summary>
    /// <param name="hudId">The HUD colour.</param>
    /// <param name="colour">The colour.</param>
    public static void SetColour(int hudId, Color colour)
    {
        Natives.ReplaceHudColourWithRgba(hudId, colour.R, colour.G, colour.B, colour.A);
    }

    /// <summary>
    /// Replaces the specified HUD colour <paramref name="hudId"/> with the colour assigned to the HUD colour specified in
    /// <paramref name="anotherHudId"/>.
    /// </summary>
    /// <param name="hudId">The ID representing the colour to replace.</param>
    /// <param name="anotherHudId">The ID representing the colour to replace with.</param>
    public static void SetColour(int hudId, int anotherHudId)
    {
        Natives.ReplaceHudColour(hudId, anotherHudId);
    }

    public static void SetComponentPosition(HudComponent component, PointF point) =>
        SetComponentPosition(component, point.X, point.Y);

    public static void SetComponentPosition(HudComponent component, Point point) =>
        SetComponentPosition(component, point.X, point.Y);

    public static void SetComponentPosition(HudComponent component, float x, float y) =>
        Natives.SetHudComponentPosition((int)component, x, y);

    public static void ToggleBlockWaypoint(bool toggle)
    {
        Natives.SetMinimapBlockWaypoint(toggle);
    }

    /// <summary>
    /// Toggles whether to display GTA Online-styled big map.
    /// </summary>
    /// <param name="bigMap">If <see langword="true"/>, displays the big map.</param>
    /// <param name="fullMap">If <see langword="true"/>, displays the full map.</param>
    public static void ToggleBigMap(bool bigMap, bool fullMap)
    {
        Natives.SetBigmapActive(bigMap, fullMap);
    }

    /// <summary>
    /// Toggles whether or not the current GPS route flashes.
    /// </summary>
    /// <param name="toggle">If <see langword="true"/>, flashes the current GPS route.</param>
    public static void ToggleGpsFlashes(bool toggle)
    {
        Natives.SetGpsFlashes(toggle);
    }

    /// <summary>
    /// Toggles whether to display the map of Cayo Perico instead of the map of San Andreas.
    /// </summary>
    /// <param name="toggle">If <see langword="true"/>, display the map of Cayo Perico instead of the map of San Andreas.</param>
    public static void ToggleIslandMap(bool toggle)
    {
        Natives.SetUseIslandMap(toggle);
    }

    /// <summary>
    /// Toggles whether to display the map of North Yankton instead of the map of San Andreas.
    /// </summary>
    /// <param name="toggle">If <see langword="true"/>, display the map of North Yankton instead of the map of San Andreas.</param>
    public static void TogglePrologueMap(bool toggle)
    {
        Natives.SetMinimapInPrologue(toggle);
    }

    /// <summary>
    /// Toggles whether or not to disabled Fog of War on the radar.
    /// </summary>
    /// <param name="toggle">If <see langword="true"/>, Fog of War is disabled.</param>
    public static void ToggleRevealMap(bool toggle)
    {
        Natives.SetMinimapHideFow(toggle);
    }

    /// <summary>
    /// Toggles whether to flash the wanted star displayer.
    /// </summary>
    /// <param name="toggle">If <see langword="true"/>, flash the wanted star displayer.</param>
    public static void ToggleWantedDisplayFlashes(bool toggle)
    {
        Natives.FlashWantedDisplay(toggle);
    }
}
