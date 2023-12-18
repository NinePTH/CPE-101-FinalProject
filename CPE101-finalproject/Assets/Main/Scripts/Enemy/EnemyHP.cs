using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    [SerializeField] float maxHP;
    public float currentHP;

    EnemyMovement EnemyMovementScript;

    Rigidbody2D rigid;
    Animator animator;
    WaitForFixedUpdate wait;
    Collider2D coll;
    SpriteRenderer spriter;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        currentHP = maxHP;
        animator = GetComponent<Animator>();
        wait = new WaitForFixedUpdate();
        EnemyMovementScript = GetComponent<EnemyMovement>();
        coll = GetComponent<Collider2D>();
        spriter = GetComponent<SpriteRenderer>();
        animator.SetBool("Dead", false);
    }


    public void TakeDamage(float damageAmount)
    {
        currentHP -= damageAmount;
        StartCoroutine(KnockBack());
        if (currentHP <= 0)
        {
            EnemyMovementScript.isLive = false;
            coll.enabled = false;
            rigid.simulated = false;
            spriter.sortingOrder = 1;
            currentHP = 0;
            Die();

        }
        else
        {
            animator.SetTrigger("Hit");
        }
    }

    IEnumerator KnockBack()
    {
        yield return wait;
        Vector3 playerPos = GameManager.instance.player.transform.position;
        Vector3 dirVec = transform.position - playerPos;
        rigid.AddForce(dirVec.normalized * 3, ForceMode2D.Impulse);
    }

    void Die()
    {
        animator.SetBool("Dead",true);
        Destroy(gameObject, 2f);
    }
}
