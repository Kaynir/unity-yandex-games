using System.Runtime.InteropServices;

namespace Kaynir.YandexGames.Tools
{
    public static class YandexService
    {
        [DllImport("__Internal")]
        public static extern int GetSDKStatus();

        [DllImport("__Internal")]
        public static extern int GetAuthStatus();

        [DllImport("__Internal")]
        public static extern string GetDevice();

        [DllImport("__Internal")]
        public static extern string GetLanguage();

        [DllImport("__Internal")]
        public static extern void SaveData(string data);

        [DllImport("__Internal")]
        public static extern void LoadData();

        [DllImport("__Internal")]
        public static extern void SetLeaderboard(string id, int value);

        [DllImport("__Internal")]
        public static extern void ShowFullscreenAdv();

        [DllImport("__Internal")]
        public static extern void ShowRewardedAdv(int reward);
    }
}