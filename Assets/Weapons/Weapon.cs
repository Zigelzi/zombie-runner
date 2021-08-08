using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] float gunRange = 100f;
    [SerializeField] int damage = 20;
    [SerializeField] AudioClip shootingSoundEffect;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffect;

    Camera playerCamera;
    AudioSource audioSource;

    void Awake()
    {
        playerCamera = GetComponentInParent<Camera>();
        audioSource = GetComponentInParent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleShooting();
    }

    void HandleShooting()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        bool hitObject = Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, gunRange);

        PlayShootingSFX();
        PlayMuzzleFlash();

        if (hitObject)
        {
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            PlayHitEffect(hit);

            if (target == null) { return; }

            target.TakeDamage(damage);
            Debug.Log($"Hit: {hit.transform.name}!");
        }
        else
        {
            return;
        }
    }

    void PlayShootingSFX()
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

    void PlayHitEffect(RaycastHit hit)
    {
        if (hitEffect == null) { return; }
        GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, .1f);
    }
}
