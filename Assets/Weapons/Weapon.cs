using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] float gunRange = 100f;
    [SerializeField] int damage = 20;
    [SerializeField] AudioClip shootingSoundEffect;

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
        bool hitObject = false;
        hitObject = Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, gunRange);

        PlayShootingSFX();

        if (hitObject)
        {
            // TODO: Play shooting VFX
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();

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
}
