using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instantiate_enemy : MonoBehaviour
{
    public GameObject prefab; // Instantiate edilecek nesnenin prefab'?

    void Start()
    {
        // Belirli aral?klarla Instantiate metodu ça?r?lacak
        InvokeRepeating("NesneInstantiateEt", 0f, 3f);
    }

    void NesneInstantiateEt()
    {
        // Nesneyi instantiate et
        GameObject yeniNesne = Instantiate(prefab, new Vector3(30f, 1.5f, 30f), Quaternion.identity);

        // Olu?turulan nesneyi sahneye eklemek istiyorsan?z:
        // yeniNesne.transform.parent = transform;
    }
}
