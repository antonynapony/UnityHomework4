using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : Shell
{
    private Vector3 lastVelocity;

    void Start()
    {
        lastVelocity = GetComponent<Rigidbody>().velocity;
    }

    public override void OnCollisionEnter(Collision collision)
    {
        var speed = lastVelocity.magnitude;
        var direction = Vector3.Reflect(lastVelocity, collision.contacts[0].normal);
        GetComponent<Rigidbody>().velocity = direction * speed;
    }
}
