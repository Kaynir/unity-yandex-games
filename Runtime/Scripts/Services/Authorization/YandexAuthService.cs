using Kaynir.YandexGames.Tools;
using UnityEngine;

namespace Kaynir.YandexGames.Services.Authorization
{
    public class YandexAuthService : MonoBehaviour, IAuthService
    {
        public bool IsAuthorized => YandexPlugin.IsAuthorized();
    }
}