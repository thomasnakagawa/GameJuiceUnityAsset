using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameJuice;
public class MusicPulseReactor : MonoBehaviour
{
    public EasingFunction ef;
    public MusicPulseDetector.FREQ_RANGE freqRange = MusicPulseDetector.FREQ_RANGE.ALL;
    bool pulse = false;

    Coroutine pulseCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindObjectOfType<MusicPulseDetector>().RegisterListener(this, freqRange);
    }

    // Update is called once per frame
    void Update()
    {
        if (pulse)
        {
            if (pulseCoroutine == null)
            {
                pulseCoroutine = StartCoroutine(Tween.Vector3(
                    Vector3.one * 1.3f,
                    Vector3.one,
                    0.1f,
                    ef.Evaluate,
                    vec => transform.localScale = vec
                ).Then(() => pulseCoroutine = null));
                pulse = false;
            }
        }
    }

    public void OnPulse()
    {
        pulse = true;
    }
}
