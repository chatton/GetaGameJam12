using UnityEngine;

public class Fall : MonoBehaviour
{

    [SerializeField] float Speed = 10f;

    void Update () => transform.position = new Vector3(transform.position.x, transform.position.y - Speed * Time.deltaTime, transform.position.z);

}
