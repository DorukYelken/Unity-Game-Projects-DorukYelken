using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteRoadGenerator : MonoBehaviour
{
    public GameObject cubePrefab;
    public GameObject Sphere;
    int checkZ = 0;
    float ranRang;
    void Start()
    {
          

    }

    // Update is called once per frame
    void Update()
    {
      GameObject sphereObjesi = GameObject.Find("Sphere");
          Mover moverScript = sphereObjesi.GetComponent<Mover>();
          float moveForceLimit = moverScript.moveForceLimit;
        
        if(Sphere.transform.position.z > 1000){
          ranRang = Random.Range(-12f, 1.5f);
        }else if(Sphere.transform.position.z > 5){
            moveForceLimit = 20f;

          ranRang = Random.Range(-12f, 2f);
        }else{
          ranRang = Random.Range(-12f, 2.5f);
        }
        
         int cubeZ = Mathf.FloorToInt(transform.position.z) + 40;
             
         if(cubeZ != checkZ){  
           checkZ = cubeZ ;  
         if(ranRang >= 0 ){
         Vector3 spawnPosition = new Vector3(0, 0, cubeZ);
         GameObject instantiatedObject = Instantiate(cubePrefab, spawnPosition, Quaternion.identity);
        }
        }
          }
        
        


    }

