using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public bool shooting, ready, reloading;

    public ProjectileController projectile;
    public float force;

    public float fireRate;
    private float shotTimer;
    public float reloadSpeed;
    private float reloadTimer;

    public Transform firePoint;

    public int capacity;
    public int maxAmmo;
    public bool continuousFire;

    private int ammoLeft, ammoUsed;
    

    public Camera cam;
    

    private void Awake()
    {
        ammoLeft = capacity;
        ammoUsed = 0;
        ready = true;
    }

    private void Update() 
    {
        if (ammoUsed < maxAmmo)
        {
            if (reloading)
            {
                reloadTimer -= Time.deltaTime;
                if (reloadTimer <= 0)
                {
                    ammoLeft = capacity;
                    reloading = false;
                }
                else
                {
                    shooting = false;
                }
            }
            if (shooting)
            {
                shotTimer -= Time.deltaTime;
                if (shotTimer <= 0 && ammoLeft > 0)
                {
                    shotTimer = fireRate;
                    ProjectileController newProjectile = Instantiate(projectile, firePoint.position, firePoint.rotation) as ProjectileController;
                    newProjectile.speed = force;
                    ammoLeft--;
                    ammoUsed++;
                }
                if (ammoLeft <= 0)
                {
                    reloading = true;
                    reloadTimer = reloadSpeed;
                }
            }
            else
            {
                shotTimer = 0;
            }
        }
    }
}
