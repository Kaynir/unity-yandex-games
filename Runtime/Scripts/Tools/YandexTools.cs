using System.Collections.Generic;
using Kaynir.YandexGames.Data;
using UnityEngine;

namespace Kaynir.YandexGames.Tools
{
    public static class YandexTools
    {
        public const string SDK_OBJECT_NAME = "YandexSDK";

        public const string DEVICE_CODE_DESKTOP = "desktop";
        public const string DEVICE_CODE_MOBILE = "mobile";
        public const string DEVICE_CODE_TABLET = "tablet";

        public const string DEFAULT_LANGUAGE_CODE = "en";

        private static readonly Dictionary<string, DeviceType> deviceTypes = new Dictionary<string, DeviceType>()
        {
            { DEVICE_CODE_DESKTOP, DeviceType.Desktop },
            { DEVICE_CODE_MOBILE, DeviceType.Handheld },
            { DEVICE_CODE_TABLET, DeviceType.Handheld }
        };

        private static readonly Dictionary<DeviceType, string> deviceCodes = new Dictionary<DeviceType, string>()
        {
            { DeviceType.Desktop, DEVICE_CODE_DESKTOP },
            { DeviceType.Handheld, DEVICE_CODE_MOBILE },
            { DeviceType.Handheld, DEVICE_CODE_TABLET }
        };

        public static DeviceType GetDeviceType(string deviceCode)
        {
            return deviceTypes.GetValueOrDefault(deviceCode, DeviceType.Desktop);
        }

        public static string GetDeviceCode(DeviceType deviceType)
        {
            return deviceCodes.GetValueOrDefault(deviceType, DEVICE_CODE_DESKTOP);
        }

        public static SystemData GetSystemData()
        {
            string json = YandexPlugin.GetSystemData();
            return JsonUtility.FromJson<SystemData>(json);
        }
    }
}