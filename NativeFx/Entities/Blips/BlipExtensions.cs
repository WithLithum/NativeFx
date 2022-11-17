/*
 * SPDX-FileCopyrightText: 2022 WithLithum <withlithum@foxmail.com>
 *
 * SPDX-License-Identifier: Apache-2.0
 */

namespace NativeFx.Entities.Blips;

using GTA;
using NativeFx.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class BlipExtensions
{
    public static void ShowGoldTick(this Blip blip, bool toggle)
    {
        if (!(blip ?? throw new ArgumentNullException(nameof(blip))).Exists())
        {
            throw new ArgumentException("Operation is invalid because the blip is invalid.", nameof(blip));
        }

        Natives.ShowGoldTickOnBlip(blip.Handle, toggle);
    }
}
