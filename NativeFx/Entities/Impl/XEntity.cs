/*
 * SPDX-FileCopyrightText: 2022 WithLithum <withlithum@foxmail.com>
 *
 * SPDX-License-Identifier: Apache-2.0
 */

namespace NativeFx.Entities.Impl;

using GTA.Math;
using NativeFx.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Represents an entity in the game world.
/// </summary>
public abstract class XEntity : IHandleable, IDeletable, IPersistable, IFreezable
    , ISpatial
{
    /// <summary>
    /// Initialises a new instance of the <see cref="XEntity"/> class.
    /// </summary>
    /// <param name="handle">The handle.</param>
    protected XEntity(int handle)
    {
        Handle = handle;
    }

    public bool CanBeDamaged
    {
        get => Natives.GetEntityCanBeDamaged(Handle);
        set => Natives.SetEntityCanBeDamaged(Handle, value);
    }

    public System.Numerics.Vector3 ForwardVector
    {
        get
        {
            var nat = Natives.GetEntityForwardVector(Handle);
            return new System.Numerics.Vector3(nat.X, nat.Y, nat.Z);
        }
    }

    public System.Numerics.Vector2 Forward2D
    {
        get
        {
            return new System.Numerics.Vector2(ForwardX, ForwardY);
        }
    }

    public float ForwardX => Natives.GetEntityForwardX(Handle);
    public float ForwardY => Natives.GetEntityForwardY(Handle);

    /// <inheritdoc />
    public int Handle { get; protected internal set; }

    public float HeightAboveGround => Natives.GetEntityHeightAboveGround(Handle);

    /// <summary>
    /// Gets a value indicating whether this instance is still alive.
    /// </summary>
    public bool IsAlive => !IsDead;

    /// <summary>
    /// Gets a value indicating whether this instance is dead.
    /// </summary>
    public bool IsDead => Natives.IsEntityDead(Handle, false);

    public bool IsInAir => Natives.IsEntityInAir(Handle);

    /// <summary>
    /// Gets a value indicating whether this instance is in water.
    /// </summary>
    public bool IsInWater => Natives.IsEntityInWater(Handle);

    /// <summary>
    /// Gets a value indicating whether this instance is static.
    /// </summary>
    /// <remarks>
    /// A static instance will not respond to task invoking and manipulation regarding physics
    /// of static instances are restricted.
    /// </remarks>
    public bool IsStatic => Natives.IsEntityStatic(Handle);

    /// <inheritdoc />
    public bool IsPersistent
    {
        get => Natives.IsEntityAMissionEntity(Handle);
        set
        {
            if (value)
            {
                MakePersistent();
            }
            else
            {
                Dismiss();
            }
        }
    }

    public Matrix Matrix
    {
        get
        {
            GTA.Math.Vector3 forward = GTA.Math.Vector3.Zero;
            GTA.Math.Vector3 up = GTA.Math.Vector3.Zero;
            GTA.Math.Vector3 right = GTA.Math.Vector3.Zero;
            GTA.Math.Vector3 pos = GTA.Math.Vector3.Zero;

            Natives.GetEntityMatrix(Handle, ref forward, ref right, ref up, ref pos);

            return new Matrix(new float[] { forward.X, forward.Y, forward.Z, right.X, right.Y, right.Z, up.X, up.Y, up.Z, pos.X, pos.Y, pos.Z });
        }
    }

    /// <summary>
    /// Gets the physical heading of this instance in degrees.
    /// </summary>
    public float PhysicsHeading => Natives.GetEntityHeadingFromEulers(Handle);

    public float Pitch => Natives.GetEntityPitch(ValidHandleOrException());

    /// <inheritdoc />
    public System.Numerics.Vector3 Position
    {
        get
        {
            var x = Natives.GetEntityCoords(Handle, false);
            return new System.Numerics.Vector3(x.X, x.Y, x.Z);
        }
        set => Natives.SetEntityCoords(Handle, value.X, value.Y, value.Z, false, false, false, false);
    }

    /// <inheritdoc />
    public System.Numerics.Vector3 Rotation
    {
        get
        {
            var x = Natives.GetEntityRotation(Handle, 2);
            return new System.Numerics.Vector3(x.X, x.Y, x.Z);
        }
        set => Natives.SetEntityRotation(Handle, value.X, value.Y, value.Z, 2, true);
    }

    /// <summary>
    /// Gets a value indicating whether this instance have drawable model.
    /// </summary>
    public bool HaveDrawable => Natives.DoesEntityHaveDrawable(Handle);

    /// <summary>
    /// Gets a value indicating whether this instance have physics.
    /// </summary>
    public bool HavePhysics => Natives.DoesEntityHavePhysics(Handle);

    /// <summary>
    /// Gets a value indicating whether this instance have skeleton.
    /// </summary>
    /// <remarks>
    /// This property is introduced in game build 2699.
    /// </remarks>
    public bool HaveSkeleton => Natives.DoesEntityHaveSkeleton(Handle);

    public bool HaveAnimationDirector => Natives.DoesEntityHaveAnimDirector(Handle);

    /// <inheritdoc />
    public float Heading
    {
        get => Natives.GetEntityHeading(Handle);
        set => Natives.SetEntityHeading(Handle, value);
    }

    /// <summary>
    /// Gets or sets the velocity of this instance.
    /// </summary>
    public System.Numerics.Vector3 Velocity
    {
        get
        {
            var x = Natives.GetEntityVelocity(Handle);
            return new System.Numerics.Vector3(x.X, x.Y, x.Z);
        }
        set => Natives.SetEntityVelocity(Handle, value.X, value.Y, value.Z);
    }

    /// <summary>
    /// Gets the rotation velocity of this instance.
    /// </summary>
    public System.Numerics.Vector3 RotationVelocity
    {
        get
        {
            var x = Natives.GetEntityRotationVelocity(Handle);
            return new System.Numerics.Vector3(x.X, x.Y, x.Z);
        }
    }

    /// <summary>
    /// Gets or sets the health value remaining for this instance.
    /// </summary>
    public int Health
    {
        get => Natives.GetEntityHealth(Handle);
        set => Natives.SetEntityHealth(Handle, value, 0);
    }

    /// <summary>
    /// Gets or sets the maximum health value of this instance.
    /// </summary>
    public int MaxHealth
    {
        get => Natives.GetEntityMaxHealth(Handle);
        set => Natives.SetEntityMaxHealth(Handle, value);
    }

    /// <summary>
    /// Gets the speed of this instance in metres per second.
    /// </summary>
    public float Speed
    {
        get => Natives.GetEntitySpeed(Handle);
    }

    /// <summary>
    /// Gets how deep this instance is submerged into water.
    /// </summary>
    /// <value>
    /// A float indicating how deep this instance is submerged into water. Value <c>1.0f</c> means this instance is fully submerged.
    /// </value>
    public float SubmersionLevel
    {
        get => Natives.GetEntitySubmergedLevel(Handle);
    }

    /// <summary>
    /// Gets or sets the quarternion of this instance.
    /// </summary>
    public System.Numerics.Quaternion Quaternion
    {
        get
        {
            float x = 0;
            float y = 0;
            float z = 0;
            float w = 0;

            Natives.GetEntityQuaternion(Handle, ref x, ref y, ref z, ref w);

            return new System.Numerics.Quaternion(x, y, z, w);
        }
        set
        {
            Natives.SetEntityQuaternion(Handle, value.X, value.Y, value.Z, value.W);
        }
    }

    protected int ValidHandleOrException()
    {
        if (!IsValid())
        {
            throw new InvalidOperationException("The operation is not valid because this instance is invalid.");
        }

        return Handle;
    }

    public bool IsAttachedTo(XEntity other)
    {
        if (other == null) throw new ArgumentNullException(nameof(other));
        if (!other.IsValid()) throw new ArgumentException("The other entity is invalid.", nameof(other));

        return Natives.IsEntityAttachedToEntity(ValidHandleOrException(), other.Handle);
    }

    /// <summary>
    /// Determines whether this instance is in screen space.
    /// </summary>
    /// <remarks>
    /// This method does not check if the player can actually see this instance on screen; instead, this method just checks if this instance
    /// is anywhere in the screen space.
    /// </remarks>
    /// <returns><see langword="true"/> if this instance is in screen space; otherwise, <see langword="false"/>.</returns>
    public bool IsOnScreen()
    {
        return Natives.IsEntityOnScreen(ValidHandleOrException());
    }

    /// <inheritdoc />
    public bool IsValid()
    {
        return Natives.DoesEntityExist(Handle);
    }

    /// <inheritdoc />
    public void Delete()
    {
        var x = Handle;
        Natives.DeleteEntity(ref x);
        Handle = x;
    }

    /// <inheritdoc />
    public void Dismiss()
    {
        var x = Handle;
        Natives.SetEntityAsNoLongerNeeded(ref x);
    }

    /// <inheritdoc />
    public void MakePersistent()
    {
        Natives.SetEntityAsMissionEntity(Handle, false, false);
    }

    public void ProcessAttachments() => Natives.ProcessEntityAttachments(ValidHandleOrException());

    public void SetAnimationSpeed(string animDict, string anim, float multiplier) =>
        Natives.SetEntityAnimSpeed(Handle, animDict, anim, multiplier);

    public void StopAnimation(string animDict, string anim) => Natives.StopEntityAnim(ValidHandleOrException(), anim, animDict, 1f);

    /// <inheritdoc />
    public void Freeze(bool freeze)
    {
        Natives.FreezeEntityPosition(Handle, freeze);
    }

    /// <summary>
    /// Toggles whether this instance can only be damaged by the player.
    /// </summary>
    /// <param name="toggle">If <see langword="true"/>, this instance can only be damaged by player; otherwise, <see langword="false"/>.</param>
    public void SetOnlyDamagedByPlayer(bool toggle)
    {
        Natives.SetEntityOnlyDamagedByPlayer(Handle, toggle);
    }

    /// <summary>
    /// Determines whether this instance has or had been damaged by the specified <paramref name="other"/> entity.
    /// </summary>
    /// <param name="other">The entity to check.</param>
    /// <returns><see langword="true"/> if this instance has or had been damaged by <paramref name="other"/> entity; otherwise, <see langword="false"/>.</returns>
    /// <exception cref="ArgumentNullException">The specified <paramref name="other"/> entity is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">The specified <paramref name="other"/> entity is not valid.</exception>
    public bool HasBeenDamagedBy(XEntity other)
    {
        if (other == null) throw new ArgumentNullException(nameof(other));
        if (!other.IsValid()) throw new ArgumentException("The other entity is invalid.", nameof(other));

        return Natives.HasEntityBeenDamagedByEntity(ValidHandleOrException(), other.Handle, true);
    }

    /// <summary>
    /// Determines whether this instance is currently colliding or collided with anything.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This method checks whether this instance is collided with anything (ground, entities, &amp;c.) for the current tick.
    /// </para>
    /// <note type="note">
    /// For vehicles, this method will return <see langword="false"/> even if the wheels of it touches the ground, as this method will only
    /// determine whether the body has collided with anything (except wheels, &amp;c. on vehicle itself) when checking vehicels.
    /// </note>
    /// </remarks>
    /// <returns><see langword="true"/> if this instance is currently colliding or collided with anything; otherwise, <see langword="false"/>.</returns>
    public bool HasCollidedWithAnything()
    {
        return Natives.HasEntityCollidedWithAnything(Handle);
    }
}
