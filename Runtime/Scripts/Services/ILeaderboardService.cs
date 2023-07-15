namespace Kaynir.YandexGames.Services
{
    public interface ILeaderboardService
    {
        void SetScore(string leaderboardName, int value);
    }
}