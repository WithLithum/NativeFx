namespace NativeFx.Interop;

using GTA.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal static partial class Natives
{
    internal static void StopPedRingtone(int /* Ped */ ped)
    {
        Function.Call(Hash.STOP_PED_RINGTONE, ped);
    }

    internal static void StopCurrentPlayingAmbientSpeech(int /* Ped */ ped)
    {
        Function.Call(Hash.STOP_CURRENT_PLAYING_AMBIENT_SPEECH, ped);
    }

    internal static bool IsAmbientSpeechDisabled(int /* Ped */ ped)
    {
        return Function.Call<bool>(Hash.IS_AMBIENT_SPEECH_DISABLED, ped);
    }
}
