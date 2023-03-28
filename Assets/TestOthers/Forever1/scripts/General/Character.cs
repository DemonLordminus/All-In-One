using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Character : MonoBehaviour
{
    [Header("基本属性")]
    public float maxHealth;
    public float currentHealth;

    [Header("受伤无敌")]
    public float invulnerableDuration;
    private float invulneralbleCounter;
    public bool invulnerable;
    public UnityEvent<Transform> OnTakeDamage;
    public UnityEvent onDie;
    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if(invulnerable)
        {
            invulneralbleCounter -= Time.deltaTime;
            if(invulneralbleCounter<=0)
            {
                invulnerable = false;
            }
        }
    }

    public void TakeDamage(Attack attacker)
    {
        //Debug.Log(attacker.damage);
        if (invulnerable)
            return;
        if (currentHealth - attacker.damage > 0)
        {
            currentHealth -= attacker.damage;
            TriggerInvulnerable();
            //执行受伤
            OnTakeDamage?.Invoke(attacker.transform);
        }
        else
        {
            currentHealth = 0;
            //触发死亡
            onDie?.Invoke();
        }
    }
    //触发受伤无敌
    private void TriggerInvulnerable()
    {
        if(!invulnerable)
        {
            invulnerable = true;
            invulneralbleCounter = invulnerableDuration;
        }
    }
}
