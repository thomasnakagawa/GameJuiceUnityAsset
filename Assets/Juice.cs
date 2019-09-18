using GameJuiceBox;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJuiceBox
{
    public class Juice : MonoBehaviour
    {
        private static Juice Instance;

        // Start is called before the first frame update
        void Start()
        {
            Instance = this;
        }

        public static void HitStun(float time)
        {

        }

        public static IEnumerator Wait(float seconds)
        {
            yield return new WaitForSeconds(seconds);
        }

        public IEnumerator HitStunSeconds(float seconds)
        {
            float previousTimeScale = Time.timeScale;
            Time.timeScale = 0f;
            yield return new WaitForSecondsRealtime(seconds);
            Time.timeScale = previousTimeScale;
        }

        public IEnumerator HitStunFrames(int frames)
        {
            float previousTimeScale = Time.timeScale;
            Time.timeScale = 0f;
            for (int frameCounter = 0; frameCounter < frames; frameCounter++)
            {
                yield return null;
            }
            Time.timeScale = previousTimeScale;
        }
    }
}
