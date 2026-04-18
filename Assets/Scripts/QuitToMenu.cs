using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitToMenu : MonoBehaviour
{
    public Animator Anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StartCoroutine(TransitionScene());
        }//yes why you red thios?>
    }
    IEnumerator TransitionScene()
    {
        Anim.SetTrigger("fade");
        yield return new WaitForSeconds(0.24f);
        SceneManager.LoadSceneAsync("MainMenu");
    }
}
