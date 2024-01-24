using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletCode : MonoBehaviour
{
    Rigidbody rb;
    float speed = 1000f;
    float pow = 2500f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        rb.velocity = transform.forward * speed * Time.deltaTime;
        Vector3 power = transform.forward;
        rb.AddForce (power * pow);
    }
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.name == "Plane")
        {
            Destroy(this.gameObject);
        }


    }

}
