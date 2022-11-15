/*
 * SPDX-FileCopyrightText: 2022 WithLithum <withlithum@foxmail.com>
 *
 * SPDX-License-Identifier: Apache-2.0
 */
namespace NativeFx;

using GTA.Native;
using NativeFx.Interop;
using NativeFx.UI.Text;
using System;

/// <summary>
/// Provides methods and properties to manipulate the game and the game engine.
/// </summary>
public static class XGame
{
    /// <summary>
    /// Gets the current total frame time.
    /// </summary>
    public static float FrameTime => Natives.Timestep();

    /// <summary>
    /// Gets or sets the value of the first native game engine timer.
    /// </summary>
    /// <value>
    /// The value of the first game engine timer, in milliseconds.
    /// </value>
    /// <remarks>
    /// The timer is used by native scripts whenever they need to count up time. Be aware of that it is likely
    /// all scripts share this timer so you may want to implement your own CLR-based timer. If you need to
    /// initialise this, set this to <c>0</c>.
    /// </remarks>
    public static int NativeTimerA
    {
        get => Natives.Timera();
        set => Natives.Settimera(value);
    }

    /// <summary>
    /// Gets or sets the value of the first second game engine timer.
    /// </summary>
    /// <value>
    /// The value of the second game engine timer, in milliseconds.
    /// </value>
    /// <remarks>
    /// The timer is used by native scripts whenever they need to count up time. Be aware of that it is likely
    /// all scripts share this timer so you may want to implement your own CLR-based timer. If you need to
    /// initialise this, set this to <c>0</c>.
    /// </remarks>
    public static int NativeTimerB
    {
        get => Natives.Timerb();
        set => Natives.Settimerb(value);
    }

    /// <summary>
    /// Gets or sets the visual-only wanted level displayed on the HUD.
    /// </summary>
    /// <value>
    /// The visual-only fake wanted level.
    /// </value>
    /// <remarks>
    /// This is used in scripts to render a fake wanted level in combat. It will not spawn NPCs; you should spawn them.
    /// </remarks>
    public static int FakeWantedLevel
    {
        get => Function.Call<int>(Hash.GET_FAKE_WANTED_LEVEL);
        set => Function.Call(Hash.SET_FAKE_WANTED_LEVEL, value);
    }

    /// <summary>
    /// Gets a value indicating whether there is a cutscene that is currently being played.
    /// </summary>
    public static bool IsCutscenePlaying => Natives.IsCutscenePlaying();

    /// <summary>
    /// Toggles whether to substitute the word <c>Waypoint</c> with the word <c>Destination</c> on the map
    /// legend of way-points.
    /// </summary>
    /// <param name="toggle">If <see langword="true"/>, the word will be substituted.</param>
    public static void SetWaypointAsDestination(bool toggle)
    {
        Function.Call((Hash)0x6CDD58146A436083, toggle);
    }

    /// <summary>
    /// Toggles whether to play the default siren in a way that it feels like the sirens are from a
    /// distance.
    /// </summary>
    /// <param name="toggle">If <see langword="true"/>, plays distant sirens.</param>
    public static void PlayDistantSirens(bool toggle)
    {
        Function.Call(Hash.DISTANT_COP_CAR_SIRENS, toggle);
    }

    /// <summary>
    /// Determines whether this client is the host of this script.
    /// </summary>
    /// <returns><see langword="true"/> if this instance is the host of the current script.</returns>
    public static bool IsHostOfThisScript()
    {
        return Natives.NetworkIsHostOfThisScript();
    }

    /// <summary>
    /// Toggles whether to disable automatic re-spawn after the player is busted or wasted.
    /// </summary>
    /// <param name="toggle">If <see langword="true"/>, automatic re-spawn is disabled.</param>
    public static void DisableAutomaticRespawn(bool toggle)
    {
        Natives.PauseDeathArrestRestart(toggle);
    }

    /// <summary>
    /// Displays a subtitle text at the bottom of the screen.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The subtitles are used to indicate the player for the current objective in a mission or event, or as simple subtitles.
    /// </para>
    /// <note type="note">
    /// If you need a subtitle to only appear if the player's Display -> Subtitle option is on, add <c>~z~</c> token at the beginning
    /// of the text.
    /// </note>
    /// </remarks>
    /// <param name="text">The text to draw.</param>
    /// <param name="duration">The duration to display the subtitle. Defaults to <c>8000</c>.</param>
    /// <param name="drawImmediately">If <see langword="true"/>, the subtitle will be drawn immediately; otherwise, it will be drawn after the current subtitle being displayed finished displaying.</param>
    public static void DisplaySubtitle(IText text, int duration = 8000, bool drawImmediately = true)
    {
        Natives.BeginTextCommandPrint("STRING");
        text.Add();
        Natives.EndTextCommandPrint(duration, drawImmediately);
    }

    /// <summary>
    /// Displays a simple notification.
    /// </summary>
    /// <param name="text">The text to display.</param>
    /// <param name="blink">If <see langword="true"/>, the notification will blink briefly when being added to the screen.</param>
    public static void DisplayNotification(IText text, bool blink = false)
    {
        Natives.BeginTextCommandThefeedPost("STRING");
        text.Add();
        Natives.EndTextCommandThefeedPostTicker(blink, false);
    }

    /// <summary>
    /// Displays a simple notification with multiple text components.
    /// </summary>
    /// <param name="text">The text components to display.</param>
    /// <exception cref="ArgumentOutOfRangeException">The <paramref name="text"/> consisted of more than 10 items.</exception>
    public static void DisplayNotification(params IText[] text)
    {
        if (text.Length > 10)
        {
            throw new ArgumentOutOfRangeException(nameof(text), "You can only pass up to 10 text strings.");
        }

        Natives.BeginTextCommandThefeedPost("CEIL_EMAIL_BCON");
        
        foreach (var str in text)
        {
            str.Add();
        }

        Natives.EndTextCommandThefeedPostTicker(false, false);
    }

    /// <summary>
    /// Removes the current cutscene.
    /// </summary>
    public static void RemoveCutscene()
    {
        Natives.RemoveCutscene();
    }
}
