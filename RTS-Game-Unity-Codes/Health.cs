using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Health : MonoBehaviour
{
    Animator animator;
    private float timer=0f;
    private float timer2=0f;
    private float interval=5f;
     private float interval2= 5f;
    public int health=100;
    public float resistance = 0;
      public GUIStyle style;
    
    // Start is called before the first frame update
    void Start()
    {
        animator=GetComponent<Animator>();
         if (gameObject.CompareTag("Player2"))
        {
            health += 50;
        }else if (gameObject.CompareTag("Player3")){
            health += 100;
        }
    }
 
    // Update is called once per frame
    void Update()
    {
        timer2+=Time.deltaTime;
        if(health <= 0){
           animator.SetBool("isDie", true);
            StartCoroutine(waitForDestroy());
            
           
             
             timer2 = 0; 
             
             
        }
        
        
    }

    
    
    void Resistance(){

        string thisObjectName1 = gameObject.name;
        string objectNameSixCharacters = thisObjectName1.Substring(0, Mathf.Min(6, thisObjectName1.Length));
        if(objectNameSixCharacters == "remote"){
        float distancez = transform.position.z - 245.3f;
        float distancex = transform.position.x - 594f;
        float distance = (float)(Mathf.Sqrt(distancez*distancez + distancex*distancex));
        resistance = distance*0.02f;
        } else{
            float distancez = transform.position.z - 245.3f;
            float distancex = transform.position.x - 294.2f;
            float distance = (float)(Mathf.Sqrt(distancez*distancez + distancex*distancex));
            resistance = distance*0.02f;
        }
        
    }
    
    
    void OnCollisionStay(Collision other){
        Resistance();
        string otherName =other.gameObject.name;

        string firstSixCharacters = otherName.Substring(0, Mathf.Min(6, otherName.Length));

        string thisObjectName = gameObject.name;
        string objectNameSixCharacters = thisObjectName.Substring(0, Mathf.Min(6, thisObjectName.Length));

        Rigidbody rb= GetComponent<Rigidbody>();
        if(rb!=null && !firstSixCharacters.Equals(objectNameSixCharacters) ){
            if( firstSixCharacters.Equals("Player") || firstSixCharacters.Equals("remote")){
            rb.velocity=Vector3.zero;
            animator.SetBool("isWalking", false);
            animator.SetBool("isAttack", true);
            timer+=Time.deltaTime;
            if(timer>=interval){
               
            Health res = other.gameObject.GetComponent<Health>(); 
             if (res != null)
            {
               Debug.Log("rakippppp:    " + res.resistance);
            }
            Debug.Log("ana: " + resistance );
            
           if(res.resistance<50){
                health-=5;
                

             }else if(res.resistance>50 && res.resistance<100){
                health-=8;
                
             }else{
                health-=10;
               
             }
            timer=0f;
            
        }
       
        
    }
  }
}
void OnCollisionExit(Collision other){
    animator.SetBool("isAttack", false);
    animator.SetBool("isWalking", true);

    }

IEnumerator waitForDestroy()
    {
        // Coroutine içinde WaitForSeconds kullanarak belirli bir süre bekleyebiliriz.
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
