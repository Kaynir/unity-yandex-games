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

        public SystemData(string deviceCode, string languageCode)
        {
            this.deviceCode = deviceCode;
            this.languageCode = languageCode;
        }
    }
}