namespace Kaynir.YandexGames.Services.Leaderboards
{
    public interface ILeaderboardService
    {
        void SetScore(string leaderboard, int value);
    }
}