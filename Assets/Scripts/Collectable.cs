using UnityEngine;

public class Collectable : MonoBehaviour
{
    CollectablesManager colM;
    bool collected = false;
    public GameObject collectParticles;
    void Start()
    {
        colM = FindFirstObjectByType<CollectablesManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Collect()
    {
        colM.totalCollectables++;
        Instantiate(collectParticles, transform.position, Quaternion.identity);
        collected = true;
        Destroy(gameObject);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collected) return;
            Collect();
        }
    }
}
