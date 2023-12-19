using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    [SerializeField] public float maxHP;
    public float currentHP;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damageAmount)
    {
        currentHP -= damageAmount;

        if (currentHP <= 0)
        {
            currentHP = 0;
            Die();
        }
    }

    void Die()
    {
        animator.SetTrigger("Dead");
        GameManager.instance.GameOver();
        for (int index = 3; index < transform.childCount; index++)
        {
            transform.GetChild(index).gameObject.SetActive(false);
        }
        //Destroy(gameObject);
        Debug.Log("Die");
    }
}
