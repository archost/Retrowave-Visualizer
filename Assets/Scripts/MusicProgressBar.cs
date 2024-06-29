using UnityEngine;
using UnityEngine.UI;

public class MusicProgressBar : MonoBehaviour
{

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private Slider progressSlider;

    private void Update()
    {
        if (audioSource.isPlaying && audioSource.clip != null)
        {
            float progress = audioSource.time / audioSource.clip.length;
            progressSlider.value = progress;
        }
    }
}