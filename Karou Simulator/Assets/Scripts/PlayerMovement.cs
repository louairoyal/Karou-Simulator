using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed;
    public Transform Orientation;
    float horizontalInput;
    float verticalInput;
    Vector3 MoveDirection;
    Rigidbody rb;

    // Start is called before the first frame update
    private void Start()
    {
        rb= GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }
    // Update is called once per frame
    private void Update()
    {
        MyInput();
    }
    private void FixedUpdate()
    {
        MovePlayer();
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Speed = 5;
        }
        else
        {
            Speed = 2;
        }
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }
    
    private void MovePlayer()
    {
        MoveDirection = Orientation.forward * verticalInput + Orientation.right * horizontalInput;
        rb.AddForce(MoveDirection.normalized * Speed * 10f, ForceMode.Force);
    }
}

