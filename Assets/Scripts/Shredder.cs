using UnityEngine;

public class Shredder : MonoBehaviour
{


    private void OnCollisionEnter(Collision collision)
    {

        if (collision.transform.parent.gameObject.tag == "Player") {
            FindObjectOfType<GameEnder>().EndGame();
            return;
        }
        Destroy(collision.gameObject);
    }
}
