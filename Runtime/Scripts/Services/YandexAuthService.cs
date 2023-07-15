using Kaynir.YandexGames.Tools;
using UnityEngine;

namespace Kaynir.YandexGames.Services
{
    public class YandexAuthService : MonoBehaviour, IAuthService
    {
        public bool IsAuthorized => YandexPlugin.IsAuthorized();
    }
}