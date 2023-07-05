using System.Runtime.InteropServices;

namespace Kaynir.YandexGames.Tools
{
    public static class YandexPlugin
    {
        [DllImport("__Internal")]
        public static extern bool IsAuthorized();

        [DllImport("__Internal")]
        public static extern string GetDevice();

        [DllImport("__Internal")]
        public static extern string GetLanguage();

        [DllImport("__Internal")]
        public static extern void SaveData(string data);

        [DllImport("__Internal")]
        public static extern void LoadData();

        [DllImport("__Internal")]
        public static extern void SetLeaderboardScore(string id, int value);

        [DllImport("__Internal")]
        public static extern void ShowFullscreenAdv();

        [DllImport("__Internal")]
        public static extern void ShowRewardedAdv(int reward);
    }
}