namespace NativeFx.Interop;

using GTA.Native;

internal static partial class Natives
{
    internal static void BlipSiren(int /* Vehicle */ vehicle)
    {
        Function.Call(Hash.BLIP_SIREN, vehicle);
    }

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

    internal static bool IsHornActive(int /* Vehicle */ vehicle)
    {
        return Function.Call<bool>(Hash.IS_HORN_ACTIVE, vehicle);
    }
}
