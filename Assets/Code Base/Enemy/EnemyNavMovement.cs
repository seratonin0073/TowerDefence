using UnityEngine;
using UnityEngine.AI;

public class EnemyNavMovement : MonoBehaviour
{
    private Vector3 finishPosition;
    private EnemySettings enemySetup;
    [SerializeField] private NavMeshAgent navMesh;
    void Awake()
    {
        enemySetup = GetComponent<EnemySettings>();
        finishPosition = GameObject.FindGameObjectWithTag("Finish").transform.position;
        if (navMesh == null) navMesh = GetComponent<NavMeshAgent>();
        navMesh.speed = enemySetup.Speed;
        navMesh.acceleration = enemySetup.Acceleration;
        

    }

    void Start()
    {
        navMesh.destination = finishPosition;
    }

    

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            Destroy(gameObject);
        }
    }
}
