using Kaynir.YandexGames.Tools;
using UnityEngine;

namespace Kaynir.YandexGames
{
    public class YandexSDK : MonoBehaviour
    {
        public bool IsAuthorized => YandexPlugin.IsAuthorized();

        public string LanguageID => YandexPlugin.GetLanguage();
        public string DeviceID => YandexPlugin.GetDevice();

        public DeviceType DeviceType => YandexConsts.GetDeviceType(DeviceID);

        private void Awake()
        {
            gameObject.name = YandexConsts.SDK_OBJECT_NAME;
            DontDestroyOnLoad(gameObject);
        }
    }
}