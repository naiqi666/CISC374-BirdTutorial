using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] AudioSource audioSource;
    // Update is called once per frame
    [Header("clips")]
    public AudioClip background;
    public AudioClip gameOver;
    public AudioClip score;


    private void Start()
    {
        audioSource.clip = background;
        audioSource.loop = true;
        audioSource.Play();
    }
    public void playSound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
    // public void playBackground()
    // {
    //     playSound(background);
    // }

}
