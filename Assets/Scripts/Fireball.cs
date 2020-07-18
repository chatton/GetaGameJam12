using System;
using UnityEngine;

public class Fireball : MonoBehaviour
{

    private Spawner Spawner;
    public FireColour FireColour;
    private ScoreTracker ScoreTracker;

    public Action OnDestruction { get; internal set; }

    // Start is called before the first frame update
    void Start()
    {
        
        Spawner = FindObjectOfType<Spawner>();
        ScoreTracker = FindObjectOfType<ScoreTracker>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Tile tile = other.gameObject.GetComponent<Tile>();

        if (tile == null)
        {
            return;
        }


        Spawner.UnRegisterTile(tile);
        //ScoreTracker.DecreaseScore(5);
        Destroy(other.gameObject);
    }

    private void OnDestroy()
    {
       
        OnDestruction?.Invoke();
    }
}
