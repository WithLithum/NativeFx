namespace NativeFx.Entities;

using GTA;
using GTA.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class PoolObjectWrapper<T> : INativeValue
    where T : PoolObject
{
    protected readonly T x;

    protected PoolObjectWrapper(T x)
    {
        this.x = x;
    }

    /// <summary>
    /// Gets or sets the native value of this instance.
    /// </summary>
    [Obsolete("Should not be used. This property exists purely for convince of the native engine.")]
    public ulong NativeValue
    {
        get => x.NativeValue;
        set => x.NativeValue = value;
    }

    /// <summary>
    /// Determines whether this instance still exists in the game world.
    /// </summary>
    /// <returns><see langword="true"/> if this instance exists; otherwise, <see langword="false"/>.</returns>
    public bool IsValid()
    {
        return x?.Exists() == true;
    }
}
