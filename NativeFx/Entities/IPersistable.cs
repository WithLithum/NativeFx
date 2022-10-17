/*
 * SPDX-FileCopyrightText: 2022 WithLithum <withlithum@foxmail.com>
 *
 * SPDX-License-Identifier: Apache-2.0
 */
namespace NativeFx.Entities;
/// <summary>
/// Represents an entity that can be persistent.
/// </summary>
public interface IPersistable
{
    /// <summary>
    /// Dismisses this instance and flags this instance as 'no longer needed' on the game engine.
    /// </summary>
    /// <remarks>
    /// A dismissed instance, although can be manipulated, will be cleaned up if the game felt that the entity
    /// should no longer be used. Note that the game deletes dismissed instances more easily than ambient spawned
    /// instances.
    /// </remarks>
    void Dismiss();

    /// <summary>
    /// Gets or sets a value indicating whether this instance is persistent.
    /// </summary>
    /// <remarks>
    /// <note type="warning">
    /// You should not rely on this property for guaranteeing that this instance will be valid. Other scripts and
    /// threads can still delete this instance and this instance may be deleted by the game for other reasons. Always
    /// validate this instance on each game tick.
    /// </note>
    /// <para>
    /// Making an instance "persistent" causes the game engine to not to delete this instance during clean-ups regardless
    /// of position, facing, on screen or else.
    /// </para>
    /// </remarks>
    bool IsPersistent { get; set; }
}
