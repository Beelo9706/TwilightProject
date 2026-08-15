using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;
    

    public float lookRadius = 15f;
    public float attackRadius = 1.2f;
    
    NavMeshAgent agent;

    public Transform attackPoint;
    public int enemyDamage = 10;
    public LayerMask playerLayer;
    public float attackRate;
    float attackDelay;
    public Animator animator; 


    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        

        

        
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
