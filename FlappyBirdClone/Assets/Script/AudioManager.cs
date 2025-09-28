using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource musicSource;
    public AudioSource sfxSource;
    public AudioClip backgroundMusicClip;
    public AudioClip jumpClip;
    public AudioClip scoreClip;
    public AudioClip dieClip;
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }
    void Start()
    {
        musicSource.clip = backgroundMusicClip;
        musicSource.loop = true;
        musicSource.Play();
    }
    public void PlaySoundEffect(Sound sound)
    {
        switch (sound)
        {
            case Sound.Jump:
                sfxSource.PlayOneShot(jumpClip);
                break;
            case Sound.Score:
                sfxSource.PlayOneShot(scoreClip);
                break;
            case Sound.Die:
                sfxSource.PlayOneShot(dieClip);
                break;
        }
    }
}
public enum Sound
{
    Jump,
    Score,
    Die
}
