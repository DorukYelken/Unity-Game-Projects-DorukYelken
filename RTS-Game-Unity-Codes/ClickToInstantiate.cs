using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class ClickToInstantiate : MonoBehaviourPunCallbacks
{
    public GameObject prefab1;
    public GameObject prefab2;
    public GameObject prefab3;
    public GameObject prefab4;
    private bool isKey1 = false;
    private bool isKey2 = false;
    private bool isKey3 = false;
    private bool isKey4 = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            isKey1 = true;
            isKey2 = false;
            isKey3 = false;
            isKey4 = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            isKey1 = false;
            isKey2 = true;
            isKey3 = false;
            isKey4 = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            isKey1 = false;
            isKey2 = false;
            isKey3 = true;
            isKey4 = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            isKey1 = false;
            isKey2 = false;
            isKey3 = false;
            isKey4 = true;
        }


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isKey1 = false;
            isKey2 = false;
            isKey3 = false;
            isKey4 = false;
        }

        if (isKey1 && Input.GetMouseButtonDown(0))
        {
            

            if (photonView.IsMine)
            {
                townHallScript townHall = FindObjectOfType<townHallScript>();
                if (townHall != null && townHall.numberOfGolds >= 5 && townHall.totalWood >= 5)
                {
                   instantiateBuilding(prefab1);
                  
                    townHall.numberOfGolds -= 5;
                    townHall.totalWood -= 5;

                }
            }
            else
            {
                remoteTownHallScript remoteTownHall = FindObjectOfType<remoteTownHallScript>();
                if (remoteTownHall != null && remoteTownHall.remoteNumberOfGolds >= 5  && remoteTownHall.remoteTotalWood >= 5)
                {
                    instantiateBuilding(prefab1);
                    remoteTownHall.remoteNumberOfGolds -= 5;
                    remoteTownHall.remoteTotalWood -= 5;
                }
            }
        }

        if (isKey2 && Input.GetMouseButtonDown(0))
        {
            if (photonView.IsMine)
            {
                townHallScript townHall = FindObjectOfType<townHallScript>();
                if (townHall != null && townHall.numberOfGolds >= 5)
                {
                    instantiateBuilding(prefab2);
                    townHall.numberOfGolds -= 5;
                }
            }
            else
            {
                remoteTownHallScript remoteTownHall = FindObjectOfType<remoteTownHallScript>();
                if (remoteTownHall != null && remoteTownHall.remoteNumberOfGolds >= 5)
                {
                    instantiateBuilding(prefab2);
                    remoteTownHall.remoteNumberOfGolds -= 5;
                }
            }
        }

        if (isKey3 && Input.GetMouseButtonDown(0))
        {
            if (photonView.IsMine)
            {
                townHallScript townHall = FindObjectOfType<townHallScript>();
                if (townHall != null && townHall.numberOfGolds >= 5 && townHall.totalWood >= 5)
                {
                    instantiateBuilding(prefab3);
                    townHall.numberOfGolds -= 5;
                    townHall.totalWood -= 5;
                }
            }
            else
            {
                remoteTownHallScript remoteTownHall = FindObjectOfType<remoteTownHallScript>();
                if (remoteTownHall != null && remoteTownHall.remoteNumberOfGolds >= 5  && remoteTownHall.remoteTotalWood >= 5)
                {
                    instantiateBuilding(prefab3);
                    remoteTownHall.remoteNumberOfGolds -= 5;
                    remoteTownHall.remoteTotalWood -= 5;
                }
            }
        }

        if (isKey4 && Input.GetMouseButtonDown(0))
        {
            if (photonView.IsMine)
            {
                townHallScript townHall = FindObjectOfType<townHallScript>();
                if (townHall != null && townHall.numberOfGolds >= 20 && townHall.totalWood >= 20)
                {
                    instantiateBuilding(prefab4);
                    townHall.numberOfGolds -= 20;
                    townHall.totalWood -= 20;
                }
            }
            else
            {
                remoteTownHallScript remoteTownHall = FindObjectOfType<remoteTownHallScript>();
                if (remoteTownHall != null && remoteTownHall.remoteNumberOfGolds >= 20  && remoteTownHall.remoteTotalWood >= 20)
                {
                    instantiateBuilding(prefab4);
                    remoteTownHall.remoteNumberOfGolds -= 20;
                    remoteTownHall.remoteTotalWood -= 20;
                }
            }
        }
    }

    public void instantiateBuilding(GameObject prefabName)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Ray'in bir şeyi vurup vurmadığını kontrol et
        if (Physics.Raycast(ray, out hit))
        {
            // Tıklanan noktada prefabı instantiate et
            PhotonNetwork.Instantiate(prefabName.name, hit.point, Quaternion.identity);
        }
    }
}
