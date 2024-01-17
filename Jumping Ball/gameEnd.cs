using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class gameEnd : MonoBehaviour
{
    public int pointValue;
    public int highScore = 0;
    
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision){
         if (collision.gameObject.CompareTag("Player"))
        {
            
            pointValue = Mathf.FloorToInt(collision.gameObject.transform.position.z);
             if (pointValue > highScore)
            {
                highScore = pointValue;
                PlayerPrefs.SetInt("HighScore", highScore);
                PlayerPrefs.Save(); // PlayerPrefs verilerini kaydet
            }
           
            SceneManager.LoadScene(1);
        }
    }

    void OnTriggerEnter(Collider other){
         if (other.gameObject.CompareTag("Player"))
        {
            pointValue = Mathf.FloorToInt(other.gameObject.transform.position.z);
            
            
           
        }
    }

}
