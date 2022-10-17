/*
 * SPDX-FileCopyrightText: 2022 WithLithum <withlithum@foxmail.com>
 *
 * SPDX-License-Identifier: Apache-2.0
 */
namespace NativeFx.UI;

using NativeFx.Interop;

/// <summary>
/// Provides utilities to manipulate HUD.
/// </summary>
public static class XHud
{
    /// <summary>
    /// Flashes the GPS route.
    /// </summary>
    /// <param name="flash">If <see langword="true"/>, the GPS route is flashed.</param>
    public static void FlashGpsRoute(bool flash)
    {
        Natives.SetGpsFlashes(flash);
    }

    public static void FlashWantedDisplay(bool flash)
    {
        Natives.FlashWantedDisplay(flash);
    }
}
