using System.Collections.Generic;
using Kaynir.YandexGames.Data;
using UnityEngine;

namespace Kaynir.YandexGames.Tools
{
    public static class YandexTools
    {
        public const string SDK_OBJECT_NAME = "YandexSDK";

        private static readonly Dictionary<string, DeviceType> _devices = new Dictionary<string, DeviceType>()
        {
            { "desktop", DeviceType.Desktop },
            { "mobile", DeviceType.Handheld },
            { "tablet", DeviceType.Handheld },
            { "tv", DeviceType.Console }
        };

        public static DeviceType GetDeviceType(string deviceCode)
        {
            return _devices.TryGetValue(deviceCode, out var deviceType)
            ? deviceType
            : DeviceType.Desktop;
        }

        public static SystemData GetSystemData()
        {
            string json = YandexPlugin.GetSystemData();
            return JsonUtility.FromJson<SystemData>(json);
        }
    }
}