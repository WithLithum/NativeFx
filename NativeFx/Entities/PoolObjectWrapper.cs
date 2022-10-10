namespace NativeFx.Entities;

using GTA;

/// <summary>
/// Represents a wrapper object that wraps a <see cref="PoolObject"/>.
/// </summary>
/// <typeparam name="T">The type of the object to wrap.</typeparam>
public abstract class PoolObjectWrapper<T> : IHandleable
    where T : PoolObject
{
    protected readonly T x;

    /// <summary>
    /// Initialises a new instance of the <see cref="PoolObjectWrapper{T}"/> class.
    /// </summary>
    /// <param name="x">The object to wrap.</param>
    protected PoolObjectWrapper(T x)
    {
        this.x = x;
    }

    public int Handle => x.Handle;

    public bool IsValid()
    {
        return x?.Exists() == true;
    }
}
