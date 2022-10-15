namespace NativeFx.Entities;

using GTA;
using GTA.Math;
using NativeFx.Interop;

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

    /// <summary>
    /// Gets a value indicating whether this instance is dead.
    /// </summary>
    public bool IsDead => Natives.IsEntityDead(Handle);

    /// <summary>
    /// Gets a value indicating whether this instance is alive.
    /// </summary>
    public bool IsAlive => !IsDead;

    /// <summary>
    /// Gets a value indicating whether this instance is on fire.
    /// </summary>
    public bool IsOnFire => Natives.IsEntityOnFire(Handle);

    /// <inheritdoc />
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
        x.MarkAsNoLongerNeeded();
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
}
