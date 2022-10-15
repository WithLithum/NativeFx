namespace NativeFx.Entities;

using GTA;
using GTA.Native;
using NativeFx.Entities.Peds;
using NativeFx.Interop;

/// <summary>
/// Provides a wrapper for <see cref="Ped"/> that provides extra API access.
/// </summary>
public class XPed : XEntityWrapper<Ped>
{
    /// <summary>
    /// Initialises a new instance of the <see cref="XPed"></see> class.
    /// </summary>
    /// <param name="x">The class to wrap.</param>
    public XPed(Ped x) : base(x)
    {
    }

    /// <summary>
    /// Gets or sets a value indicating whether the torch on the weapon of this instance is
    /// currently activated.
    /// </summary>
    /// <value>
    /// <see langword="true"/> if the torch on the current weapon is on; otherwise, <see langword="false"/>.
    /// </value>
    /// <remarks>
    /// Setting the value requires game version <c>2060</c> or later. 
    /// </remarks>
    public bool IsFlashlightOn
    {
        get => Function.Call<bool>(Hash.IS_FLASH_LIGHT_ON, x.Handle);
        set => Function.Call(Hash._SET_FLASH_LIGHT_ENABLED, x.Handle, value);
    }

    /// <summary>
    /// Gets a value indicating whether this instance is currently fleeing.
    /// </summary>
    public bool IsFleeing => x.IsFleeing;

    /// <summary>
    /// Gets a value indicating whether this instance is currently falling.
    /// </summary>
    public bool IsFalling => x.IsFalling;

    /// <summary>
    /// Gets a value indicating whether this instance has ambient speech disabled.
    /// </summary>
    /// <value>
    /// <see langword="true"/> if ambient speech is disabled; otherwise, <see langword="false"/>.
    /// </value>
    public bool IsAmbientSpeechDisabled
    {
        get => Natives.IsAmbientSpeechDisabled(x.Handle);
    }

    /// <summary>
    /// Gets a value indicating whether this instance is considered injured by the game engine.
    /// </summary>
    /// <remarks>
    /// Game considers an instance "injured" if their health falls below a specified threshold, the threshold
    /// is, by default, <c>100</c>. However, normally an instance with a health below that point would automatically
    /// die.
    /// </remarks>
    public bool IsInjured
    {
        get => Natives.IsPedInjured(Handle);
    }

    /// <summary>
    /// Determines whether this instance can speak the specified speech.
    /// </summary>
    /// <param name="speech">The speech to check.</param>
    /// <returns><see langword="true"/> if this instance can speak the specified speech; otherwise, <see langword="false"/>.</returns>
    public bool CanSpeak(string speech)
    {
        return Natives.CanPedSpeak(x.Handle, speech, false);
    }

    /// <summary>
    /// Determines whether this instance is facing towards the specified instance.
    /// </summary>
    /// <param name="other">The other instance to check.</param>
    /// <param name="coneAngle">The angle of the view cone of this instance.</param>
    /// <returns><see langword="true"/> if this instance currently facing towards the specified instance; otherwise, <see langword="false"/>.</returns>
    public bool IsFacing(XPed other, float coneAngle)
    {
        return Natives.IsPedFacingPed(x.Handle, other.x.Handle, coneAngle);
    }

    /// <summary>
    /// Sets whether to show the vision cone for the ambient blip of this instance.
    /// </summary>
    /// <param name="toggle">If <see langword="true"/>, a vision cone is shown.</param>
    public void ShowConeForAmbientBlip(bool toggle)
    {
        Natives.SetPedAiBlipHasCone(x.Handle, toggle);
    }

    /// <summary>
    /// Disables or enables the pain audio of this instance.
    /// </summary>
    /// <param name="toggle">If <see langword="true"/>, disables the pain audio of this instance.</param>
    public void DisablePainAudio(bool toggle)
    {
        Function.Call(Hash.DISABLE_PED_PAIN_AUDIO, x.Handle, toggle);
    }

    /// <summary>
    /// Sets the response of this instance after this instance has or had lost its target in combat.
    /// </summary>
    /// <param name="response">The response to set to.</param>
    public void SetTargetLostResponse(PedTargetLossResponse response)
    {
        Natives.SetPedTargetLossResponse(Handle, (int)response);
    }

    /// <summary>
    /// Dismisses this instance without clearing the tasks.
    /// </summary>
    public void DismissNoClearTask()
    {
        x.SetIsPersistentNoClearTask(false);
    }

    /// <summary>
    /// Determines whether the specified component variation is valid for this instance.
    /// </summary>
    /// <param name="slot">The slot.</param>
    /// <param name="drawable">The drawable.</param>
    /// <param name="texture">The texture.</param>
    public void IsVariationValid(PedVariationSlot slot, int drawable, int texture)
    {
        Natives.IsPedComponentVariationValid(x.Handle, (int)slot, drawable, texture);
    }

    /// <summary>
    /// Determines whether this instance is currently <b>on</b> any vehicle.
    /// </summary>
    /// <remarks>
    /// This method determines whether this instance is currently <b>physically on</b> (e.g. when standing on it)
    /// a vehicle instead of <b>sitting in</b> a vehicle.
    /// </remarks>
    /// <returns><see langword="true"/> if this instance is currently on any vehicle.</returns>
    public bool IsOnAnyVehicle()
    {
        return Natives.IsPedOnVehicle(Handle);
    }

    /// <summary>
    /// Sets the component variation at the specified <paramref name="slot"/> to the specified <paramref name="drawable"/> and
    /// <paramref name="texture"/>.
    /// </summary>
    /// <param name="slot">The slot to set variation to.</param>
    /// <param name="drawable">The drawable model of the variation to set.</param>
    /// <param name="texture">The texture index of the variation to set.</param>
    public void SetVariation(PedVariationSlot slot, int drawable, int texture)
    {
        Natives.SetPedComponentVariation(x.Handle, (int)slot, drawable, texture, 0);
    }

    /// <summary>
    /// Teleports this instance into the specified vehicle.
    /// </summary>
    /// <param name="vehicle">The vehicle to teleport into.</param>
    /// <param name="seat">The seat.</param>
    public void WrapIntoVehicle(XVehicle vehicle, VehicleSeat seat)
    {
        Natives.SetPedIntoVehicle(Handle, vehicle.Handle, (int)seat);
    }

    /// <summary>
    /// Sets the seeing range of this instance.
    /// </summary>
    /// <param name="range">The seeing range to set to.</param>
    public void SetSeeingRange(float range)
    {
        Natives.SetPedSeeingRange(Handle, range);
    }

    /// <summary>
    /// Toggles whether this instance is highly perceptive.
    /// </summary>
    /// <param name="toggle">If <see langword="true"/>, this instance is highly perceptive.</param>
    public void SetHighlyPerceptive(bool toggle)
    {
        Natives.SetPedHighlyPerceptive(Handle, toggle);
    }

    /// <summary>
    /// Sets the option of how this instance can and the difficulty of being knocked off vehicles.
    /// </summary>
    /// <example>
    /// This is an example found in <c>am_mc_rc_vehicle</c> native script:
    /// <code language="cs">
    /// Game.Player.SetKnockOffVehicleOption(PedKnockOffVehicleOption.Default);
    /// </code>
    /// </example>
    /// <param name="option">The option.</param>
    public void SetKnockOffVehicleOption(PedKnockOffVehicleOption option)
    {
        Natives.SetPedCanBeKnockedOffVehicle(Handle, (int)option);
    }

    /// <summary>
    /// Sets the hearing range of this instance.
    /// </summary>
    /// <param name="range">The hearing range to set to.</param>
    public void SetHearingRange(float range)
    {
        Natives.SetPedHearingRange(Handle, range);
    }

    /// <summary>
    /// Stops the currently playing ringtone of this instance.
    /// </summary>
    public void StopRingtone()
    {
        Natives.StopPedRingtone(x.Handle);
    }

    /// <summary>
    /// Determines whether this instance is in any vehicle that is classified as taxi.
    /// </summary>
    /// <returns><see langword="true"/> if this instance is in any vehicle that is classified as taxi; otherwise,
    /// <see langword="false"/>.</returns>
    public bool IsInAnyTaxi()
    {
        return Natives.IsPedInAnyTaxi(x.Handle);
    }

    /// <summary>
    /// Determines whether this instance is in any vehicle that is determined as "flying" by the game engine.
    /// </summary>
    /// <returns><see langword="true"/> if this instance is in any flying vehicle; otherwise, <see langword="false"/>.</returns>
    public bool IsInAnyFlyingVehicle()
    {
        return Natives.IsPedInFlyingVehicle(Handle);
    }

    /// <summary>
    /// Stops the ambient speech that is currently being played.
    /// </summary>
    public void StopAmbientSpeech()
    {
        Natives.StopCurrentPlayingAmbientSpeech(x.Handle);
    }
}
