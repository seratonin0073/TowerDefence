using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySettings : MonoBehaviour
{
    [SerializeField] private uint health = 3;
    [SerializeField] private float speed = 3f;
    [SerializeField] private float acceleration = 3f;

    public float Speed { get { return speed; }}
    public float Acceleration { get { return acceleration; } }
    public uint Health { get { return health; } }

    public void GetDamage(uint damage)
    {
        if (damage > health) return;
        health -= damage;
        if(health <= 0) Destroy(gameObject);
    }
}
