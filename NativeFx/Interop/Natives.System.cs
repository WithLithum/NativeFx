namespace NativeFx.Interop;

using GTA.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal static partial class Natives
{
    internal static float Timestep()
    {
        return Function.Call<float>(Hash.TIMESTEP);
    }

    internal static int TimerA()
    {
        return Function.Call<int>(Hash.TIMERA);
    }

    internal static int TimerB()
    {
        return Function.Call<int>(Hash.TIMERB);
    }

    internal static void SetTimerA(int value)
    {
        Function.Call(Hash.SETTIMERA, value);
    }

    internal static void SetTimerB(int value)
    {
        Function.Call(Hash.SETTIMERB, value);
    }
}
