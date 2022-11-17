/*
 * SPDX-FileCopyrightText: 2022 WithLithum <withlithum@foxmail.com>
 *
 * SPDX-License-Identifier: Apache-2.0
 */
namespace NativeFx.Entities.Players;

using GTA;
using NativeFx.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public sealed class XPlayer : IEquatable<XPlayer>
{
    private static XPlayer _local;

    internal XPlayer(int id)
    {
        Id = id;
    }

    /// <summary>
    /// Gets the local player.
    /// </summary>
    public static XPlayer Local
    {
        get
        {
            _local ??= new XPlayer(Natives.PlayerId().Handle);

            return _local;
        }
    }

    /// <summary>
    /// Gets the identification number of this player.
    /// </summary>
    public int Id { get; }

    /// <inheritdoc />
    public bool Equals(XPlayer other)
    {
        return other != null && this.Id == other.Id;
    }
}
