using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(ReactiveTarget))]
public class WanderingAI : MonoBehaviour
{
    [SerializeField] private float speed = 3.0F;
    [SerializeField] private float obstacleRange = 5.0F;

    [SerializeField] private GameObject FireballPrefab;
    [SerializeField] private float rotationCooldown = 2.0f;

    private GameObject _fireball;

    private float lastFireTime = -Mathf.Infinity;

    void Update()
    {
        ReactiveTarget obj = GetComponent<ReactiveTarget>();
        if (obj.IsUnityNull() || obj.isDead) return;

        transform.Translate(0, 0, speed * Time.deltaTime);

        if (Time.time < lastFireTime + rotationCooldown) return;

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.SphereCast(ray, 0.75f, out hit))
        {
            GameObject hitObject = hit.transform.gameObject;
            PlayerCharacter player = hitObject.GetComponent<PlayerCharacter>();

            if (player.IsUnityNull())
            {
                if (hit.distance < obstacleRange)
                {
                    float angle = Random.Range(-110.0f, 110.0f);
                    transform.Rotate(0, angle, 0);
                }
            }
            else
            {
                if (_fireball.IsUnityNull())
                {
                    _fireball = Instantiate(FireballPrefab);
                    _fireball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                    _fireball.transform.rotation = transform.rotation;

                    lastFireTime = Time.time;
                }
            }
        }
    }
}
