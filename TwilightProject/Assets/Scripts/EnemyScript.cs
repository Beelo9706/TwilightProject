using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;

    public Animator animator;

    

    public float attackRange = 0.5f;
    public Transform attackPoint;
    static public int enemyDamage = 25;
    public LayerMask playerLayer;

    public float attackRate;
    float attackDelay;
    public Transform target;
    public float attackRadius = 4;
    public float lookRadius = 15;

    


    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        float distance = Vector2.Distance(target.position, transform.position);

        if (distance <= attackRadius && PlayerScript.currentPlayerHealth > 0)
        {
            AttackOne();
            attackDelay = Time.time + 1f / attackRate;
        }

    }

    void AttackOne()
    {
        animator.SetTrigger("AttackOne");


    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        animator.SetTrigger("Hurt");

        if(currentHealth <= 0)
        {
            Die();
        }

    }

    void Die()
    {
        Debug.Log("Enemy Died");
        this.enabled = false;

        GetComponent<Collider2D>().enabled = false;
    }

    

    public void ColliderEnabled()
    {
        transform.GetChild(0).GetComponent<Collider2D>().enabled = true;
    }

    public void ColliderDisabled()
    {
        transform.GetChild(0).GetComponent<Collider2D>().enabled = false;
    }


}
