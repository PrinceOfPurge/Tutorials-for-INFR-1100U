using UnityEngine;


public class Player : MonoBehaviour
{
    [SerializeField] private float Speed ;
        Vector2 move;
        Vector2 rotate;
        Rigidbody rb;
    private float distanceToGround;
     bool isGrounded;
     public float jump = 5f;
    public float walkSpeed = 5f;
    
    

    private Vector3 _moveDirection;
    // Start is called before the first frame update
    float depth;
    private void Awake(){
        depth= GetComponent<Collider>(). bounds.extents.y;
        InputManager.Init(this);
        InputManager.SetGameControls();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position +=Speed * Time.deltaTime * _moveDirection;
        
        
            isGrounded = Physics.Raycast(transform.position, Vector3.down, depth);
        Debug.DrawRay(transform.position, Vector3.down * depth);
    }

    public void Jump()
    {
        if (isGrounded){
            Debug.Log ("can jump");
        rb.velocity = new Vector3(rb.velocity.x, jump, rb.velocity.z);
        rb.AddForce(Vector3.up * jump, ForceMode.Impulse);
        }
    }
    public void SetMovementDirection(Vector3 newDirection)
    {
        _moveDirection = newDirection;
    }
    
}
