namespace NativeFx.UI.Text;

using NativeFx.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Represents a literal text.
/// </summary>
/// <remarks>
/// This type uses <see cref="Natives.AddTextComponentSubstringPlayerName(string)"/> which supports short text strings
/// up to 99 characters, which this type passes a single instance of string. You should pass up to 10 instances of this class
/// for longer strings.
/// </remarks>
public class LiteralText : IText
{
    /// <summary>
    /// Initialises a new instance of the <see cref="LiteralText"/> class.
    /// </summary>
    /// <param name="value">The value.</param>
    public LiteralText(string value)
    {
        Value = value;
    }

    /// <inheritdoc />
    public string Value { get; set; }

    /// <inheritdoc />
    public void Add()
    {
        Natives.AddTextComponentSubstringPlayerName(Value);
    }
}
