using System;
using UnityEngine;

public class Fireball : MonoBehaviour
{

    private Spawner Spawner;
    public FireColour FireColour;

    public Action OnDestruction { get; internal set; }

    // Start is called before the first frame update
    void Start()
    {
        Spawner = FindObjectOfType<Spawner>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Tile tile = other.gameObject.GetComponent<Tile>();

        if (tile == null)
        {
            return;
        }

        Spawner.UnRegisterTile(tile);
        Destroy(other.gameObject);
    }

    private void OnDestroy()
    {
        OnDestruction?.Invoke();
    }
}
