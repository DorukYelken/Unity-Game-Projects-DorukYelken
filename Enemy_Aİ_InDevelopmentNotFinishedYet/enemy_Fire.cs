using System.Collections;
using UnityEngine;

public class enemy_Fire : MonoBehaviour
{
    public GameObject enemy_bullet;
    public EnemyMover enemyMoverSC;
    void Start()
    {

        
           StartCoroutine(FiringRoutine());
        
    }

    IEnumerator FiringRoutine()
    {
        
            while (true)
            {
                yield return new WaitForSeconds(2f);
                FireBullet();
            }
        
        
    }

    void FireBullet()
    {
        enemyMoverSC = transform.parent.GetComponent<EnemyMover>();
        Debug.Log(enemyMoverSC.enemyMoveCheck);
        if (enemyMoverSC.enemyMoveCheck)
        {
            Instantiate(enemy_bullet, transform.position, transform.rotation);
        }
    }
}

