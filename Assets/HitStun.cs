using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitStun : MonoBehaviour
{
    /*
    public static void HitStun(float seconds)
    {
        Instance.StartCoroutine(Instance.HitStunIEnum(seconds));
    }

    public static void HitStun(int frames)
    {
        Instance.StartCoroutine(Instance.HitStunIEnum(frames));
    }

    private IEnumerator HitStunIEnum(float seconds)
    {
        float previousTimeScale = Time.timeScale;
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(seconds);
        Time.timeScale = previousTimeScale;
    }

    private IEnumerator HitStunIEnum(int frames)
    {
        float previousTimeScale = Time.timeScale;
        Time.timeScale = 0f;
        for (int frameCounter = 0; frameCounter < frames; frameCounter++)
        {
            yield return null;
        }
        Time.timeScale = previousTimeScale;
    }
    */
}
