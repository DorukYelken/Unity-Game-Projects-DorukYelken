using UnityEngine;
using UnityEngine.AI;
using Photon.Pun;
using Photon.Realtime;
public class Mover2 : MonoBehaviourPunCallbacks
{
    Animator animator;
    private NavMeshAgent navMeshAgent;
    public bool isPlayerSelected = false;

    private Vector3 destination;

    void Start()
    {
        // NavMeshAgent bileşenini al
        animator=GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        PhotonView photonView = GetComponent<PhotonView>();
        
    }

    void Update()
    {
        if(photonView.IsMine){
        
        
        if (Input.GetKeyDown(KeyCode.K))
        {
            isPlayerSelected = false;
        }

        if (Input.GetMouseButtonDown(0))
        {
            // Ray oluştur
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // Tıklanan obje bir oyuncu mu diye kontrol et
                if (hit.collider.CompareTag(gameObject.tag))
                {
                    // Birinci tıklamada oyuncuyu seç
                    isPlayerSelected = true;
                }
                else if (hit.collider.CompareTag("Player1"))
                {
                    // Birinci tıklamada oyuncuyu seçme
                    isPlayerSelected = false;
                }
                else if (hit.collider.CompareTag("Player3"))
                {
                    // Birinci tıklamada oyuncuyu seçme
                    isPlayerSelected = false;
                }
                else if (hit.collider.CompareTag("InvisibleCube") && !IsInsideCube())
                {
                    // Eğer tıklanan obje görünmez küp ve oyuncu küpün içinde değilse, küpe git
                    destination = hit.collider.transform.position;
                    navMeshAgent.SetDestination(destination);
                    isPlayerSelected = true;
                }
                else if (hit.collider.CompareTag("treeForWood") && !IsInsideTree())
                {
                    // Eğer tıklanan obje görünmez küp ve oyuncu treenin içinde değilse, treeye git
                    destination = hit.collider.transform.position;
                    navMeshAgent.SetDestination(destination);
                    isPlayerSelected = true;
                }
                else if (isPlayerSelected)
                {
                    // İkinci tıklamada tıklanan yere git
                    animator.SetBool("isWalking", true);
                    destination = hit.point;
                    navMeshAgent.SetDestination(destination);
                    isPlayerSelected = true;
                }
            }
        }
}
        // Her frame'de hareket animasyonunu güncelle
       
    }

    

    private bool IsInsideTree()
    {
        // Küpün içinde mi kontrolü yap
        Collider collider = GetComponent<Collider>();
        return collider.bounds.Intersects(navMeshAgent.gameObject.GetComponent<Collider>().bounds);
    }
    private bool IsInsideCube()
    {
        // Küpün içinde mi kontrolü yap
        Collider collider = GetComponent<Collider>();
        return collider.bounds.Intersects(navMeshAgent.gameObject.GetComponent<Collider>().bounds);
    }
}

