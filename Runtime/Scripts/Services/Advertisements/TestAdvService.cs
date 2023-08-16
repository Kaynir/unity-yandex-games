using System;
using UnityEngine;

namespace Kaynir.YandexGames.Services.Advertisements
{
    public class TestAdvService : MonoBehaviour, IAdvService
    {
        public event Action AdvOpened;
        public event Action AdvClosed;
        public event Action AdvFailed;
        public event Action<int> AdvRewarded;

        [SerializeField] private bool enableFailed = false;

        public void ShowFullscreenAdv()
        {
            AdvOpened?.Invoke();

            if (enableFailed) AdvFailed?.Invoke();
            
            AdvClosed?.Invoke();
        }

        public void ShowRewardedAdv(int reward)
        {
            AdvOpened?.Invoke();
            
            if (enableFailed) AdvFailed?.Invoke();
            else AdvRewarded?.Invoke(reward);
            
            AdvClosed?.Invoke();
        }
    }
}