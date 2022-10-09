namespace NativeFx.Entities;

using GTA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Provides a wrapper for an entity.
/// </summary>
/// <typeparam name="T">The entity to wrap.</typeparam>
public abstract class XEntityWrapper<T> : PoolObjectWrapper<T>, IDeletable, IPersistable
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

    public bool IsPersistent
    {
        get => x.IsPersistent;
        set => x.IsPersistent = value;
    }

    public void Delete()
    {
        x.Delete();
    }

    public void Dismiss()
    {
        x.MarkAsNoLongerNeeded();
    }
}
