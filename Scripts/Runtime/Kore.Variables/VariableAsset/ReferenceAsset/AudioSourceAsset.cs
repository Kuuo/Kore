using UnityEngine;

namespace Kore.Variables
{
    [CreateAssetMenu(menuName = "Kore/VariableAsset/Reference/AudioSource")]
    public class AudioSourceAsset : ReferenceAsset<AudioSource>
    {
        public void PlayOneShot(AudioClip clip)
        {
            Reference.PlayOneShot(clip);
        }
    }
}
