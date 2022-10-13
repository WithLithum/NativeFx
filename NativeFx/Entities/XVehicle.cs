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
    /// Gets or sets the amount of bombs carried on this instance.
    /// </summary>
    /// <remarks>
    /// This property does not have any effects on vehicles; scripts use this to store
    /// the amount of bombs store on a vehicle. You should check for this manually in event
    /// of using this property when dropping bombs, and manually add and deduct bombs when
    /// a bomb is loaded or dropped from this instance.
    /// </remarks>
    /// <value>
    /// The amount of bombs carried on this instance.
    /// </value>
    public int BombCount
    {
        get => Natives.GetVehicleBombCount(Handle);
        set => Natives.SetVehicleBombCount(Handle, value);
    }

    /// <summary>
    /// Attempts to teleport this instance to the ground level properly on all wheels.
    /// </summary>
    /// <remarks>
    /// As this method <b>only attempts</b>, it returns whether it is successful.
    /// </remarks>
    public void PlaceOnGround() => x.PlaceOnGround();

    /// <summary>
    /// Sets whether this instance can be used by fleeing actors.
    /// </summary>
    /// <param name="toggle">If <see langword="true"/>, fleeing actors will use this vehicle.</param>
    public void CanBeUsedByFleeingPeds(bool toggle)
    {
        Natives.SetVehicleCanBeUsedByFleeingPeds(x.Handle, toggle);
    }

    /// <summary>
    /// Sets whether this instance has its control inverted (reversed).
    /// </summary>
    /// <remarks>
    /// If a vehicles controls are inverted, accelerating with cause this vehicle to go backward or slow
    /// down instead, and pressing the go back/slow down key with accelerate instead.
    /// </remarks>
    /// <param name="toggle">If <see langword="true"/>, the controls of this vehicle is inverted.</param>
    public void SetControlsInverted(bool toggle)
    {
        Natives.SetVehicleControlsInverted(x.Handle, toggle);
    }

    /// <summary>
    /// Determines whether the wings of this instance are intact, given if this instance is
    /// a plane.
    /// </summary>
    /// <returns><see langword="true"/> if wings are intact; otherwise, <see langword="false"/>.</returns>
    public bool AreWingsIntact()
    {
        return Natives.ArePlaneWingsIntact(Handle);
    }

    /// <summary>
    /// Toggles whether to play a stall warning at this instance.
    /// </summary>
    /// <param name="toggle">If <see langword="true"/>, plays stall warning.</param>
    public void PlayStallWarning(bool toggle)
    {
        Function.Call(Hash.ENABLE_STALL_WARNING_SOUNDS, x, toggle);
    }

    public void SetWheelsDealDamage(bool toggle)
    {
        Natives.SetVehicleWheelsDealDamage(Handle, toggle);
    }

    /// <summary>
    /// Triggers the siren of this instance if this instance has sirens and no actor are
    /// in the vehicle.
    /// </summary>
    public void TriggerSiren()
    {
        Natives.TriggerSiren(Handle);
    }
}
