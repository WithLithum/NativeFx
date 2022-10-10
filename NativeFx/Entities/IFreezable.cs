namespace NativeFx.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IFreezable
{
    /// <summary>
    /// Freezes this instance.
    /// </summary>
    /// <param name="freeze">If <see langword="true"/>, prohibits this instance to change position on its own; otherwise,
    /// <see langword="false"/>.</param>
    void Freeze(bool freeze);
}
