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
                
                attackDelay = Time.time + 1f / attackRate;
            }

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
