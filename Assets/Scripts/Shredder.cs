using UnityEngine;

public class Shredder : MonoBehaviour
{


    private void OnCollisionEnter(Collision collision)
    {

 
    }


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.parent.gameObject.tag == "Player")
        {
            FindObjectOfType<GameEnder>().EndGame();
            return;
        }
        Destroy(collision.gameObject);
    }
}
