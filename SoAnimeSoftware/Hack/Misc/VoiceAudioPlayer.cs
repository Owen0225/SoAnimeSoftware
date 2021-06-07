using System.IO;
using System.Runtime.InteropServices;
using SoAnimeSoftware.CSGO;

namespace SoAnimeSoftware.Hack.Misc
{
    public static unsafe class VoiceAudioPlayer
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate byte VoiceRecordStartDlg(string a1, string a2, string a3);

        private static readonly string _fileFormat = ".wav";

        private static bool _isVoiceEnabled = false;
        private static float _endAudioTime;

        public static bool IsVoiceUsing => _isVoiceEnabled;

        public static bool Play(string filename, bool loopback = true)
        {
            filename = filename + _fileFormat;

            var path = Path.Combine(GVars.MainAudioPath, filename);

            if (!File.Exists(path))
                return false;

            var fileInfo = new FileInfo(path);

            var audioLength = fileInfo.Length / 44100f + 0.05f;
            var fn = Marshal.GetDelegateForFunctionPointer<VoiceRecordStartDlg>(Offsets.VoiceRecordStartPointer);

            SDK.Engine.ClientCmd_Unrestricted($"voice_loopback {(loopback ? "1" : "0")}", 0);
            _endAudioTime = SDK.GlobalVars->timeInSeconds + audioLength;
            _isVoiceEnabled = true;
            var a = fn(path, "", "");

            return true;
        }

        public static void AutoStopAudio()
        {
            if (_isVoiceEnabled && SDK.GlobalVars->timeInSeconds >= _endAudioTime)
            {
                _isVoiceEnabled = false;
                SDK.Engine.ClientCmd_Unrestricted("voice_loopback 0; -voicerecord");
            }
        }

        public static void Stop()
        {
            _isVoiceEnabled = false;
            SDK.Engine.ClientCmd_Unrestricted("voice_loopback 0; -voicerecord");
        }
    }
}