/*
 * SPDX-FileCopyrightText: 2022 WithLithum <withlithum@foxmail.com>
 *
 * SPDX-License-Identifier: Apache-2.0
 */
namespace NativeFx.Entities;

using GTA.Math;

/// <summary>
/// Represents a spatial object.
/// </summary>
public interface ISpatial
{
    /// <summary>
    /// Gets or sets the position of this instance.
    /// </summary>
    public System.Numerics.Vector3 Position { get; set; }

    /// <summary>
    /// Gets or sets the rotation of this instance.
    /// </summary>
    public System.Numerics.Vector3 Rotation { get; set; }

    /// <summary>
    /// Gets or sets the heading or Yaw of this instance.
    /// </summary>
    public float Heading { get; set; }
}

/// <summary>
/// Represents a spatial object.
/// </summary>
public interface INativeSpatial
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
