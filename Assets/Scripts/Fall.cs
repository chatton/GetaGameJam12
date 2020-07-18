using UnityEngine;

public class Fall : MonoBehaviour
{

    [SerializeField] float Speed = 7.5f;

    void Update () => transform.position = new Vector3(transform.position.x, transform.position.y - Speed * Time.deltaTime, transform.position.z);

}
