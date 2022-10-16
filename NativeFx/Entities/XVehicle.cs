namespace NativeFx.Entities;

using GTA;
using GTA.Native;
using NativeFx.Interop;

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
    /// Gets a value indicating whether the horn of this instance is currently active.
    /// </summary>
    public bool IsHornActive
    {
        get => Natives.IsHornActive(Handle);
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
    /// Forces this instance to stop after the specified period.
    /// </summary>
    /// <param name="distance">The distance that this vehicle allowed to travel before brought to stop.</param>
    /// <param name="duration">The time takes to bring this instance to stop.</param>
    public void BringToHalt(float distance, int duration) => Natives.BringVehicleToHalt(Handle, distance, duration, false);

    /// <summary>
    /// Attempts to teleport this instance to the ground level properly on all wheels.
    /// </summary>
    /// <remarks>
    /// As this method <b>only attempts</b>, it returns whether it is successful.
    /// </remarks>s
    public void PlaceOnGround() => x.PlaceOnGround();

    /// <summary>
    /// Gets the maximum acceleration value of this instance.
    /// </summary>
    public float MaxAcceleration => Natives.GetVehicleAcceleration(Handle);

    /// <summary>
    /// Gets or sets a value indicating whether the engine of this instance is currently
    /// running.
    /// </summary>
    /// <remarks>
    /// This property instantly turns the engine on or off when set; however, the game provides
    /// additional features when setting engine on or off, to use these features, use <see cref="SetEngineOn(bool, bool, bool)"/>.
    /// </remarks>
    public bool IsEngineOn
    {
        get => Natives.GetIsVehicleEngineRunning(Handle);
        set => Natives.SetVehicleEngineOn(Handle, value, true, false);
    }

    /// <summary>
    /// Gets or sets a value indicating whether this instance plays loud radio audio.
    /// </summary>
    public bool IsRadioLoud
    {
        get => Natives.IsVehicleRadioLoud(Handle);
        set => Natives.SetVehicleRadioLoud(Handle, value);
    }

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

    /// <summary>
    /// Turns on the engine of this instance.
    /// </summary>
    /// <param name="toggle">If <see langword="true"/>, the engine is activated; otherwise, <see langword="false"/>.</param>
    /// <param name="instantly">If <see langword="true"/>, the vehicle will instantly switch on or off instead of the driver switching it physically on or off.</param>
    /// <param name="disableAutoStart">If <see langword="true"/>, when the player enters the vehicle for the next time, the engine will not automatically turn on.</param>
    public void SetEngineOn(bool toggle, bool instantly, bool disableAutoStart)
    {
        Natives.SetVehicleEngineOn(Handle, toggle, instantly, disableAutoStart);
    }

    /// <summary>
    /// Toggles whether the wheels of this instance deals damage to entities when running over those.
    /// </summary>
    /// <param name="toggle">If <see langword="true"/>, deals damage.</param>
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
