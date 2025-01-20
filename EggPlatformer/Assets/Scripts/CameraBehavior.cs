using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraBehavior : MonoBehaviour
{
    private GameObject player;
    public float rotationSpeed = 5f, zoomSpeed = 5f;
    public float minZoomDistance = 2f, maxZoomDistance = 15f;

    private RaycastHit hit;
    private float _rotationX = 0f, _rotationY = 0f;
    [SerializeField] private float _currentZoomDistance = 10f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        if (Time.timeScale > 0)
        {
            float mouseX = Input.GetAxisRaw("Mouse X") * rotationSpeed;
            float mouseY = Input.GetAxisRaw("Mouse Y") * rotationSpeed;
            _rotationX -= mouseY;
            _rotationY += mouseX;
            _rotationX = Mathf.Clamp(_rotationX, -90f, 90f);
            Quaternion targetRotation = Quaternion.Euler(_rotationX, _rotationY, 0f);



            float scrollWheel = Input.GetAxisRaw("Mouse ScrollWheel");
            if (scrollWheel != 0)
            {
                float zoomAmount = scrollWheel * zoomSpeed;
                UpdateZoomDistance(zoomAmount);
            }

            transform.rotation = targetRotation;
            if (Physics.Raycast(player.transform.position, targetRotation * Vector3.back, out hit, _currentZoomDistance, 1, QueryTriggerInteraction.Ignore))
            {
                transform.position = hit.point;
                Debug.DrawLine(player.transform.position, hit.point, Color.blue);
                //print("hit");
            }
            else
            {
                transform.position = player.transform.position - targetRotation * Vector3.forward * _currentZoomDistance;
                Debug.DrawLine(player.transform.position, transform.position , Color.red);
            }
        }
    }

    private void UpdateZoomDistance(float zoomAmount)
    {
        _currentZoomDistance = Mathf.Clamp(_currentZoomDistance - zoomAmount, minZoomDistance, maxZoomDistance);
    }
}