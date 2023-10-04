using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float Speed ;
    [SerializeField] private LayerMask groundLayers;
        Vector2 move;
        Vector2 rotate;
        Rigidbody rb;
        private float depth;
        public MovementState state;
        public enum MovementState
        {
            walking,
            sprinting,
            air,
        }
    private float distanceToGround;
     bool isGrounded;
     public float jump = 5f;
    public float walkSpeed = 5f;
    public float sprintSpeed;
    [Header("keybind for sprint")]
    public KeyCode sprintKey = KeyCode.LeftShift;
   

    private Vector3 _moveDirection;
    // Start is called before the first frame update    

    private void Awake(){
        InputManager.Init(this);
        InputManager.SetGameControls();
        rb = GetComponent<Rigidbody>();
        depth = GetComponent<Collider>().bounds.size.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position +=Speed * Time.deltaTime * _moveDirection;
        
        
            isGrounded = Physics.Raycast(transform.position, Vector3.down,depth, groundLayers);
        Debug.DrawRay(transform.position, Vector3.down * depth,
            Color.green, duration: 0, depthTest: false);
        
    }


    public void Jump()
    {
        if (isGrounded)
        {
        Debug.Log("jump called");
        rb.AddForce(Vector3.up * jump, ForceMode.Impulse);
        }
    }

    public void SetMovementDirection(Vector3 newDirection)
    {
        _moveDirection = newDirection;
    }
        
    
    
}
