namespace NativeFx.Entities.Peds;
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
