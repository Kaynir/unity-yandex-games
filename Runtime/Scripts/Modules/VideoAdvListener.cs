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
            YandexSDK.Instance.VideoAdvOpened += _advOpened.Invoke;
            YandexSDK.Instance.VideoAdvClosed += _advClosed.Invoke;
            YandexSDK.Instance.VideoAdvFailed += _advFailed.Invoke;
            YandexSDK.Instance.VideoAdvRewarded += _advRewarded.Invoke;
        }

        private void OnDisable()
        {
            YandexSDK.Instance.VideoAdvOpened -= _advOpened.Invoke;
            YandexSDK.Instance.VideoAdvClosed -= _advClosed.Invoke;
            YandexSDK.Instance.VideoAdvFailed -= _advFailed.Invoke;
            YandexSDK.Instance.VideoAdvRewarded -= _advRewarded.Invoke;
        }
    }
}