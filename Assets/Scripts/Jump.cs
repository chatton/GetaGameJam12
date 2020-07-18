
using UnityEngine;

public class Jump : MonoBehaviour
{

    [SerializeField] float JumpHeight = 2f;
    [SerializeField] private float jumpForce = 2.0f;
    private Vector3 jump;
  

    private  bool isGrounded;
    private float rigidBodyY;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponentInChildren<Rigidbody>();
        rigidBodyY = rb.transform.position.y;
        jump = new Vector3(0.0f, JumpHeight, 0.0f);
    }



    void Update()
    {
        isGrounded = Mathf.Approximately(rb.transform.position.y, rigidBodyY);
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }
}
