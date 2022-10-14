﻿namespace NativeFx.Entities.Peds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// An enumeration of options applying to when knocking ped off vehicle.
/// </summary>
public enum PedKnockOffVehicleOption
{
    /// <summary>
    /// The default option.
    /// </summary>
    Default,
    /// <summary>
    /// Impossible to knock off vehicle.
    /// </summary>
    Never,
    /// <summary>
    /// Easier to knock off vehicle.
    /// </summary>
    Easy,
    /// <summary>
    /// Harder to knock off vehicle.
    /// </summary>
    Hard
}
