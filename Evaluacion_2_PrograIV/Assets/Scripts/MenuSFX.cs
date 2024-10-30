using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSFX : MonoBehaviour
{
    public static MenuSFX instance;

    [SerializeField] AudioClip select, move, back, error, purchase, start, startup, carMove, slider, bgm1, bgm2, bgm3;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this);
    }

    public void Select()
    {
        AudioSingleton.instance.PlaySFX(select);
    }

    public void Move()
    {
        AudioSingleton.instance.PlaySFX(move);
    }

    public void Back()
    {
        AudioSingleton.instance.PlaySFX(back);
    }

    public void Error()
    {
        AudioSingleton.instance.PlaySFX(error);
    }
    public void Purchase()
    {
        AudioSingleton.instance.PlaySFX(purchase);
    }

    public void Start_()
    {
        AudioSingleton.instance.PlaySFX(start);
    }

    public void Startup()
    {
        AudioSingleton.instance.PlaySFX(startup);
    }
    public void Slider()
    {
        AudioSingleton.instance.PlaySFX(slider);
    }

    public void StartBGM()
    {
        int rand = Random.Range(1, 4);
        if(rand == 1)
        {
            AudioSingleton.instance.ChangeMusic(bgm1);
        }
        else if(rand == 2)
        {
            AudioSingleton.instance.ChangeMusic(bgm2);
        }
        else if (rand == 3)
        {
            AudioSingleton.instance.ChangeMusic(bgm3);
        }
    }

    public void StopBGM()
    {
        AudioSingleton.instance.PauseMusic();
    }
}
