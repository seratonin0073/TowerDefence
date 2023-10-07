using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
    [Header("Turret")]
    [SerializeField] private Transform target;
    [SerializeField] private float range = 3f;

    [Header("Bullet")] 
    [SerializeField] private GameObject Bullet;
    [SerializeField] private Transform[] GunBarrels;
    [SerializeField] private float coolDown = 1f;
    [SerializeField] private float turnSpeed = 1f;
    private bool isShoot = true;
    private int barrelCounter = 0;
    
    
    

    private void Start()
    {
        InvokeRepeating("FindTarget", 0f, 0.3f);
    }

    private void Update()
    {
        Look();
    }

    private void Look()
    {
        if (target != null)
        {
            Quaternion look = Quaternion.LookRotation(target.position - transform.position);
            transform.rotation = Quaternion.Lerp(transform.rotation, look, Time.deltaTime * turnSpeed);
            if (isShoot)
            {
                StartCoroutine(Shoot());
                isShoot = !isShoot;
            }
        }
    }
    
    IEnumerator Shoot()
    {
        GameObject bullet = Instantiate(Bullet, GunBarrels[barrelCounter].position, Quaternion.identity);
        bullet.transform.parent = null;
        bullet.GetComponent<BulletScript>().TakeForce(target);
        barrelCounter = ++barrelCounter % GunBarrels.Length;
        yield return new WaitForSeconds(coolDown);
        isShoot = !isShoot;
    }
    
    private void FindTarget()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject currentTarget = null;
        float distance = Mathf.Infinity;

        foreach (GameObject target in targets)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, target.transform.position);
            if (distanceToEnemy < distance)
            {
                distance = distanceToEnemy;
                currentTarget = target;
            }
        }

        if (distance <= range && currentTarget != null) this.target = currentTarget.transform;
        else this.target = null;
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
