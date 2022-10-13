using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera playerCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 30f;
    void Update()
    {
        HandleShooting();
    }

    private void HandleShooting()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, range))
        {
            Debug.Log("I hit " + hit.transform.name);

            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();

            if (target == null)
                return;

            target.TakeDamage(damage);
        }
        else
        {
            Debug.Log("I hit nothing");
        }
    }
}
