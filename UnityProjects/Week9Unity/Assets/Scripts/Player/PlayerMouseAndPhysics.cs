using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMouseAndPhysics : MonoBehaviour
{
    [SerializeField] private float MoveSpeed = 1.0f;
    [SerializeField] private float RotationSpeed = 1.0f;

    [SerializeField] private Transform PlayerHead;

    private Rigidbody physicsBody;

    private float horizontalFacing = 0f;
    private float verticalFacing = 0f;

    void Start()
    {
        // Initialize Rigidbody and lock the cursor
        physicsBody = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Freeze rotation on the Rigidbody so it doesn’t spin with physics
        physicsBody.freezeRotation = true;
    }

    /// <summary>
    /// Look around with camera every frame in Update
    /// </summary>
    void Update()
    {
        MoveCameraWithMouse();
    }

    /// <summary>
    /// Move with physics only on Fixed Update
    /// </summary>
    private void FixedUpdate()
    {
        MoveWithPhysics();
    }

    private void MoveCameraWithMouse()
    {
        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X") * RotationSpeed * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * RotationSpeed * Time.deltaTime;

        // Calculate pitch (vertical rotation) and clamp it
        verticalFacing -= mouseY;
        verticalFacing = Mathf.Clamp(verticalFacing, -90f, 90f);

        horizontalFacing += mouseX;

        // Make the camera look up and down locally
        PlayerHead.localRotation = Quaternion.Euler(verticalFacing, 0f, 0f);
        // apply the horizontal rotation to the entire player body
        physicsBody.rotation = Quaternion.Euler(0f, horizontalFacing, 0f);
    }
    private void MoveWithPhysics()
    {
        // Get WASD input
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // Calculate movement direction relative to the player's orientation
        Vector3 moveDirection = transform.right * moveX + transform.forward * moveZ;

        // Apply velocity-based movement to the Rigidbody
        Vector3 velocity = moveDirection * MoveSpeed;
        // Preserve y velocity for gravity
        physicsBody.velocity = new Vector3(velocity.x, physicsBody.velocity.y, velocity.z); 
    }
}
