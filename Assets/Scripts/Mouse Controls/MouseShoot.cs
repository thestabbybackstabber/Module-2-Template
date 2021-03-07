using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseShoot : MonoBehaviour
{
    public float range = 20;
    public float damage = 10;

    private Camera fpsCam;

    void Start()
    {
        fpsCam = Camera.main;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));

            RaycastHit hit;
            if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit,range))
            {
                if (hit.collider.GetComponent<IDamagable>() != null)
                {
                    hit.collider.GetComponent<IDamagable>().TakeDamage(damage);
                }
            }
        }
    }
}
