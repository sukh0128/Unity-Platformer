using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackLogic : IPlayerAttackLogic
{
    private readonly float attackCooldown;
    private float cooldownTimer = Mathf.Infinity;
    public GameObject[] Fireballs { get; set; }

    public PlayerAttackLogic(float attackCooldown)
    {
        this.attackCooldown = attackCooldown;
        this.cooldownTimer = attackCooldown;
    }

    public void ProcessAttack(bool attackRequested)
    {
        if(attackRequested)
        {
            cooldownTimer += Time.deltaTime;
        }
    }

    public bool ShouldAttack(out int fireballIndex)
    {
        if (cooldownTimer > attackCooldown)
        {
            cooldownTimer = 0;
            fireballIndex = FindFireball();
            return true;
        }

        fireballIndex = -1;
        return false;
    }
    
    private int FindFireball()
    {
        for (int i = 0; i < Fireballs.Length; i++)
        {
            if (!Fireballs[i].activeInHierarchy)
                return i;
        }
        return 0;
    }
}
