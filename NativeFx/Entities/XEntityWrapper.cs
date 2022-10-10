namespace NativeFx.Entities;

using GTA;
using GTA.Math;
using NativeFx.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Provides a wrapper for an entity.
/// </summary>
/// <typeparam name="T">The entity to wrap.</typeparam>
public abstract class XEntityWrapper<T> : PoolObjectWrapper<T>, IDeletable, IPersistable, IFreezable, ISpatial
    where T : Entity
{
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
    /// The health of this instance.
    /// </value>
    public int Health
    {
        get => x.Health;
        set => x.Health = value;
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

    public bool IsPersistent
    {
        get => x.IsPersistent;
        set => x.IsPersistent = value;
    }

    /// <summary>
    /// Gets a value indicating whether this instance is in water.
    /// </summary>
    public bool IsInWater => Natives.IsEntityInWater(x.Handle);

    /// <summary>
    /// Gets or sets a value indicating whether this instance has gravity.
    /// </summary>
    public bool HasGravity
    {
        get => x.HasGravity;
        set => Natives.SetEntityHasGravity(x.Handle, value);
    }

    public bool HasDrawable => Natives.DoesEntityHaveDrawable(x.Handle);

    public bool HasPhysics => Natives.DoesEntityHavePhysics(x.Handle);

    public Vector3 Position
    {
        get => x.Position;
        set => x.Position = value;
    }
    public Vector3 Rotation
    {
        get => x.Rotation;
        set => x.Rotation = value;
    }

    public float Heading
    {
        get => Natives.GetEntityHeading(Handle);
        set => Natives.SetEntityHeading(Handle, value);
    }

    public void Delete()
    {
        x.Delete();
    }

    public void Dismiss()
    {
        x.MarkAsNoLongerNeeded();
    }

    public void Freeze(bool freeze)
    {
        Natives.FreezeEntityPosition(Handle, freeze);
    }
}
