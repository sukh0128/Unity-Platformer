using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] fireballs;

    private Animator anim;
    private PlayerMovement playerMovement;
    // The Humble object is a dependency of the PlayerAttack class - the Non-Humble class.
    private IPlayerAttackLogic attackLogic;
    
    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        // Create an instance of the Humble Object with the dependencies it needs.
        attackLogic = new PlayerAttackLogic(attackCooldown);
        attackLogic.Fireballs = fireballs;
    }

    private void Update()
    {
        bool attackRequested = Input.GetMouseButton(0) && playerMovement.canAttack();
        attackLogic.ProcessAttack(attackRequested);

        int fireBallIndex;
        if (attackLogic.ShouldAttack(out fireBallIndex))
        {
            Attack(fireBallIndex);
        }
    }

    private void Attack(int fireballIndex)
    {
        anim.SetTrigger("attack");

        fireballs[fireballIndex].transform.position = firePoint.position;
        fireballs[fireballIndex].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
    }

}