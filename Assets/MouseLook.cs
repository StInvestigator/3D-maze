using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private float sensitivityHorz = 9.0f;
    [SerializeField] private float sensitivityVert = 9.0f;
    [SerializeField] private float minVertAngle = -45.0f;
    [SerializeField] private float maxVertAngle = 45.0f;

    private float rotationX = 0f;
    private Transform playerBody;

    void Start()
    {
        playerBody = transform.parent;
        rotationX = transform.localEulerAngles.x;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
        rotationX = Mathf.Clamp(rotationX, minVertAngle, maxVertAngle);
        transform.localEulerAngles = new Vector3(rotationX, 0, 0);

        float rotationY = Input.GetAxis("Mouse X") * sensitivityHorz;
        playerBody.Rotate(0, rotationY, 0);
    }
}
