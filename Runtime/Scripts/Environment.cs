using Kaynir.YandexGames.Enums;
using Kaynir.YandexGames.Tools;
using UnityEngine;

namespace Kaynir.YandexGames
{
    public struct Environment
    {
        public Device device;
        public SystemLanguage language;

        public Environment(string deviceID, string languageID)
        {
            device = YandexConsts.GetDevice(deviceID);
            language = YandexConsts.GetLanguage(languageID);
        }

        public Environment(Device device, SystemLanguage language)
        {
            this.device = device;
            this.language = language;
        }
    }
}