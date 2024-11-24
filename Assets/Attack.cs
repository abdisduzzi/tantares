using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private float timeAttack;
    public float startTimeAttack;

    public Transform attackPos;
    public LayerMask whatIsEnemies;
    //public Animator camAnim;
   // public Animator playerAnim;
    public float attackRange;
    public int damage;

    void Update(){

        if(timeAttack <= 0){
            if(Input.GetKey(KeyCode.Space)){
           //     camAnim.SetTrigger("shake");
       //         playerAnim.SetTrigger("attack");
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++){
                    enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
                }
            }

            timeAttack = startTimeAttack;
        } else {
            timeAttack -= Time.deltaTime;
        }
    }

    void OnDrawGizmoSelected(){

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}