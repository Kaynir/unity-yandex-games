using System;
using Kaynir.YandexGames.Enums;
using Kaynir.YandexGames.Tools;
using UnityEngine;

namespace Kaynir.YandexGames
{
    public class YandexSDK : MonoBehaviour
    {
        #region Initialization
        public static YandexSDK Instance => _instance ?? CreateInstance();
        private static YandexSDK _instance;

        private static YandexSDK CreateInstance()
        {
            _instance = new GameObject().AddComponent<YandexSDK>();
            _instance.name = nameof(YandexSDK);
            _instance.Initialize();

            DontDestroyOnLoad(_instance.gameObject);
            return _instance;
        }

        private void Initialize()
        {
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
        public event Action<string> DataLoaded;
        public event Action DataSaved;

        public event Action VideoAdvOpened;
        public event Action VideoAdvClosed;
        public event Action VideoAdvFailed;
        public event Action<int> VideoAdvRewarded;

        public event Action FullscreenAdvOpened;
        public event Action FullscreenAdvClosed;
        public event Action FullscreenAdvFailed;
        #endregion

        #region Status
        public SDKStatus Status { get; private set; }
        public Player Player { get; private set; }
        public Environment Environment { get; private set; }
        #endregion

        #region Methods
        public void LoadData() => YandexService.LoadData();
        public void SaveData(string data) => YandexService.SaveData(data);

        public void SetLeaderboard(string id, int value)
        {
            if (!Player.isAuthorized) return;
            YandexService.SetLeaderboard(id, value);
        }

        public void ShowFullscreenAdv()
        {
            if (Status == SDKStatus.Debug) return;
            YandexService.ShowFullscreenAdv();
        }

        public void ShowRewardedAdv(int reward)
        {
            switch (Status)
            {
                default: YandexService.ShowRewardedAdv(reward); break;
                case SDKStatus.Debug: 
                {
                    OnVideoAdvOpened();
                    OnVideoAdvRewarded(reward);
                    OnVideoAdvClosed();
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