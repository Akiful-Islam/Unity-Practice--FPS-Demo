using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] int ammoAmount = 20;
    public int AmmoAmount { get => ammoAmount; }
    public void AddAmmo(int ammo)
    {
        ammoAmount += ammo;
    }

    public void ReduceAmmo(int ammo)
    {
        ammoAmount -= ammo;
    }
}
