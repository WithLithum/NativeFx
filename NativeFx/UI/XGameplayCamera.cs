namespace NativeFx.UI;

using NativeFx.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class XGameplayCamera
{
    public static float RelativePitch
    {
        get => Natives.GetGameplayCamRelativePitch();
        set => Natives.SetGameplayCamRelativePitch(value, 1f);
    }

    public static void SetRelativePitchWithScaling(float value, float factor)
    {
        Natives.SetGameplayCamRelativePitch(value, factor);
    }
}
