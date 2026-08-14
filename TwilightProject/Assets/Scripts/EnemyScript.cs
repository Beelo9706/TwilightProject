using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;
    public float attackRange = 0.5f;
    public float attackRate;
    public float attackDelay;
    public float attackRadius = 5;

    public Transform other;
    EnemyCombat method;



    public float lookRadius = 15f;

    
    public Animator animator;

    Transform target;
    NavMeshAgent agent;


    void Update()
    {
        float distance = Vector2.Distance(other.position, transform.position);



        if (distance <= attackRadius && attackRate >= attackDelay)
        {
            //Attack Player

            method.AttackOne();
            attackDelay = Time.time + 1f / attackRate;
            Debug.Log("Enemy Attacking Player!");

        }

    }
    
    
    void Start()
    {
        currentHealth = maxHealth;
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


}
