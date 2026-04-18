using NUnit.Framework.Constraints;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    public string NextLevelName;
    public Transform PlayerT;
    public Animator T_Anim;

    public GameObject Particel;// yes particel not particle, you dumb ahh.
    void Start()
    {
        
    }

    void Update()
    {
        Particel.SetActive(FindFirstObjectByType<CollectablesManager>().CanPass());
    }
    IEnumerator StartTransition()
    {
        PlayerT.GetComponent<Player>().enabled = false;
        FindFirstObjectByType<AudioManager>().PlaySFX(FindFirstObjectByType<AudioManager>().End);
        PlayerT.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        StartCoroutine(LerpToPosition(transform.position, 0.1f));
        T_Anim.SetTrigger("fade");
        yield return new WaitForSeconds(0.25f);
        SceneManager.LoadSceneAsync(NextLevelName);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (FindFirstObjectByType<CollectablesManager>().CanPass())
            {
                StartCoroutine(StartTransition());
            }
        }
    }
    public IEnumerator LerpToPosition(Vector3 targetPos, float duration)
    {
        Vector3 startPos = PlayerT.position;
        float time = 0f;
        while (time < duration)
        {
            time += Time.deltaTime;
            float t = time / duration;
            PlayerT.position = Vector3.Lerp(startPos, targetPos, t);
            yield return null;
        }
        PlayerT.position = targetPos;
    }
}
