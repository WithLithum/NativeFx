namespace NativeFx.UI.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Represents a native text string.
/// </summary>
public interface IText
{
    /// <summary>
    /// Gets or sets the value of this instance.
    /// </summary>
    string Value { get; set; }

    /// <summary>
    /// Adds the <see cref="Value"/> to the native text stack.
    /// </summary>
    void Add();
}
