using UnityEngine;

namespace Kaynir.YandexGames.Services.Authorization
{
    public class TestAuthService : MonoBehaviour, IAuthService
    {
        [SerializeField] private bool isAuthorized = false;

        public bool IsAuthorized => isAuthorized;
    }
}
