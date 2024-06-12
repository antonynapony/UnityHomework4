using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Shell : MonoBehaviour
{
    public abstract void OnCollisionEnter(Collision collision);
}
