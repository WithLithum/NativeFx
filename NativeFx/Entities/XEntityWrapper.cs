/*
 * SPDX-FileCopyrightText: 2022 WithLithum <withlithum@foxmail.com>
 *
 * SPDX-License-Identifier: Apache-2.0
 */
namespace NativeFx.Entities;

using GTA;
using GTA.Math;
using NativeFx.Interop;
using System;

/// <summary>
/// Provides a wrapper for an entity.
/// </summary>
/// <typeparam name="T">The entity to wrap.</typeparam>
public abstract class XEntityWrapper<T> : PoolObjectWrapper<T>, IDeletable, IPersistable, IFreezable, ISpatial
    where T : Entity
{
    /// <summary>
    /// Initialises a new instance of the <see cref="XEntityWrapper{T}"/> class.
    /// </summary>
    /// <param name="x">The entity to wrap.</param>
    protected XEntityWrapper(T x) : base(x)
    {
    }

    /// <summary>
    /// Gets the model of this instance.
    /// </summary>
    /// <value>
    /// The model of this instance.
    /// </value>
    public Model Model => x.Model;

    /// <summary>
    /// Gets or sets the health of this instance.
    /// </summary>
    /// <value>
    /// The health of this instance. This instance is considered 'dead' if the health of this
    /// instance is less than <c>0</c>, unless this instance is a vehicle (which whether it is dead
    /// is determined by various other health values).
    /// </value>
    public int Health
    {
        get => Natives.GetEntityHealth(Handle);
        set => Natives.SetEntityHealth(Handle, value, 0);
    }

    /// <summary>
    /// Gets or sets the maximum health of this instance.
    /// </summary>
    /// <value>
    /// The maximum health of this instance.
    /// </value>
    public int MaxHealth
    {
        get => Natives.GetEntityMaxHealth(x.Handle);
        set => Natives.SetEntityMaxHealth(x.Handle, value);
    }

    /// <summary>
    /// Gets a value indicating whether this instance is dead.
    /// </summary>
    public virtual bool IsDead => Natives.IsEntityDead(Handle, false);

    /// <summary>
    /// Gets a value indicating whether this instance is alive.
    /// </summary>
    public bool IsAlive => !IsDead;

    /// <summary>
    /// Gets a value indicating whether this instance is on fire.
    /// </summary>
    public bool IsOnFire => Natives.IsEntityOnFire(Handle);

    /// <summary>
    /// <inheritdoc />
    /// </summary>
    /// <remarks>
    /// <inheritdoc />
    /// <para>
    /// In GTA IV, it is also known as "required for mission".
    /// </para>
    /// </remarks>
    public bool IsPersistent
    {
        get => x.IsPersistent;
        set
        {
            if (value)
            {
                this.MakePersistent();
            }
            else
            {
                this.Dismiss();
            }
        }
    }

    public void MakePersistent()
    {
        Natives.SetEntityAsMissionEntity(Handle, false, false);
    }

    /// <summary>
    /// Gets a value indicating whether this instance is in water.
    /// </summary>
    public bool IsInWater => Natives.IsEntityInWater(x.Handle);

    /// <summary>
    /// Gets a value indicating whether this instance is static.
    /// </summary>
    /// <remarks>
    /// A static instance will not respond to task invoking and manipulation regarding physics
    /// of static instances are restricted.
    /// </remarks>
    public bool IsStatic => Natives.IsEntityStatic(Handle);

    /// <summary>
    /// Gets or sets a value indicating whether this instance has gravity.
    /// </summary>
    public bool HasGravity
    {
        get => x.HasGravity;
        set => Natives.SetEntityHasGravity(x.Handle, value);
    }

    /// <summary>
    /// Gets a value indicating whether this instance has a drawable model.
    /// </summary>
    public bool HasDrawable => Natives.DoesEntityHaveDrawable(x.Handle);

    /// <summary>
    /// Gets a value indicating whether this instance has physics.
    /// </summary>
    public bool HasPhysics => Natives.DoesEntityHavePhysics(x.Handle);

    /// <summary>
    /// Gets or sets the position of this instance.
    /// </summary>
    public Vector3 Position
    {
        get => x.Position;
        set => x.Position = value;
    }

    /// <summary>
    /// Gets or sets the rotation of this instance.
    /// </summary>
    public Vector3 Rotation
    {
        get => x.Rotation;
        set => x.Rotation = value;
    }

    /// <summary>
    /// Gets or sets the heading of this instance.
    /// </summary>
    public float Heading
    {
        get => Natives.GetEntityHeading(Handle);
        set => Natives.SetEntityHeading(Handle, value);
    }

    /// <inheritdoc />
    public void Delete()
    {
        x.Delete();
    }

    /// <inheritdoc />
    public void Dismiss()
    {
        var x = Handle;
        Natives.SetEntityAsNoLongerNeeded(ref x);
    }

    /// <summary>
    /// Determines whether this instance is attached to any vehicle.
    /// </summary>
    /// <returns><see langword="true"/> if this instance is attached to any vehicle.</returns>
    public bool IsAttachedToAnyVehicle()
    {
        return Natives.IsEntityAttachedToAnyVehicle(Handle);
    }

    /// <summary>
    /// Freezes this instance.
    /// </summary>
    /// <param name="freeze">If <see langword="true"/>, this instance is frozen.</param>
    public void Freeze(bool freeze)
    {
        Natives.FreezeEntityPosition(Handle, freeze);
    }

    public void Teleport(Vector3 position, bool clearArea, bool invertX = false, bool invertY = false, bool invertZ = false)
    {
        Natives.SetEntityCoords(Handle, position.X, position.Y, position.Z, invertX, invertY, invertZ, clearArea);
    }

    public void TeleportNoOffset(Vector3 position, bool invertX = false, bool invertY = false, bool invertZ = false)
    {
        Natives.SetEntityCoordsNoOffset(Handle, position.X, position.Y, position.Z, invertX, invertY, invertZ);
    }
}
