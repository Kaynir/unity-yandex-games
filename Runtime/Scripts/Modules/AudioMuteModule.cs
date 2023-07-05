using Kaynir.YandexGames.Services;
using UnityEngine;
using UnityEngine.Audio;

namespace Kaynir.YandexGames.Modules
{
    [RequireComponent(typeof(IAdvService))]
    public class AudioMuteModule : MonoBehaviour
    {
        private const float MUTE_TRANSITION_TIME = 0f;

        [SerializeField] private AudioMixerSnapshot _muteSnapshot = null;
        [SerializeField] private AudioMixerSnapshot _defaultSnapshot = null;
        [SerializeField, Min(0f)] private float _defaultTransitionTime = 1f;

        private IAdvService _advService;

        private void Awake()
        {
            _advService = GetComponent<IAdvService>();

            _advService.AdvOpened += OnAdvOpened;
            _advService.AdvClosed += OnAdvClosed;
        }

        private void OnDestroy()
        {
            _advService.AdvOpened -= OnAdvOpened;
            _advService.AdvClosed -= OnAdvClosed;
        }

        private void OnAdvOpened()
        {
            _muteSnapshot.TransitionTo(MUTE_TRANSITION_TIME);
        }

        private void OnAdvClosed()
        {
            _defaultSnapshot.TransitionTo(_defaultTransitionTime);
        }
    }
}