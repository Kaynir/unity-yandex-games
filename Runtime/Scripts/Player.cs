using System;

namespace Kaynir.YandexGames
{
    [Serializable]
    public struct Player
    {
        public bool isAuthorized;

        public Player(int authStatus)
        {
            this.isAuthorized = authStatus == 1;
        }

        public Player(bool isAuthorized)
        {
            this.isAuthorized = isAuthorized;
        }
    }
}