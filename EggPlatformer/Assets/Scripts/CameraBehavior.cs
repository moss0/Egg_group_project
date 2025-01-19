using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    public Transform player;
    public float rotationSpeed = 5f, zoomSpeed = 5f;
    public float minZoomDistance = 2f, maxZoomDistance = 15f;

    private RaycastHit hit;
    private float _rotationX = 0f, _rotationY = 0f; 
    [SerializeField] private float _currentZoomDistance = 10f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        if (player == null) player = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed;
        _rotationX -= mouseY;
        _rotationY += mouseX;
        _rotationX = Mathf.Clamp(_rotationX, -90f, 90f);
        Quaternion targetRotation = Quaternion.Euler(_rotationX, _rotationY, 0f);



        float scrollWheel = Input.GetAxis("Mouse ScrollWheel");
        if (scrollWheel != 0)
        {
            float zoomAmount = scrollWheel * zoomSpeed;
            UpdateZoomDistance(zoomAmount);
        }


        if (Input.GetKeyDown(KeyCode.Escape)) Cursor.lockState = CursorLockMode.None;


        transform.rotation = targetRotation;
        
        if (Physics.Raycast(player.position, targetRotation * Vector3.back, out hit, _currentZoomDistance))
        {
            transform.position = hit.point;
            Debug.DrawLine(player.position, hit.point);
        }
        else
        {
            transform.position = player.position - targetRotation * Vector3.forward * _currentZoomDistance;
        }
    }

    private void UpdateZoomDistance(float zoomAmount)
    {
        _currentZoomDistance = Mathf.Clamp(_currentZoomDistance - zoomAmount, minZoomDistance, maxZoomDistance);
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collison.CompareTag("Solid"))
    //    {

    //    }
    //}



    /* scroll camera stuff


    RaycastHit cameraBackHit;
    if (Physics.Raycast(transform.position, -transform.forward,out cameraBackHit,))
    {
        transform.position = cameraBackHit.point;
    }


    */
}
