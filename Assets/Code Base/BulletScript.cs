using System;
using Unity.VisualScripting;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private uint damage = 2;
    [SerializeField] private float bulletSpeed = 20f;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, 6f);
    }

    public void TakeForce(Transform target)
    {
        transform.LookAt(target);
        Vector3 dir = target.position - transform.position;
        rb.AddForce(dir * bulletSpeed, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.GetComponent<EnemySettings>().GetDamage(damage);
            Destroy(gameObject);
        }
    }
}
