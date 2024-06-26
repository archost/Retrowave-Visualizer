using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioVisualizer : MonoBehaviour
{
    private AudioSource _audioSource;

    public static float[] _samples = new float[512];

    public static float[] _freqBand = new float[8];

    public static float[] _bandBuffer = new float[8];

    private float[] _bufferDecrease = new float[8];

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        GetSpectrumAudioSource();
        MakeFrequencyBands();
        BandBuffer();
    }

    private void GetSpectrumAudioSource()
    {
        _audioSource.GetSpectrumData(_samples, 0, FFTWindow.Blackman);
    }

    private void MakeFrequencyBands()
    {
        for (int i = 0; i < 8; i++)
        {
            float avg = 0f;
            int sampleCount = (int)Mathf.Pow(2, i + 1);

            if (i == 7)
                sampleCount += 2;

            for (int count = 0; count < sampleCount; count++)
                avg += _samples[count] * (count + 1);

            avg /= sampleCount;
            _freqBand[i] = avg * 10;
        }
    }

    private void BandBuffer()
    {
        for (int i = 0; i < 8; i++)
        {
            if (_freqBand[i] > _bandBuffer[i])
            {
                _bandBuffer[i] = _freqBand[i];
                _bufferDecrease[i] = 0.005f;

            }
            if (_freqBand[i] < _bandBuffer[i])
            {
                _bandBuffer[i] -= _bufferDecrease[i];
                _bufferDecrease[i] *= 1.2f;
            }
        }
    }
}