using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicToggle : MonoBehaviour
{
    [SerializeField] AudioClip loseMusic=null;
    [SerializeField] AudioClip gameMusic=null;
    [SerializeField] AudioClip winMusic = null;
    [SerializeField] AudioSource audioSource=null;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = gameMusic;
        PlayMusic();
    }
    public void PlayMusic()
    {
        if (audioSource.isPlaying)
            return;
        audioSource.PlayOneShot(gameMusic);
        audioSource.loop = true;
    }
    public void StopMusic()
    {
        audioSource.Stop();

    }
    public void SetLoseMusic()
    {
        StopMusic();
        audioSource.PlayOneShot(loseMusic);
        PlayMusic();
    }
    public void SetGameMusic()
    {
        StopMusic();
        audioSource.PlayOneShot(gameMusic);
        PlayMusic();
    }
    public void SetWinMusic()
    {
        StopMusic();
        audioSource.PlayOneShot(winMusic);
        PlayMusic();
    }
}
