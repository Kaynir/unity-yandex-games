using UnityEngine;
using UnityEditor;
using Kaynir.YandexGames.Tools;
using Kaynir.YandexGames.Services;
using Kaynir.YandexGames.Modules;

namespace Kaynir.YandexGames.Editors
{
    public static class YandexMenuItems
    {
        [MenuItem("Kaynir/Yandex Games/Create SDK Object", false)]
        private static void CreateSDKObject()
        {
            GameObject sdkObject = new GameObject();

            sdkObject.name = YandexConsts.SDK_OBJECT_NAME;

            sdkObject.AddComponent<YandexSDK>();
            sdkObject.AddComponent<YandexAdvService>();
            sdkObject.AddComponent<YandexCloudService>();

            sdkObject.AddComponent<AudioMuteModule>();
        }

        [MenuItem("Kaynir/Yandex Games/Create SDK Object", true)]
        private static bool ValidateCreateSDKObject()
        {
            return !GameObject.Find(YandexConsts.SDK_OBJECT_NAME);
        }
    }
}