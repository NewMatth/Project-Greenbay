using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Rifle_Shoot_BANG_BANG : MonoBehaviour


{
    RaycastHit Hit;

    //Damage Enemy
    [SerializeField]
    float damageEnemy = 10f;

    [SerializeField]
    float damageAmmo = 10f;

    [SerializeField]
    Transform ShootPoint;

    [SerializeField]
    int currentammo;

    //weapon effects
    //muzzle flash
    public ParticleSystem MuzzleFlash;

    //GunAudio
    AudioSource GunAS;
    public AudioClip ShootAC;


    //rate of fire
    [SerializeField]
    float RateofFire;
    float NextFire = 0;

    [SerializeField]
    float WeaponRange;

    void Start()
    {
        MuzzleFlash.Stop();
        GunAS = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(Input.GetButton("Fire1") && currentammo > 0)
        {
            Shoot();
        }

    }

    void Shoot()
    {
        if (Time.time > NextFire)
        {
            NextFire = Time.time + RateofFire;

            currentammo--;

            GunAS.PlayOneShot(ShootAC);

            StartCoroutine(WeaponEffects());

            if (Physics.Raycast(ShootPoint.position, ShootPoint.forward, out Hit, WeaponRange))
            {
                if(Hit.transform.tag == "Enemy")
                {
                    Debug.Log("Hit Enemy");
                    EnemyHealth EnemyHealthScript = Hit.transform.GetComponent<EnemyHealth>();
                    EnemyHealthScript.DeductHealth(damageEnemy);
                    currentammo = currentammo + 10000;
                }
                else
                {
                    Debug.Log("Hit Something Else");
                }
                if(Hit.transform.tag == "Ammo")
                {
                    Debug.Log("Got Ammo!");
                    AmmoPickup AmmoPickupScript = Hit.transform.GetComponent<AmmoPickup>();
                    AmmoPickupScript.DeductHealth(damageAmmo);
                    currentammo = currentammo + 10000;
                }
            }
        }
    }

    IEnumerator WeaponEffects()
    {
        MuzzleFlash.Play();
        yield return new WaitForEndOfFrame();
        MuzzleFlash.Stop();
    }
}