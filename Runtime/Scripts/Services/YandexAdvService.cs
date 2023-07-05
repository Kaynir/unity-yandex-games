using System;
using Kaynir.YandexGames.Tools;
using UnityEngine;

namespace Kaynir.YandexGames.Services
{
    public class YandexAdvService : MonoBehaviour, IAdvService
    {
        #region Events
        public event Action AdvOpened;
        public event Action AdvClosed;
        public event Action AdvFailed;
        public event Action<int> AdvRewarded;
        #endregion

        #region Methods
        public void ShowFullscreenAdv() => YandexPlugin.ShowFullscreenAdv();
        public void ShowRewardedAdv(int reward) => YandexPlugin.ShowRewardedAdv(reward);
        #endregion

        #region JS Callbacks
        private void OnAdvOpened() => AdvOpened?.Invoke();
        private void OnAdvClosed() => AdvClosed?.Invoke();
        private void OnAdvFailed() => AdvFailed?.Invoke();
        private void OnAdvRewarded(int reward) => AdvRewarded?.Invoke(reward);
        #endregion
    }
}