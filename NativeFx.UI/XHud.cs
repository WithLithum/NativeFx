/*
 * SPDX-FileCopyrightText: 2022 WithLithum <withlithum@foxmail.com>
 *
 * SPDX-License-Identifier: Apache-2.0
 */

namespace NativeFx.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class XHud
{
    public static bool FakeSpectatorMode
    {
        get => Natives.GetFakeSpectatorMode();
        set => Natives.SetFakeSpectatorMode(value);
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

    /// <summary>
    /// Replaces the specified HUD colour with the specified custom colour.
    /// </summary>
    /// <param name="hudId">The HUD colour.</param>
    /// <param name="colour">The colour.</param>
    public static void SetColour(int hudId, Color colour)
    {
        Natives.ReplaceHudColourWithRgba(hudId, colour.R, colour.G, colour.B, colour.A);
    }
}
