using UnityEngine;

namespace Kore.Variables
{
    [CreateAssetMenu(menuName = "Kore/VariableAsset/Reference/AudioSource",
                     fileName = "AudioSource Reference")]
    public class AudioSourceAsset : ReferenceAsset<AudioSource>
    {
        public void PlayOneShot(AudioClip clip)
        {
            Reference.PlayOneShot(clip);
        }
    }
}
