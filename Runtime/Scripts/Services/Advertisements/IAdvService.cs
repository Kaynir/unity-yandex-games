using System;

namespace Kaynir.YandexGames.Services.Advertisements
{
    public interface IAdvService
    {
        event Action AdvOpened;
        event Action AdvClosed;
        event Action AdvFailed;
        event Action<int> AdvRewarded;

        void ShowFullscreenAdv();
        void ShowRewardedAdv(int reward);
    }
}