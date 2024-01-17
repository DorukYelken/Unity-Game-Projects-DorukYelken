using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Photon.Pun;
using Photon.Realtime;

public class ButtonClick : MonoBehaviourPunCallbacks
{
    
    private Rigidbody prefabRigidbody;
    public GameObject Player1;
    public GameObject Player2;
    public GameObject Player3;
    
    public Button buton;
    public Button buton2;
    public Button buton3;
    
    public bool explorerBool = false;
    private IEnumerator coroutine;
 private int buttonClickCount = 0;
    private int maxButtonClicks = 5; // Maksimum tıklama sayısı
    private float waitTimeBetweenClicks = 5f; // Tıklamalar arasındaki bekleme süresi
    

    void Start()
    {
         

       
            buton.onClick.AddListener(() => ButonaTiklandi(Player1, buton));
            buton2.onClick.AddListener(() => ButonaTiklandi2(Player2, buton2));
            buton3.onClick.AddListener(() => ButonaTiklandi(Player3, buton3));
         
    }
    

    

    // Buton tıklandığında çağrılacak metod
    void ButonaTiklandi(GameObject player, Button button)
    {
        Debug.Log(PhotonNetwork.PlayerList.Length.ToString());
         foreach (Player playerInList in PhotonNetwork.PlayerList)
        {
            Debug.Log("Player Name: " + playerInList.NickName);
        }
        if (PhotonNetwork.IsMasterClient)
        {
            // MasterClient'ın adını Debug.Log ile yazdır
            Debug.Log("Current MasterClient: " + PhotonNetwork.MasterClient.NickName);
        }
        if (buttonClickCount < maxButtonClicks)
        {
            coroutine = WaitforInstantiate(waitTimeBetweenClicks * buttonClickCount, player, button);
            StartCoroutine(coroutine);

            buttonClickCount++;
        }
    }

    void ButonaTiklandi2(GameObject player, Button button)
    {

        Debug.Log(PhotonNetwork.PlayerList.Length.ToString());
         foreach (Player playerInList in PhotonNetwork.PlayerList)
        {
            Debug.Log("Player Name: " + playerInList.NickName);
        }
        if (PhotonNetwork.IsMasterClient)
        {
            // MasterClient'ın adını Debug.Log ile yazdır
            Debug.Log("Current MasterClient: " + PhotonNetwork.MasterClient.NickName);
        }
        if (buttonClickCount < maxButtonClicks)
        {
            coroutine = WaitforInstantiate(waitTimeBetweenClicks * buttonClickCount, player, button);
            StartCoroutine(coroutine);

            buttonClickCount++;
        }
    }


    

  

    
private  GameObject playerInstance;

    private IEnumerator WaitforInstantiate(float waitTime , GameObject player , Button button)
    {
        if(button != buton){
            button.interactable = false;
            yield return new WaitForSeconds(waitTime);
        }else{
            button.interactable = true;
            yield return new WaitForSeconds(waitTime);
        }
       
        
        
        if (PhotonNetwork.IsConnected)
        {
            
           if (GetComponent<PhotonView>().IsMine)
    {
      townHallScript townHall = FindObjectOfType<townHallScript>();

      if (townHall != null)
     {
         if (townHall.totalWood >= 2 && townHall.totalFood >= 5 && player.name == "Player2")
        {
            playerInstance = PhotonNetwork.Instantiate(player.name, new Vector3(315f, 0.1f, 250f), Quaternion.identity);
            townHall.totalWood -= 2;
            townHall.totalFood -= 5;
        }

        else if (townHall.totalWood >= 4 && townHall.totalFood >= 10 && player.name == "Player3")
        {
            playerInstance = PhotonNetwork.Instantiate(player.name, new Vector3(600, 0.1f, 250f), Quaternion.identity);
            townHall.totalWood -= 4;
            townHall.totalFood -= 10;
        }
    }

    // This condition is now part of the original block
    if (player.name == "Player")
    {
        playerInstance = PhotonNetwork.Instantiate(player.name, new Vector3(315f, 0.1f, 250f), Quaternion.identity);
    }
}
        else
        {
            remoteTownHallScript remoteTownHall = FindObjectOfType<remoteTownHallScript>();
            if(player.name == "Player"){
                string remoteName = "remote" + player.name;
                playerInstance = PhotonNetwork.Instantiate(player.name, new Vector3(315f, 0.1f, 250f), Quaternion.identity);
            }else if (remoteTownHall != null && remoteTownHall.remoteTotalWood >= 2 && remoteTownHall.remoteTotalFood >= 5 && player.name == "Player2")
            {
            string remoteName = "remote" + player.name;
            // Instantiate the remote player object using PhotonNetwork
            playerInstance = PhotonNetwork.Instantiate(remoteName, new Vector3(330f, 0.1f, 245f), Quaternion.identity);
            remoteTownHall.remoteTotalWood -= 2;
            remoteTownHall.remoteTotalFood -= 5;
        }else if (remoteTownHall != null && remoteTownHall.remoteTotalWood >=  4  && remoteTownHall.remoteTotalFood >= 20 && player.name == "Player3")
            {
            string remoteName = "remote" + player.name;
            // Instantiate the remote player object using PhotonNetwork
            playerInstance = PhotonNetwork.Instantiate(remoteName, new Vector3(600f, 0.1f, 245f), Quaternion.identity);
            remoteTownHall.remoteTotalWood -= 4;
            remoteTownHall.remoteTotalFood -= 10;
        }
        }
    }
    else
    {
        // Instantiate the local player object if not connected to PhotonNetwork
        playerInstance = Instantiate(player, new Vector3(315f, 0.1f, 250f), Quaternion.identity);
    }
        yield return new WaitForSeconds(waitTime);
        prefabRigidbody = playerInstance.GetComponent<Rigidbody>();
        button.interactable = true;
        // Disable the button interaction after instantiation
        
    

    
}
}
