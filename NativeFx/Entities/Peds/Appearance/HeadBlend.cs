namespace NativeFx.Entities.Peds.Appearance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Represents the head blend data of a character instance.
/// </summary>
public struct HeadBlend
{
    /// <summary>
    /// Gets or sets the value of the first shape factor.
    /// </summary>
    public int FirstShape { get; set; }
    /// <summary>
    /// Gets or sets the value of the second shape factor.
    /// </summary>
    public int SecondShape { get; set; }
    /// <summary>
    /// Gets or sets the value of the additional shape factor.
    /// </summary>
    public int ExtraShape { get; set; }
    /// <summary>
    /// Gets or sets the value of the first tone factor.
    /// </summary>
    public int FirstTone { get; set; }
    /// <summary>
    /// Gets or sets the value of the second tone factor.
    /// </summary>
    public int SecondTone { get; set; }
    /// <summary>
    /// Gets or sets the value of the additional tone factor.
    /// </summary>
    public int ExtraTone { get; set; }
    /// <summary>
    /// Gets or sets the mix between <see cref="FirstShape"/> and <see cref="SecondShape"/>.
    /// </summary>
    public float ShapeMix { get; set; }
    /// <summary>
    /// Gets or sets the mix between <see cref="FirstTone"/> and <see cref="SecondTone"/>.
    /// </summary>
    public float ToneMix { get; set; }
    /// <summary>
    /// Gets or sets the extra mix affects tone and shape.
    /// </summary>
    public float ExtraMix { get; set; }
    /// <summary>
    /// Gets or sets a value indicating whether this instance is used as a parent.
    /// </summary>
    public bool IsParent { get; set; }
}
