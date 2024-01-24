using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.PlayerSettings;

public class enemyHealth : MonoBehaviour
{
    public int health = 1;
    Rigidbody rb;
    Vector3 pos;
    public float itmeGucu = 10f;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
       

    }

    // Update is called once per frame
    void Update()
    {
       
        if(health <= 0)
        {
            Destroy(gameObject);
        }
        pos = transform.position;

    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "bullet")
        {


            rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
            
            
            health --;  
            
            Destroy(collision.gameObject);
            
            transform.rotation = Quaternion.identity;
        }
    }
    }
