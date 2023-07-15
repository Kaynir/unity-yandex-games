using Kaynir.YandexGames.Data;
using Kaynir.YandexGames.Services;
using Kaynir.YandexGames.Tools;
using UnityEngine;

namespace Kaynir.YandexGames
{
    public class YandexSDK : MonoBehaviour
    {
        #region Initialization
        public static YandexSDK Instance => instance ?? CreateInstance();

        private static YandexSDK instance;
        
        private static YandexSDK CreateInstance()
        {
            GameObject sdkObject = new GameObject(YandexTools.SDK_OBJECT_NAME);
            instance = sdkObject.AddComponent<YandexSDK>();

            instance.SystemData = YandexTools.GetSystemData();

#if !UNITY_EDITOR && UNITY_WEBGL
            instance.AdvService = sdkObject.AddComponent<YandexAdvService>();
            instance.AuthService = sdkObject.AddComponent<YandexAuthService>();
            instance.CloudService = sdkObject.AddComponent<YandexCloudService>();
            instance.LeaderboardService = sdkObject.AddComponent<YandexLeaderboardService>();
#else
            YandexSDKDummy dummyServices = sdkObject.AddComponent<YandexSDKDummy>();
            instance.AdvService = dummyServices;
            instance.AuthService = dummyServices;
            instance.CloudService = dummyServices;
            instance.LeaderboardService = dummyServices;
#endif
            DontDestroyOnLoad(sdkObject);
            return instance;
        }
        #endregion

        public SystemData SystemData { get; private set; }

        public IAdvService AdvService { get; private set; }
        public IAuthService AuthService { get; private set; }
        public ICloudService CloudService { get; private set; }
        public ILeaderboardService LeaderboardService { get; private set; }

        private void OnDestroy() => instance = null;
    }
}