using UnityEngine;

namespace Kore.Audio
{
    [AddComponentMenu("Kore/Audio/RandomAudioPlayer")]
    public class RandomAudioPlayer : MonoBehaviour
    {
        public AudioSource audioSource;
        public bool randomPitch = true;
        [Range(0, .05f)] public float pitchRange = .02f;
        public bool playOnAwake;
        public AudioClip[] clips;

        private float initPitch;

        private AudioClip randomClip => clips.Random();

        private void Awake()
        {
            initPitch = audioSource.pitch;
            if (playOnAwake)
            {
                Play();
            }
        }

        public void Play()
        {
            audioSource.pitch = initPitch;

            if (randomPitch)
            {
                audioSource.pitch += Random.Range(-pitchRange, pitchRange);
            }

            audioSource.PlayOneShot(randomClip);
        }
    }
}
