using UnityEngine;

namespace Kaynir.YandexGames.Services.Leaderboards
{
    public class TestLeaderboardService : MonoBehaviour, ILeaderboardService
    {
        public void SetScore(string leaderboard, int value)
        {
            Debug.Log($"{leaderboard} updated with score: {value}.");            
        }
    }
}
