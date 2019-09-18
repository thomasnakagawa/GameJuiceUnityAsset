using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicPulseDetector : MonoBehaviour
{
    [SerializeField] private float BassThreshold = 0.5f;
    [SerializeField] private float MidThreshold = 0.5f;
    [SerializeField] private float HighThreshold = 0.5f;

    private AudioSource audioSource;

    private MusicPulseReactor reactor;

    private float[] samples = new float[64];

    public enum FREQ_RANGE
    {
        ALL, BASS, MID, HIGH
    }

    private Dictionary<FREQ_RANGE, List<MusicPulseReactor>> Listeners;

    // Start is called before the first frame update
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogException(new MissingComponentException("Must be attached to an AudioSource"), this);
        }

        Listeners = new Dictionary<FREQ_RANGE, List<MusicPulseReactor>>
        {
            [FREQ_RANGE.ALL] = new List<MusicPulseReactor>(),
            [FREQ_RANGE.BASS] = new List<MusicPulseReactor>(),
            [FREQ_RANGE.MID] = new List<MusicPulseReactor>(),
            [FREQ_RANGE.HIGH] = new List<MusicPulseReactor>(),
        };
    }

    private void Update()
    {
        audioSource.GetSpectrumData(samples, 0, FFTWindow.Blackman);

        bool isBassLoud = IsFreqOverThresh(0, 21, BassThreshold);
        if (isBassLoud)
        {
            foreach (MusicPulseReactor reactor in Listeners[FREQ_RANGE.BASS] )
            {
                reactor.OnPulse();
            }
        }
        bool isMidLoud = IsFreqOverThresh(21, 42, MidThreshold);
        if (isMidLoud)
        {
            foreach (MusicPulseReactor reactor in Listeners[FREQ_RANGE.MID])
            {
                reactor.OnPulse();
            }
        }
        bool isHighLoud = IsFreqOverThresh(42, 64, HighThreshold);
        if (isHighLoud)
        {
            foreach (MusicPulseReactor reactor in Listeners[FREQ_RANGE.HIGH])
            {
                reactor.OnPulse();
            }
        }

        if (isBassLoud || isMidLoud || isHighLoud)
        {
            foreach (MusicPulseReactor reactor in Listeners[FREQ_RANGE.ALL])
            {
                reactor.OnPulse();
            }
        }
    }

    private bool IsFreqOverThresh(int channelMin, int channelMax, float thresh)
    {
        float freqMax = 0f;
        for (int i = channelMin; i < channelMax; i++)
        {
            if (samples[i] > freqMax)
            {
                freqMax = samples[i];
            }
        }
        return freqMax >= thresh;
    }

    public void RegisterListener(MusicPulseReactor reactor, FREQ_RANGE freq_range)
    {
        Listeners[freq_range].Add(reactor);
    }
}
