using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public GameObject playerPrefab;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 offset = new Vector3(0f, 2f, 0f);
        transform.position = playerPrefab.gameObject.transform.position + offset;
    }
}
