using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public Transform attackPos;
    public float attackRange;
    public LayerMask attackItem;
    public LayerMask saveItem;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Attack"))
        {
            StartCoroutine(doAttack());
        }
        
    }

    IEnumerator doAttack()
    {

            //then you can attack
            
            Collider2D[] attackPoint = Physics2D.OverlapCircleAll(attackPos.position, attackRange, attackItem);
            Collider2D[] savePoint = Physics2D.OverlapCircleAll(attackPos.position, attackRange, saveItem);
            yield return new WaitForSeconds(0.5f);
            for (int i = 0; i < attackPoint.Length; i++)
            {
                attackPoint[i].GetComponent<beAttacked>().attackReact();
            }
            for (int i = 0; i < savePoint.Length; i++)
            {
                Debug.Log("save");
                savePoint[i].GetComponent<doSave>().save();
            }

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
