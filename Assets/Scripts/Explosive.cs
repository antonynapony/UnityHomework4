using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosive : Shell
{

    public float Radius;
    public float Force;


    public override void OnCollisionEnter(Collision collision)
    {
        Explode();
    }

    public void Explode()
    {
        Collider[] overLappedColliders = Physics.OverlapSphere(transform.position, Radius);

        for (int i = 0; i < overLappedColliders.Length; i++)
        {
            Rigidbody rb = overLappedColliders[i].attachedRigidbody;
            if (rb != null)
            {
                rb.AddExplosionForce(Force, transform.position, Radius);
            }
        }

        Destroy(gameObject);
    }
}
