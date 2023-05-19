using UnityEngine;
using UnityEngine.Events;

namespace Kaynir.YandexGames.Modules
{
    public class VideoAdvListener : MonoBehaviour
    {
        [SerializeField] private UnityEvent _advOpened = new UnityEvent();
        [SerializeField] private UnityEvent _advClosed = new UnityEvent();
        [SerializeField] private UnityEvent _advFailed = new UnityEvent();
        [SerializeField] private UnityEvent<int> _advRewarded = new UnityEvent<int>();

        private void OnEnable()
        {
            YandexSDK.VideoAdvOpened += _advOpened.Invoke;
            YandexSDK.VideoAdvClosed += _advClosed.Invoke;
            YandexSDK.VideoAdvFailed += _advFailed.Invoke;
            YandexSDK.VideoAdvRewarded += _advRewarded.Invoke;
        }

        private void OnDisable()
        {
            YandexSDK.VideoAdvOpened -= _advOpened.Invoke;
            YandexSDK.VideoAdvClosed -= _advClosed.Invoke;
            YandexSDK.VideoAdvFailed -= _advFailed.Invoke;
            YandexSDK.VideoAdvRewarded -= _advRewarded.Invoke;
        }
    }
}