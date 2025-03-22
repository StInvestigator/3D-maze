using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class FPSInput : MonoBehaviour
{
    [SerializeField] private float BaseSpeed = 6.0F;
    private float CurrentSpeed;
    [SerializeField] private float Gravity = 9.8F;

    CharacterController _charController;

    void Start()
    {
        CurrentSpeed = BaseSpeed;
        _charController = GetComponent<CharacterController>();
    }
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal") * CurrentSpeed;
        float vertical = Input.GetAxis("Vertical") * CurrentSpeed;

        Vector3 movement = new Vector3(horizontal, 0, vertical);
        movement = Vector3.ClampMagnitude(movement, CurrentSpeed);
        movement.y -= Gravity;
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        _charController.Move(movement);
    }

    public IEnumerator ReduceSpeedTemporarily(float reductionFactor, float duration)
    {
        CurrentSpeed /= reductionFactor;
        yield return new WaitForSeconds(duration);
        CurrentSpeed = BaseSpeed;
    }
}
