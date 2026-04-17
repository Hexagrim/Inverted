using NUnit.Framework.Constraints;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    public string NextLevelName;
    public Transform PlayerT;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    IEnumerator StartTransition()
    {
        PlayerT.GetComponent<Player>().enabled = false;
        PlayerT.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        StartCoroutine(LerpToPosition(transform.position, 0.1f));
        yield return new WaitForSeconds(0.25f);
        SceneManager.LoadSceneAsync(NextLevelName);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(StartTransition());
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
