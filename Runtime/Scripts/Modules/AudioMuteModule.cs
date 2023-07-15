using Kaynir.YandexGames.Services;
using UnityEngine;
using UnityEngine.Audio;

namespace Kaynir.YandexGames.Modules
{
    public class AudioMuteModule : MonoBehaviour
    {
        private const float MUTE_TRANSITION_TIME = 0f;

        [SerializeField] private AudioMixerSnapshot muteSnapshot = null;
        [SerializeField] private AudioMixerSnapshot defaultSnapshot = null;
        [SerializeField, Min(0f)] private float defaultTransitionTime = 1f;

        private IAdvService advService;

        private void Awake()
        {
            advService = YandexSDK.Instance.AdvService;

            advService.AdvOpened += OnAdvOpened;
            advService.AdvClosed += OnAdvClosed;
        }

        private void OnDestroy()
        {
            advService.AdvOpened -= OnAdvOpened;
            advService.AdvClosed -= OnAdvClosed;
        }

        private void OnAdvOpened()
        {
            muteSnapshot.TransitionTo(MUTE_TRANSITION_TIME);
        }

        private void OnAdvClosed()
        {
            defaultSnapshot.TransitionTo(defaultTransitionTime);
        }
    }
}