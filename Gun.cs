using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class Gun : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private AudioClip hit;
    [SerializeField] private AudioSource source2;
    
    private float rorateOffset = 180f;
    [SerializeField] private Transform firepos;
    [SerializeField] private GameObject bulletPrefabs;
    [SerializeField] private float shoootDelay = 0.15f;
    private float nextshoot;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RorateGun();
        Shoot();
    }
    void RorateGun()
    {
        if (Input.mousePosition.x < 0 || Input.mousePosition.x > Screen.width || Input.mousePosition.y < 0 || Input.mousePosition.y > Screen.height)
        {
            return;
        }
        Vector3 displacement = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float angle = Mathf.Atan2(displacement.y, displacement.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle + rorateOffset);
        if (angle < -90 || angle > 90)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, -1, 1);
        }
    }
    void Shoot()
    {
        if (Input.GetMouseButtonDown(0) && Time.time > nextshoot)
        {
            source2.PlayOneShot(hit);
            nextshoot = Time.time + shoootDelay;
            Instantiate(bulletPrefabs, firepos.position, firepos.rotation);
            
        }
    }
}
