using System;
using Kaynir.YandexGames.Services;
using UnityEngine;

namespace Kaynir.YandexGames
{
    public class YandexSDKDummy : MonoBehaviour, IAdvService, IAuthService, ICloudService, ILeaderboardService
    {
        public event Action AdvOpened;
        public event Action AdvClosed;
        public event Action AdvFailed;
        public event Action<int> AdvRewarded;

        public event Action<string> DataLoaded;
        public event Action<bool> DataSaved;

        public bool IsAuthorized => false;

        public void ShowFullscreenAdv()
        {
            AdvOpened?.Invoke();
            AdvClosed?.Invoke();
        }

        public void ShowRewardedAdv(int reward)
        {
            AdvOpened?.Invoke();
            AdvRewarded?.Invoke(reward);
            AdvClosed?.Invoke();
        }

        public void LoadData()
        {
            DataLoaded?.Invoke(string.Empty);
        }

        public void SaveData(string data)
        {
            DataSaved?.Invoke(true);
        }

        public void SetScore(string leaderboardName, int value)
        {
            Debug.Log($"Leaderboard [{leaderboardName}] updated with score: {value}.");
        }
    }
}