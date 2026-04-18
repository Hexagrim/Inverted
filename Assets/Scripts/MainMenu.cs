using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Animator Anim;
    public string MainLevel;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Play()
    {
        StartCoroutine(StartPlay());
    }
    IEnumerator StartPlay()
    {
        Anim.SetTrigger("fade");
        yield return new WaitForSeconds(0.26f);
        SceneManager.LoadSceneAsync(MainLevel);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
