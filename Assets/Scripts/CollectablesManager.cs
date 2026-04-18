using TMPro;
using UnityEngine;

public class CollectablesManager : MonoBehaviour
{
    public int totalCollectables;
    private int maxCollectables;

    public TMP_Text counterText;
    void Start()
    {
        maxCollectables = FindObjectsByType<Collectable>(FindObjectsSortMode.None).Length;
    }

    // Update is called once per frame
    void Update()
    {
        counterText.text = totalCollectables + "/" + maxCollectables;
    }
    public bool CanPass()
    {
        return totalCollectables == maxCollectables;
    }
}
