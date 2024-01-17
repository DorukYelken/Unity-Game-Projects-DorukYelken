using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class remoteTownHallScript : MonoBehaviourPunCallbacks
{
    public int remoteTotalWood;
    public int remoteTotalFood;
    public int remoteNumberOfGolds; // Unity Editor'da bağlantısını yapın
    public GUIStyle style;
    
    void Start()
    {
        
       
    }
    void Update()
    {
        
       
    }

    void OnGUI()
    {
        if (photonView.IsMine == false)
        {
        style.fontSize = 25;
        GUI.Label(new Rect(10, 100, 200, 20), "Gold: " + remoteNumberOfGolds.ToString(), style);
        // Ekranın sol üst köşesine sayıyı yazdır
        GUI.Label(new Rect(10, 180, 200, 20), "Wood: " + remoteTotalWood.ToString(), style);
        
        GUI.Label(new Rect(10, 260, 200, 20), "Food: " + remoteTotalFood.ToString(), style);

        }
    }
}
