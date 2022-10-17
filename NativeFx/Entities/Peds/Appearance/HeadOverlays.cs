/*
 * SPDX-FileCopyrightText: 2022 WithLithum <withlithum@foxmail.com>
 *
 * SPDX-License-Identifier: Apache-2.0
 */
namespace NativeFx.Entities.Peds.Appearance;

using NativeFx.Interop;

public class HeadOverlays
{
    private readonly XPed _owner;

    internal HeadOverlays(XPed owner)
    {
        _owner = owner;
    }

    public int this[HeadOverlay overlay]
    {
        get => Natives.GetPedHeadOverlay(_owner.Handle, (int)overlay);
        set => Natives.SetPedHeadOverlay(_owner.Handle, (int)overlay, value, 1.0f);
    }

    public void SetWithOpacity(HeadOverlay overlay, int id, float opacity)
    {
        Natives.SetPedHeadOverlay(_owner.Handle, (int)overlay, id, opacity);
    }
}
