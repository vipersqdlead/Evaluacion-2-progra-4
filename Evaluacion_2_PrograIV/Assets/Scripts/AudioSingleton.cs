using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSingleton : MonoBehaviour
{
    public static AudioSingleton instance;

    public AudioSource audioSourceBGM;
    [SerializeField] AudioSource audioSourceSFX;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void ChangeMusic(AudioClip newClip)
    {
        audioSourceBGM.clip = newClip;
        audioSourceBGM.Play();
    }

    public void PauseMusic()
    {
        audioSourceBGM.Pause();
    }

    public void UnPauseMusic()
    {
        audioSourceBGM.UnPause();
    }

    public void PlaySFX(AudioClip sfxClip)
    {
        audioSourceSFX.PlayOneShot(sfxClip);
    }

    public IEnumerator FadeOut()
    {
        while (audioSourceBGM.volume > 0)
        {
            audioSourceBGM.volume -= Time.deltaTime;
            yield return null;
        }
        yield break;
    }
}
