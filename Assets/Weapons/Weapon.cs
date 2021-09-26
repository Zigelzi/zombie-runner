using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] float gunRange = 100f;
    [SerializeField] int damage = 20;
    [SerializeField] AmmoType ammoType;
    [SerializeField] AudioClip shootingSoundEffect;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffect;
    [SerializeField] [Range(0, 5f)] float timeBetweenShots = 1f;

    AudioSource audioSource;
    Ammo ammo;
    bool canShoot = true;
    Camera playerCamera;
    

    void Awake()
    {
        playerCamera = GetComponentInParent<Camera>();
        audioSource = GetComponentInParent<AudioSource>();
        ammo = GetComponentInParent<Ammo>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleShooting();
    }

    void OnEnable()
    {
        // Ensure that the weapon delay is resetted when switching to weapon
        canShoot = true;
    }

    void HandleShooting()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (ammo.HasAmmo(ammoType) && canShoot)
            {
                StartCoroutine(Shoot());
            }
        }
    }

    IEnumerator Shoot()
    {
        canShoot = false;

        PlaySFX();
        PlayMuzzleFlash();
        ammo.Consume(ammoType);

        ProcessHit();

        yield return new WaitForSeconds(timeBetweenShots);
        
        canShoot = true;

    }

    void PlaySFX()
    {
        if (audioSource)
        {
            audioSource.PlayOneShot(shootingSoundEffect);
        }
    }

    void PlayMuzzleFlash()
    {
        if (muzzleFlash)
        {
            muzzleFlash.Play();
        }
    }

    void ProcessHit()
    {
        RaycastHit hit;
        bool hitObject = Physics.Raycast(playerCamera.transform.position, 
                                         playerCamera.transform.forward, 
                                         out hit, 
                                         gunRange);

        if (hitObject)
        {
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();

            PlayHitEffect(hit);

            if (target == null) { return; }

            target.TakeDamage(damage);
        }
        else
        {
            return;
        }
    }

    void PlayHitEffect(RaycastHit hit)
    {
        if (hitEffect == null) { return; }

        GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, .1f);
    }

    
}
