using Unity.VisualScripting;
using UnityEngine;



public class EnemyCombat : MonoBehaviour
{

    Animator animator;
    public float attackRange = 0.5f;
    public Transform attackPoint;
    public int enemyDamage = 25;
    public LayerMask playerLayer;
    public float attackRate;
    float attackDelay;
    float attackRadius = 0;

    

    



    void Start()
    {
        
        
            // the second point is the position of the MonoBehaviour's transform
            
            
        
    }

        void Update()
        {

        
        }

    public void AttackOne()
    {
        animator.SetTrigger("Attack1");

        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayer);

        foreach (Collider2D player in hitPlayer)
        {
            player.GetComponent<PlayerScript>().PlayerHurt(enemyDamage);


        }
    }

   


}
