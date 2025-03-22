using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private int maxTargets = 5;
    [SerializeField] private const int totalTargetsCount = 10;
    [SerializeField] private GameObject targetPrefab;

    private int remainingTargets = totalTargetsCount;
    private GameObject[] targets;
    private Vector3[] spawnPoints = new Vector3[5]
    {
       new Vector3(-20.9f, -6.84f, 1f),
        new Vector3(-4.4f, -6.84f, -13f),
        new Vector3(15.6f, -6.84f, -9f),
        new Vector3(11.6f, -6.84f, 17.25f),
        new Vector3(-17.4f, -6.84f, 17.25f)
    };

    void Start()
    {
        targets = new GameObject[maxTargets];
    }

    void Update()
    {
        if(remainingTargets <= 0) return;
        for (int i = 0; i < maxTargets; i++)
        {
            if (targets[i] == null)
            {
                remainingTargets--;
                targets[i] = Instantiate(targetPrefab);
                targets[i].transform.position = spawnPoints[Random.Range(0, spawnPoints.Length)];
                targets[i].transform.Rotate(0, Random.Range(0, 360), 0);
            }
        }
    }
}
