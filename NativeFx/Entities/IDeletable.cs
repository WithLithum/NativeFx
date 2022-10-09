namespace NativeFx.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Represents an instance that can be deleted.
/// </summary>
public interface IDeletable
{
    /// <summary>
    /// Deletes this instance.
    /// </summary>
    void Delete();
}
