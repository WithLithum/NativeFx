/*
 * SPDX-FileCopyrightText: 2022 WithLithum <withlithum@foxmail.com>
 * SPDX-FileCopyrightText: 2015 crosire & contributors
 *
 * SPDX-License-Identifier: Apache-2.0
 * SPDX-License-Identifier: Zlib
 */

/*
Copyright (C) 2015 crosire

This software is  provided 'as-is', without any express  or implied  warranty. In no event will the
authors be held liable for any damages arising from the use of this software.
Permission  is granted  to anyone  to use  this software  for  any  purpose,  including  commercial
applications, and to alter it and redistribute it freely, subject to the following restrictions:

  1. The origin of this software must not be misrepresented; you must not claim that you  wrote the
     original  software. If you use this  software  in a product, an  acknowledgment in the product
     documentation would be appreciated but is not required.
  2. Altered source versions must  be plainly  marked as such, and  must not be  misrepresented  as
     being the original software.
  3. This notice may not be removed or altered from any source distribution.
*/

namespace NativeFx.World.Internal;

using GTA;
using SHVDN;
using System;

internal static class VdnInterop
{
    internal static void ThrowUnsupported()
    {
        throw new NotSupportedException("Operation is not supported because memory access is unavailable.");
    }

    internal static int GetBlipCategory(IntPtr memoryAddress)
    {
        if (memoryAddress == IntPtr.Zero)
        {
            ThrowUnsupported();
            return 0;
        }

        GameVersion version = Game.Version;
        int num = 90;
        if (version >= GameVersion.v1_0_944_2_Steam)
        {
            num = 96;
        }
        else if (version >= GameVersion.v1_0_463_1_Steam)
        {
            num = 94;
        }

        return NativeMemory.ReadByte(memoryAddress + num);
    }

    internal static int GetBlipPriority(IntPtr memoryAddress)
    {
        if (memoryAddress == IntPtr.Zero)
        {
            ThrowUnsupported();
        }

        GameVersion version = Game.Version;
        var ver = 87;
        if (version >= GameVersion.v1_0_944_2_Steam)
        {
            ver = 93;
        }
        else if (version >= GameVersion.v1_0_463_1_Steam)
        {
            ver = 91;
        }

        return NativeMemory.ReadByte(memoryAddress + ver);
    }

    internal static string GetBlipName(IntPtr blip)
    {
        if (blip == IntPtr.Zero)
        {
            throw new InvalidOperationException("The operation is not valid because the address of the blip is invalid.");
        }

        if ((ushort)NativeMemory.ReadInt16(blip + 48) == 0)
        {
            return string.Empty;
        }

        return NativeMemory.PtrToStringUTF8(NativeMemory.ReadAddress(blip + 40));
    }
}
