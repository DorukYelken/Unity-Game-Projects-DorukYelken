using UnityEngine;

public class FollowForDestroy : MonoBehaviour
{
    public GameObject Sphere;
    Vector3 distance;
    public float rotationSpeed = 5.0f;
    void Start()
    {
        distance = transform.position - Sphere.transform.position;
    }
    private void Update()
    {
        Vector3 newPosition = Sphere.transform.position + distance;
    newPosition.y = 0f; // Y ekseni pozisyonunu sıfır olarak ayarla
    transform.position = newPosition;
}
}

