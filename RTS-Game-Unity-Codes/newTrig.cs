using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class newTrig : MonoBehaviour
{
    
    public float interval = 5f; // Her kaç saniyede bir artırılacak
    private float timer = 0f;
    public townHallScript townHall;
    public remoteTownHallScript townHall2;
    public GUIStyle style;

    void Start()
    {
        // townHallScript referansını al
        townHall = FindObjectOfType<townHallScript>();
        townHall2 = FindObjectOfType<remoteTownHallScript>();
    }

    void OnTriggerStay(Collider other)
{
    // Check if the other collider has a Rigidbody component
    Rigidbody rb = other.GetComponent<Rigidbody>();

    // If a Rigidbody is found, reset its velocity to zero
    if (rb != null)
    {
        rb.velocity = Vector3.zero;

        // Increment numberOfGolds after a certain interval
        timer += Time.deltaTime;

        if (timer >= interval)
        {
            // Increment the count
            string firstSixCharacters = other.name.Substring(0, Mathf.Min(6, other.name.Length));
            if(firstSixCharacters == "Player"){
                townHall.numberOfGolds += 1;
            }else if(firstSixCharacters == "remote"){
                townHall2.remoteNumberOfGolds += 1;
            }

            // Reset the timer
            timer = 0f;
        }
    }
}
}

