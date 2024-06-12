using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

public class TankController : MonoBehaviour
{
    public float movementSpeed;
    public float rotationSpeed;
    private GameObject ammo;
    public GameObject muzzle;
    public float shootingForce;

    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float sideForce = Input.GetAxis("Horizontal") * rotationSpeed;
        if (sideForce != 0.0f)
        {
            rb.angularVelocity = new Vector3(0.0f, sideForce, 0.0f);
        }
        else
        {
            rb.angularVelocity = Vector3.zero;
        }

        float forwardForce = Input.GetAxis("Vertical") * movementSpeed;
        if (forwardForce != 0.0f)
        {
            rb.velocity = rb.transform.forward * forwardForce;
        }
        else
        {
            rb.velocity = Vector3.zero;
        }

        SpawnAndFire();

    }
    public void OnTriggerEnter(Collider collider)
    {
        ammo = collider.GetComponent<ShootingZone>().shell;
    }

    public void OnTriggerExit(Collider other)
    {
        ammo = null;
    }

    public void SpawnAndFire()
    {
        if (Input.GetMouseButtonDown(0) && ammo != null)
        {
            Vector3 startPos = muzzle.transform.position;
            Quaternion startRot = muzzle.transform.rotation;
            GameObject shell = Instantiate(ammo, startPos, startRot);
            Rigidbody rigidbody = shell.GetComponent<Rigidbody>();
            rigidbody.AddForce(shell.transform.forward * shootingForce, ForceMode.Impulse);
        }
    }
}


