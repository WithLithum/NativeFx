/*
 * SPDX-FileCopyrightText: 2022 WithLithum <withlithum@foxmail.com>
 *
 * SPDX-License-Identifier: Apache-2.0
 */
namespace NativeFx.World.Interfaces;
/// <summary>
/// Represents an object that can be frozen.
/// </summary>
public interface IFreezable
{
    /// <summary>
    /// Freezes this instance.
    /// </summary>
    /// <param name="freeze">If <see langword="true"/>, prohibits this instance to change position on its own; otherwise,
    /// <see langword="false"/>.</param>
    void Freeze(bool freeze);
}
