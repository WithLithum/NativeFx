namespace NativeFx.Interop;

using GTA.Native;

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
