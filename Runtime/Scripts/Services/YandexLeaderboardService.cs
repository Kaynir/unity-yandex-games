using Kaynir.YandexGames.Tools;
using UnityEngine;

namespace Kaynir.YandexGames.Services
{
    public class YandexLeaderboardService : MonoBehaviour, ILeaderboardService
    {
        public void SetScore(string leaderboardName, int value)
        {
            YandexPlugin.SetLeaderboardScore(leaderboardName, value);
        }
    }
}