using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePoint;

    public AudioClip sound;
    public AudioSource audioSource;

    private float timeBtwShots;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    float distance = Vector3.Distance(transform.position, GameObject.FindWithTag("PlayerFantom").transform.position);

    if (distance < 10)
    {
        timeBtwShots += Time.deltaTime;

        if (timeBtwShots > 2)
        {
            timeBtwShots = 0;
            shoot();
        }
    }

    }

    void shoot()
    {
        audioSource.PlayOneShot(sound);
        Instantiate(bullet, firePoint.position, Quaternion.identity);
    }
}
