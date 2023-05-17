using System.Collections.Generic;
using UnityEngine;
using Kaynir.YandexGames.Enums;

namespace Kaynir.YandexGames.Tools
{
    public static class YandexConsts
    {
        private static Dictionary<string, SystemLanguage> _languages = new Dictionary<string, SystemLanguage>()
        {
            { "ru", SystemLanguage.Russian },
            { "en", SystemLanguage.English },
            { "tr", SystemLanguage.Turkish }
        };

        private static Dictionary<string, Device> _devices = new Dictionary<string, Device>()
        {
            { "desktop", Device.Desktop },
            { "mobile", Device.Mobile },
            { "tablet", Device.Tablet },
            { "tv", Device.TV }
        };

        public static SystemLanguage GetLanguage(string languageID)
        {
            return _languages.ContainsKey(languageID)
            ? _languages[languageID]
            : SystemLanguage.English;
        }

        public static Device GetDevice(string deviceID)
        {
            return _devices.ContainsKey(deviceID)
            ? _devices[deviceID]
            : Device.Desktop;
        }

        public static Device GetDevice(bool isMobile)
        {
            return isMobile ? Device.Mobile : Device.Desktop;
        }
    }
}