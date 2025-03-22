using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class FPSInput : MonoBehaviour
{
    [SerializeField] private float Speed = 6.0F;
    [SerializeField] private float Gravity = 9.8F;

    CharacterController _charController;

    void Start()
    {
        _charController = GetComponent<CharacterController>();
    }
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal") * Speed;
        float vertical = Input.GetAxis("Vertical") * Speed;

        Vector3 movement = new Vector3(horizontal, 0, vertical);
        movement = Vector3.ClampMagnitude(movement, Speed);
        movement.y -= Gravity;
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        _charController.Move(movement);
    }
}
