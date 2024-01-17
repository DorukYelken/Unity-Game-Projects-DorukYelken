using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class townHallScript : MonoBehaviourPunCallbacks
{
    public int totalWood;
    public int totalFood;
    public int numberOfGolds; // Unity Editor'da bağlantısını yapın
    public GUIStyle style;
    
    

    void OnGUI()
    {
        if (photonView.IsMine)
        {
        style.fontSize = 25;
        GUI.Label(new Rect(10, 90, 200, 20), "Gold: " + numberOfGolds.ToString(), style);
        // Ekranın sol üst köşesine sayıyı yazdır
        GUI.Label(new Rect(10, 170, 200, 20), "Wood: " + totalWood.ToString(), style);
        
        GUI.Label(new Rect(10, 260, 200, 20), "Food: " + totalFood.ToString(), style);

        }
        
    }
}
