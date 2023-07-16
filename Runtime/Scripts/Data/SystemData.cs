using System;
using Kaynir.YandexGames.Tools;
using UnityEngine;

namespace Kaynir.YandexGames.Data
{
    [Serializable]
    public struct SystemData
    {
        [SerializeField] private string deviceCode;
        [SerializeField] private string languageCode;

        public string LanguageCode => languageCode;
        public string DeviceCode => deviceCode;

        public DeviceType DeviceType => YandexTools.GetDeviceType(deviceCode);

        public bool IsMobile => DeviceType == DeviceType.Handheld;

        public SystemData(string deviceCode, string languageCode)
        {
            this.deviceCode = deviceCode;
            this.languageCode = languageCode;
        }

        public SystemData(DeviceType deviceType, string languageCode)
        {
            this.deviceCode = YandexTools.GetDeviceCode(deviceType);
            this.languageCode = languageCode;
        }
    }
}