/*
 * SPDX-FileCopyrightText: 2022 WithLithum <withlithum@foxmail.com>
 *
 * SPDX-License-Identifier: Apache-2.0
 */
namespace NativeFx.UI;

using NativeFx.Interop;

/// <summary>
/// Provides methods and properties to manipulate gameplay camera.
/// </summary>
public static class XGameplayCamera
{
    /// <summary>
    /// Gets or sets the relative pitch of the gameplay camera.
    /// </summary>
    public static float RelativePitch
    {
        get => Natives.GetGameplayCamRelativePitch();
        set => Natives.SetGameplayCamRelativePitch(value, 1f);
    }

    /// <summary>
    /// Sets the relative pitch of the gameplay camera with the specified scaling.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="factor">The scaling factor.</param>
    public static void SetRelativePitchWithScaling(float value, float factor)
    {
        Natives.SetGameplayCamRelativePitch(value, factor);
    }
}
