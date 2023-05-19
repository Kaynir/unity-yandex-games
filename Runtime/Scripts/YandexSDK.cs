using System;
using Kaynir.YandexGames.Enums;
using Kaynir.YandexGames.Tools;
using UnityEngine;

namespace Kaynir.YandexGames
{
    public class YandexSDK : MonoBehaviour
    {
        #region Initialization
        private static YandexSDK _instance;

        private static void CreateInstance()
        {
            _instance = new GameObject().AddComponent<YandexSDK>();
            _instance.name = nameof(YandexSDK);
            DontDestroyOnLoad(_instance.gameObject);
        }

        public static void Initialize()
        {
            CreateInstance();

            if (Debug.isDebugBuild)
            {
                Status = SDKStatus.Debug;
                Player = new Player(false);
                Environment = new Environment(YandexConsts.GetDevice(Application.isMobilePlatform),
                                              Application.systemLanguage);
                return;
            }

            Status = (SDKStatus)YandexService.GetSDKStatus();
            Player = new Player(YandexService.GetAuthStatus());
            Environment = new Environment(YandexService.GetDevice(), YandexService.GetLanguage());
        }
        #endregion

        #region Events
        public static event Action<string> DataLoaded;
        public static event Action DataSaved;

        public static event Action VideoAdvOpened;
        public static event Action VideoAdvClosed;
        public static event Action VideoAdvFailed;
        public static event Action<int> VideoAdvRewarded;

        public static event Action FullscreenAdvOpened;
        public static event Action FullscreenAdvClosed;
        public static event Action FullscreenAdvFailed;
        #endregion

        #region Status
        public static SDKStatus Status { get; private set; }
        public static Player Player { get; private set; }
        public static Environment Environment { get; private set; }
        #endregion

        #region Methods
        public static void LoadData() => YandexService.LoadData();
        public static void SaveData(string data) => YandexService.SaveData(data);

        public static void SetLeaderboard(string id, int value)
        {
            if (!Player.isAuthorized) return;
            YandexService.SetLeaderboard(id, value);
        }

        public static void ShowFullscreenAdv()
        {
            if (Status == SDKStatus.Debug) return;
            YandexService.ShowFullscreenAdv();
        }

        public static void ShowRewardedAdv(int reward)
        {
            switch (Status)
            {
                default: YandexService.ShowRewardedAdv(reward); break;
                case SDKStatus.Debug: 
                {
                    _instance.OnVideoAdvOpened();
                    _instance.OnVideoAdvRewarded(reward);
                    _instance.OnVideoAdvClosed();
                    break;
                }
            }
        }
        #endregion

        #region JS Callbacks
        private void OnDataLoaded(string data) => DataLoaded?.Invoke(data);
        private void OnDataSaved() => DataSaved?.Invoke();

        private void OnVideoAdvOpened() => VideoAdvOpened?.Invoke();
        private void OnVideoAdvClosed() => VideoAdvClosed?.Invoke();
        private void OnVideoAdvFailed() => VideoAdvFailed?.Invoke();
        private void OnVideoAdvRewarded(int reward) => VideoAdvRewarded?.Invoke(reward);

        private void OnFullscreenAdvOpened() => FullscreenAdvOpened?.Invoke();
        private void OnFullscreenAdvClosed() => FullscreenAdvClosed?.Invoke();
        private void OnFullscreenAdvFailed() => FullscreenAdvFailed?.Invoke();
        #endregion
    }
}