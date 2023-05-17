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
            YandexSDK.Instance.FullscreenAdvOpened += _advOpened.Invoke;
            YandexSDK.Instance.FullscreenAdvClosed += _advClosed.Invoke;
            YandexSDK.Instance.FullscreenAdvFailed += _advFailed.Invoke;
        }

        private void OnDisable()
        {
            YandexSDK.Instance.FullscreenAdvOpened -= _advOpened.Invoke;
            YandexSDK.Instance.FullscreenAdvClosed -= _advClosed.Invoke;
            YandexSDK.Instance.FullscreenAdvFailed -= _advFailed.Invoke;
        }
    }
}