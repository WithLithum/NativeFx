namespace NativeFx.Entities;

using GTA;
using GTA.Native;
using NativeFx.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class XVehicle : XEntityWrapper<Vehicle>
{
    public XVehicle(Vehicle x) : base(x)
    {
    }

    /// <summary>
    /// Gets a value indicating whether this instance has a searchlight available.
    /// </summary>
    /// <value>
    /// <see langword="true"/> if this instance has a searchlight; otherwise, <see langword="false"/>.
    /// </value>
    public bool HasSearchlight => Natives.DoesVehicleHaveSearchlight(x.Handle);

    /// <inheritdoc cref="Vehicle.IsSearchLightOn" />
    public bool IsSearchLightOn
    {
        get => x.IsSearchLightOn;
        set => x.IsSearchLightOn = value;
    }

    /// <summary>
    /// Attempts to teleport this instance to the ground level properly on all wheels.
    /// </summary>
    /// <remarks>
    /// As this method <b>only attempts</b>, it returns whether it is successful.
    /// </remarks>
    public void PlaceOnGround() => x.PlaceOnGround();

    /// <summary>
    /// Toggles whether to play a stall warning at this instance.
    /// </summary>
    /// <param name="toggle">If <see langword="true"/>, plays stall warning.</param>
    public void PlayStallWarning(bool toggle)
    {
        Function.Call(Hash.ENABLE_STALL_WARNING_SOUNDS, x, toggle);
    }
}
