using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;

[RequireComponent(typeof(ReactiveTarget))]
public class WaneringAI : MonoBehaviour
{
    [SerializeField] private float speed = 3.0f;
    [SerializeField] private float obstacleRange = 5.0f;
    void Start()
    {

    }

    void Update()
    {
        ReactiveTarget? obj = GetComponent<ReactiveTarget>();
        if (obj.IsUnityNull() || obj.isDead) return;

        transform.Translate(0, 0, speed * Time.deltaTime);

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.SphereCast(ray, 0.75f, out hit))
        {
            if(hit.distance < obstacleRange)
            {
                float angle = Random.Range(-110, 110);
                transform.Rotate(0, angle, 0);
            }
        }
    }
}