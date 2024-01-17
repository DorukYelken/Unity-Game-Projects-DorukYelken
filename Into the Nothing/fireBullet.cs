using UnityEngine;

public class fireBullet : MonoBehaviour
{
    public GameObject bulletPrefab; // Assign your bullet prefab in the Unity Editor
    public Transform crosshair; // Assign your crosshair's transform in the Unity Editor
    public float bulletSpeed = 10f; // Adjust the speed of the bullets

    void Update()
    {
        // Check if the left mouse button is clicked
        if (Input.GetMouseButtonDown(0))
        {
            // Fire a bullet towards the point the crosshair is looking at
            Fire();
        }
    }

    void Fire()
    {
        // Perform a raycast from the camera through the crosshair position
        Ray ray = Camera.main.ScreenPointToRay(crosshair.position);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            // Instantiate the bulletPrefab at the hit point
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

            // Get the direction from the bullet to the hit point
            Vector3 bulletDirection = (hit.point - bullet.transform.position).normalized;

            // Get the rigidbody component of the bullet (assuming it has one)
            Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();

            // Check if the bullet has a rigidbody component
            if (bulletRb != null)
            {
                // Apply force to the bullet in the direction of the hit point
                bulletRb.velocity = 10f * bulletDirection * bulletSpeed;
            }
            else
            {
                Debug.LogError("BulletPrefab does not have a Rigidbody component!");
            }
        }
    }
}

