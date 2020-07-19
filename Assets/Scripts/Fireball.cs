using System;
using UnityEngine;

public class Fireball : MonoBehaviour
{

    private Spawner Spawner;
    public FireColour FireColour;
    private ScoreTracker ScoreTracker;
    [SerializeField] GameObject ExplisionPrefab;
    [SerializeField] AudioClip[] Sounds;

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
        Destroy(gameObject);
    }

    private void OnDestroy()
    {

        int index = UnityEngine.Random.Range(0, Sounds.Length);
        AudioSource.PlayClipAtPoint(Sounds[index], Camera.main.transform.position);
        if (FireColour == FireColour.RED)
        {
            Destroy(Instantiate(ExplisionPrefab, transform.position + Vector3.down, Quaternion.identity), 2f);
        }
        else {

            Destroy(Instantiate(ExplisionPrefab, transform.position, Quaternion.identity), 2f);
        }
       
        OnDestruction?.Invoke();
    }
}
