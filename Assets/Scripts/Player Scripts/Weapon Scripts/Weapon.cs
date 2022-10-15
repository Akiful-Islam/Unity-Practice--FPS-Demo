using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera playerCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 30f;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffect;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] float shotDelay = 0.5f;

    bool canShoot = true;
    void Update()
    {
        HandleShooting();
    }

    private void HandleShooting()
    {
        if (Input.GetMouseButtonDown(0) && canShoot)
        {
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        canShoot = false;

        if (ammoSlot.AmmoAmount > 0)
        {
            PlayMuzzleFlash();
            ProcessRaycast();
            ammoSlot.ReduceAmmo(1);
        }
        yield return new WaitForSeconds(shotDelay);

        canShoot = true;
    }

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, range))
        {
            HandleHitImpact(hit);
            DamageTarget(hit);
            Debug.Log("I hit " + hit.transform.name);
        }
        else
        {
            Debug.Log("I hit nothing");
        }
    }

    private void HandleHitImpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 0.1f);
    }

    private void DamageTarget(RaycastHit hit)
    {
        EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
        if (target == null)
            return;
        target.TakeDamage(damage);
    }
}
