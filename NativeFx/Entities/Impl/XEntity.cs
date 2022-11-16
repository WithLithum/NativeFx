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

    /// <inheritdoc />
    public int Handle { get; protected internal set; }

    /// <summary>
    /// Gets a value indicating whether this instance is still alive.
    /// </summary>
    public bool IsAlive => !IsDead;

    /// <summary>
    /// Gets a value indicating whether this instance is dead.
    /// </summary>
    public bool IsDead => Natives.IsEntityDead(Handle, false);

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

            return new Matrix(forward.X, forward.Y, forward.Z, right.X, right.Y, right.Z, up.X, up.Y, up.Z, pos.X, pos.Y, pos.Z);
        }
    }

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
}
