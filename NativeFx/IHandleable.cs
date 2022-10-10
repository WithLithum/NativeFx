namespace NativeFx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Represents an object that represents an instance in the game engine via a handle provided
/// by the game engine.
/// </summary>
public interface IHandleable
{
    /// <summary>
    /// Gets the handle of this instance.
    /// </summary>
    int Handle { get; }

    /// <summary>
    /// Determines whether this instance still represents a valid instance in the game
    /// world.
    /// </summary>
    /// <returns><see langword="true"/> if this instance is still valid; otherwise, <see langword="false"/>.</returns>
    bool IsValid();
}
