using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public float playerSpeed = 15f, /*jumpForce = 30f,*/ gravityScale;

    private Rigidbody _rb;
    [SerializeField] private float _rbVelocityMax;

    //private bool _isGrounded;
    //private float _timer;
    private Camera _mainCamera;
    //private Vector3 reflectedVelocity;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _mainCamera = Camera.main;
        //Time.timeScale = 0.3f;
    }

    private void Update()
    {
        //if (!_isGrounded && FastApproximately(0.0f,_rb.velocity.y,0.1f))
        //{
        //    // Mathf.Abs(_rb.velocity.y);
        //    //Use this: Mathf.Approximately(1.0f, 10.0f / 10.0f)
        //    Debug.LogWarning("Height = " + _rb.transform.position.y);
        //}

    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");
        Vector3 cameraForward = Vector3.Scale(_mainCamera.transform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 movement = (cameraForward * moveVertical + _mainCamera.transform.right * moveHorizontal).normalized;
        _rb.AddForce(movement * playerSpeed);

        if (_rb.velocity.magnitude > _rbVelocityMax)
        {
            _rb.velocity = Vector3.ClampMagnitude(_rb.velocity, _rbVelocityMax);
        }

        //Debug.Log(_rb.velocity.magnitude);


        /*
        Debug.DrawLine(transform.position,  , Color.red);
        if (Physics.Raycast(transform.position,  , 0.51f))
        {
            _isGrounded = true;
        }
        else
        {
            _isGrounded = false;
        }
        */
        _rb.AddForce((gravityScale - 1) * _rb.mass * Physics.gravity);
    }
    public static bool FastApproximately(float a, float b, float threshold)
    {
        return ((a - b) < 0 ? ((a - b) * -1) : (a - b)) <= threshold;
    }
}