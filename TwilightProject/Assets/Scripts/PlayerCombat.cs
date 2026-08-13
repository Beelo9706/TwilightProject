using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    
    public float attackRange = 0.5f;
    public Transform attackPoint;
    public int spearDamage = 25;
    public LayerMask enemyLayer;

    public float attackRate;
    float attackDelay;

    void Update()
    {
        if(Time.time >= attackDelay)
        {
            if (Input.GetKeyDown(KeyCode.JoystickButton2) || Input.GetKeyDown(KeyCode.Mouse0))
            {
                Attack();
                attackDelay = Time.time + 1f / attackRate;
            }

        }

        
    }

    void Attack()
    {
        animator.SetTrigger("Attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyScript>().TakeDamage(spearDamage);

            
        }
    }

    private void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }


}
