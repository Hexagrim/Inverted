using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource Sfx;
    public AudioClip Jump;
    public AudioClip Flip;
    public AudioClip Collect;
    public AudioClip End;

    private AudioSource BgMusic;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        BgMusic = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(SceneManager.GetActiveScene().name == "MainMenu")
        {
            BgMusic.volume = 0.6f;
        }
        else
        {
            BgMusic.volume = 0.3f;
        }
    }
    public void PlaySFX(AudioClip clip)
    {
        Sfx.pitch = Random.Range(0.7f, 1.3f);
        Sfx.PlayOneShot(clip);
    }
}
