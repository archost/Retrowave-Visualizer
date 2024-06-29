using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFading : MonoBehaviour
{
    [SerializeField]
    private AudioSource _AudioSource;

    [SerializeField]
    private Image _image;

    private float _fadeTime = 5.0f;

    private void Start()
    {
        float delay = _AudioSource.clip.length;

        Invoke("FadeOut", 0f);
        
        Invoke("FadeIn", delay - _fadeTime - 1f);
    }

    private void FadeOut()
    {
        StartCoroutine(FadeOutCoroutine());
    }

    private IEnumerator FadeOutCoroutine()
    {
        Color currentColor = _image.color;

        while (currentColor.a > 0)
        {
            currentColor.a -= Time.deltaTime / _fadeTime;
            _image.color = currentColor;
            yield return null;
        }

        currentColor.a = 0;
        _image.color = currentColor;
    }

    private void FadeIn()
    {
        StartCoroutine(FadeInCoroutine());
    }

    private IEnumerator FadeInCoroutine()
    {
        Color currentColor = _image.color;

        while (currentColor.a < 1)
        {
            currentColor.a += Time.deltaTime / _fadeTime;
            _image.color = currentColor;
            yield return null;
        }

        currentColor.a = 1;
        _image.color = currentColor;
    }
}
