using CoreAudioApi;

namespace SetMasterVolume {
    class Program {
        static void Main(string[] args) {
            if (args.Length == 0) {
                printCurrentMasterVolume();
            } else if (args[0] == "m") {
                toggleMute();
            } else {
                setMasterVolume(double.Parse(args[0]));
            }
        }

        static MMDevice getDefaultAudioEndPoint() {
            var DevEnum = new MMDeviceEnumerator();
            var device = DevEnum.GetDefaultAudioEndpoint(EDataFlow.eRender, ERole.eMultimedia);
            return device;
        }

        static void printCurrentMasterVolume() {
            var device = getDefaultAudioEndPoint();
            System.Console.WriteLine("current Master volume = {0}", device.AudioEndpointVolume.MasterVolumeLevelScalar);
            System.Console.WriteLine("mute = {0}", device.AudioEndpointVolume.Mute ? "ON": "OFF");
        }

        static void toggleMute() {
            var device = getDefaultAudioEndPoint();
            device.AudioEndpointVolume.Mute = !device.AudioEndpointVolume.Mute;
        }

        static void setMasterVolume(double volume) {
            var device = getDefaultAudioEndPoint();
            device.AudioEndpointVolume.MasterVolumeLevelScalar = (float)volume;
        }

    }
}
