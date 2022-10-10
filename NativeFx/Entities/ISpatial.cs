namespace NativeFx.Entities;

using GTA.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Represents a spatial object.
/// </summary>
public interface ISpatial
{
    /// <summary>
    /// Gets or sets the position of this instance.
    /// </summary>
    public Vector3 Position { get; set; }

    /// <summary>
    /// Gets or sets the rotation of this instance.
    /// </summary>
    public Vector3 Rotation { get; set; }

    /// <summary>
    /// Gets or sets the heading or Yaw of this instance.
    /// </summary>
    public float Heading { get; set; }
}
