using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackCollision : MonoBehaviour
{
    public LayerMask playerLayer;
    public float radius;
    private bool collided;

    public Transform hitPoint;
    public float damageCount;

    private PlayerHealth playerHealth;

    // Start is called before the first frame update
    void Awake()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] hits = Physics.OverlapSphere(hitPoint.position, radius, playerLayer);
        foreach(Collider c in hits)
        {
            if (c.isTrigger)
            {
                continue;
            }
            collided = true;
            if (collided)
            {
                playerHealth.TakeDamage(damageCount);
            }
        }
        
    }
}
