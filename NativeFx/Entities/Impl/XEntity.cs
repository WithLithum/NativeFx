namespace NativeFx.Entities.Impl;

using GTA.Math;
using NativeFx.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
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

    /// <inheritdoc />
    public Vector3 Position
    {
        get => Natives.GetEntityCoords(Handle, false);
        set => Natives.SetEntityCoords(Handle, value.X, value.Y, value.Z, false, false, false, false);
    }

    /// <inheritdoc />
    public Vector3 Rotation
    {
        get => Natives.GetEntityRotation(Handle, 2);
        set => Natives.SetEntityRotation(Handle, value.X, value.Y, value.Z, 2, true);
    }

    /// <inheritdoc />
    public float Heading
    {
        get => Natives.GetEntityHeading(Handle);
        set => Natives.SetEntityHeading(Handle, value);
    }

    /// <summary>
    /// Gets or sets the hit points (HP, otherwise known as Health) remaining for this instance.
    /// </summary>
    public int Health
    {
        get => Natives.GetEntityHealth(Handle);
        set => Natives.SetEntityHealth(Handle, value, 0);
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
}
