using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    Rigidbody rb;
    Rigidbody rb2;
    public float speed = 1000f; // Mermi h?z?
    public float destroyTime = 2f; // Mermi yok olma süresi
  
    void Start()
    {
        rb = GetComponent<Rigidbody>();
       


        MoveTowardsPlayer();
    }

   
    void MoveTowardsPlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        float distance = Vector3.Distance(player.transform.position, transform.position);
        if (player != null)
        {

            // Oyuncunun pozisyonunu hedef alarak, mermiyi bu yöne do?ru ilerlet
            Vector3 midpoint1 = (player.transform.position + transform.position) / 2;
            Debug.Log("midpoint1 : " + midpoint1);
            Vector3 midpoint2 = new Vector3(midpoint1.x , midpoint1.y + 10f, midpoint1.z);
            Vector3 direction = (midpoint2 - transform.position);
            
            
            
             
          //  rb.AddForce(direction );
            rb.velocity = direction ;
        }
        else
        {
            // E?er oyuncu bulunamazsa, mermiyi yok et
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.name == "Plane")
        {
            Destroy(this.gameObject);
        }

        if (collision.gameObject.name == "Player")
        {
           // Destroy(collision.gameObject);
        }


    }

}

