using UnityEngine;

namespace GameJuice
{
    public static class AudioSourceExtension
    {
        /// <summary>
        /// Plays an AudioClip with randomized volume and pitch
        /// </summary>
        /// <param name="audioSource">The audiosource to play the sound</param>
        /// <param name="audioClip">The audioclip to play</param>
        /// <param name="volumeVariation">How much under 1.0 the volume can be randomly set</param>
        /// <param name="pitchVariation">How much above and below 1.0 the pitch can be randomly set</param>
        public static void PlayWithVariation(this AudioSource audioSource, AudioClip audioClip, float volumeVariation = 0.1f, float pitchVariation = 0.1f)
        {
            audioSource.pitch = Random.Range(1f - pitchVariation, 1f + pitchVariation);
            audioSource.volume = Random.Range(1f - volumeVariation, 1f);
            audioSource.PlayOneShot(audioClip);
        }
    }
}
