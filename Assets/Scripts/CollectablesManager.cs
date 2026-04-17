using UnityEngine;

public class CollectablesManager : MonoBehaviour
{
    public int totalCollectables;
    private int maxCollectables;


    void Start()
    {
        maxCollectables = FindObjectsByType<Collectable>(FindObjectsSortMode.None).Length;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool CanPass()
    {
        return totalCollectables == maxCollectables;
    }
}
