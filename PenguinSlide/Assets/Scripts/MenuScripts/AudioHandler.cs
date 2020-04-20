using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioHandler : MonoBehaviour
{
    public AudioClip sfx1;
    public AudioClip sfx2;
    public AudioSource sfx;
    public AudioSource music;
    Scene scene;

    private void Start()
    {
        scene = SceneManager.GetActiveScene();
    }

    private void Update()
    {
        if (scene.buildIndex != 0)
        {
            music.Stop();
        }
    }

    public void PlaySFX1()
    {
        sfx.PlayOneShot(sfx1, 0.3f);
    }
    public void PlaySFX2()
    {
        sfx.PlayOneShot(sfx2, 0.3f);

    }

}
