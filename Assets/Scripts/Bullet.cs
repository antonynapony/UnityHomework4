using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Shell
{
    public override void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject, 1.5f);
    }
}
