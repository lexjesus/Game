using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public float distance;
    public int damage;
    public LayerMask whatIsSolid;



    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, distance, whatIsSolid);
        if(hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Enemy")){
                hitInfo.collider.GetComponent<Enemy>().TakeDamage(damage);
                Destroy(gameObject);
            }
            
        }
        if(gameObject != null){
        Destroy(gameObject, lifeTime);}

        transform.Translate(Vector2.right * speed * Time.deltaTime);

        

    }
}
