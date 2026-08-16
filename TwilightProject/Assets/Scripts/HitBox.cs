using UnityEngine;

public class HitBox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.layer == 7)
        {
            GetComponent<PlayerScript>().TakeDamage(EnemyScript.enemyDamage);
        }


    }
}
