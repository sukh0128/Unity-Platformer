using UnityEngine;

public interface IPlayerAttackLogic
{
    GameObject[] Fireballs { get; set; }

    void ProcessAttack(bool attackRequested);
    bool ShouldAttack(out int fireballIndex);
}
