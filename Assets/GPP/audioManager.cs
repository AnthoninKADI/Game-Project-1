using UnityEngine;
using UnityEngine.Audio;

public class audioManager : MonoBehaviour
{

    public AudioClip[] playlist;
    public AudioSource audioSource;
    private int musicIndex = 0;
    public static audioManager instance;
    public AudioMixerGroup soundEffectMixer;

    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = playlist[0];
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying)
        {
            PlayNextSong();
        }
    }

    private void PlayNextSong()
    {
        musicIndex = (musicIndex + 1) % playlist.Length;
        audioSource.clip = playlist[musicIndex];
        audioSource.Play();
    }
}