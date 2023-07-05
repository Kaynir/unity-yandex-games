using System.Collections.Generic;
using UnityEngine;

namespace Kaynir.YandexGames.Tools
{
    public static class YandexConsts
    {
        public const string SDK_OBJECT_NAME = "YandexSDK";

        private static readonly Dictionary<string, DeviceType> _devices = new Dictionary<string, DeviceType>()
        {
            { "desktop", DeviceType.Desktop },
            { "mobile", DeviceType.Handheld },
            { "tablet", DeviceType.Handheld },
            { "tv", DeviceType.Console }
        };

        public static DeviceType GetDeviceType(string deviceID)
        {
            return _devices.TryGetValue(deviceID, out var deviceType)
            ? deviceType
            : DeviceType.Desktop;
        }
    }
}