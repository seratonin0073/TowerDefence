using System;
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
        navMesh.speed = enemySetup.Speed;
        navMesh.acceleration = enemySetup.Acceleration;
        finishPosition = GameObject.FindGameObjectWithTag("Finish").transform.position;
        if (navMesh == null) navMesh = GetComponent<NavMeshAgent>();
        

    }

    void Start()
    {
        navMesh.destination = finishPosition;
    }

    void Update()
    {
        
    }

    

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Finish!!!");
        if (other.gameObject.CompareTag("Finish"))
        {
            Destroy(gameObject);
        }
    }
}
