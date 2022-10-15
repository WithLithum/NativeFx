namespace NativeFx.Entities;
/// <summary>
/// Represents an object that can be frozen.
/// </summary>
public interface IFreezable
{
    /// <summary>
    /// Freezes this instance.
    /// </summary>
    /// <param name="freeze">If <see langword="true"/>, prohibits this instance to change position on its own; otherwise,
    /// <see langword="false"/>.</param>
    void Freeze(bool freeze);
}
