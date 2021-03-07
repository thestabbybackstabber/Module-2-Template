using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PickupItem : MonoBehaviour, IPickup
{

    private Transform oldParent;
    private Rigidbody rb;


    void Start()
    {
        oldParent = transform.parent;
        rb = GetComponent<Rigidbody>();
    }

    public void Pickup(Transform newParent)
    {
        rb.isKinematic = true;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        transform.SetParent(newParent);

        transform.localPosition = Vector3.zero;
        transform.localEulerAngles = Vector3.zero;
    }

    public void Drop(float throwPower)
    {
        transform.SetParent(oldParent);
        rb.isKinematic = false;
        rb.AddForce(transform.forward * throwPower, ForceMode.VelocityChange);
    }
}
