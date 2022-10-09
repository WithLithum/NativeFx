namespace NativeFx;

using GTA.Native;
using NativeFx.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        get => Natives.TimerA();
        set => Natives.SetTimerA(value);
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
        get => Natives.TimerB();
        set => Natives.SetTimerB(value);
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
}
