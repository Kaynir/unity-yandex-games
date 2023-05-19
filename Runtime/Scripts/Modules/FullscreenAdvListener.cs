using UnityEngine;
using UnityEngine.Events;

namespace Kaynir.YandexGames.Modules
{
    public class FullscreenAdvListener : MonoBehaviour
    {
        [SerializeField] private UnityEvent _advOpened = new UnityEvent();
        [SerializeField] private UnityEvent _advClosed = new UnityEvent();
        [SerializeField] private UnityEvent _advFailed = new UnityEvent();

        private void OnEnable()
        {
            YandexSDK.FullscreenAdvOpened += _advOpened.Invoke;
            YandexSDK.FullscreenAdvClosed += _advClosed.Invoke;
            YandexSDK.FullscreenAdvFailed += _advFailed.Invoke;
        }

        private void OnDisable()
        {
            YandexSDK.FullscreenAdvOpened -= _advOpened.Invoke;
            YandexSDK.FullscreenAdvClosed -= _advClosed.Invoke;
            YandexSDK.FullscreenAdvFailed -= _advFailed.Invoke;
        }
    }
}