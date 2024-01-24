using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    public float moveSpeed = 30f;
    public float fireRate = 1f;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public Rigidbody rb;
    public bool enemyMoveCheck;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        transform.rotation = Quaternion.identity;
    }

    void Update()
    {
        transform.rotation = Quaternion.identity;
        Vector3 playerPosition = GameObject.FindWithTag("Player").transform.position;
        float distance = Vector3.Distance(playerPosition, transform.position);

        if(distance < 10f )
        {
            enemyMoveCheck = true;
        }
        if(enemyMoveCheck)
        {
            transform.LookAt(playerPosition);
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

            transform.rotation = Quaternion.identity;
        }
            
        
        
        
    }

    
}

