using UnityEngine;

public class FollowSphereWithoutRoll : MonoBehaviour
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
        transform.position = Sphere.transform.position + distance;
}
}
