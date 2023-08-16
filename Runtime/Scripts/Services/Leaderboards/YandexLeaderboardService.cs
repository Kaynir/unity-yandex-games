using Kaynir.YandexGames.Tools;
using UnityEngine;

namespace Kaynir.YandexGames.Services.Leaderboards
{
    public class YandexLeaderboardService : MonoBehaviour, ILeaderboardService
    {
        public void SetScore(string leaderboard, int value)
        {
            YandexPlugin.SetLeaderboardScore(leaderboard, value);
        }
    }
}