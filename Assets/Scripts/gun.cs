using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    public float offset;
    public GameObject bullet;
    public Transform shortPoint;

    private float timeBtwshots;
    public float startTimeBtwShots;

    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

        

        if(timeBtwshots <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                Instantiate(bullet, shortPoint.position, transform.rotation);
                timeBtwshots = startTimeBtwShots;
            }
        }
        else
        {
            timeBtwshots -= Time.deltaTime;
        }
    }
}
