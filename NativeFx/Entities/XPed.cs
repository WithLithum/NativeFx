namespace NativeFx.Entities;

using GTA;
using GTA.Native;
using NativeFx.Entities.Peds;
using NativeFx.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    /// Dismisses this instance without clearing the tasks.
    /// </summary>
    public void DismissNoClearTask()
    {
        x.SetIsPersistentNoClearTask(false);
    }

    public void IsVariationValid(PedVariationSlot slot, int drawable, int texture)
    {
        Natives.IsPedComponentVariationValid(x.Handle, (int)slot, drawable, texture);
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
    /// Stops the ambient speech that is currently being played.
    /// </summary>
    public void StopAmbientSpeech()
    {
        Natives.StopCurrentPlayingAmbientSpeech(x.Handle);
    }
}
