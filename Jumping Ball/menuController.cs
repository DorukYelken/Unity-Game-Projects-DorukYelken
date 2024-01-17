using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public Text textComponent; 
    public string textScore; 
     void Start()
    {
        
        
        // Eğer textComponent değişkeni Unity Editörü üzerinden atanmışsa
        if (textComponent != null)
        {
            textScore = PlayerPrefs.GetInt("HighScore", 0).ToString();
            textComponent.text =  textScore ;
        }
        else
        {
            Debug.LogError("Text bileşeni atanmamış. Lütfen Unity Editörü üzerinden atama yapın.");
        }
    }
    public void PlayButton(){
       
        Debug.Log("PlayyyyyyyyYYYYYYY");
        SceneManager.LoadScene(0);
    }

    public void QuitButton(){
        Application.Quit();
    }
}

