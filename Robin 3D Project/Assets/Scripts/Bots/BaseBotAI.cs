using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BaseBotAI : MonoBehaviour
{
    [SerializeField] public BaseBotData botData;

    protected NavMeshAgent agent;
    protected Animator animator;

    private TriggerArea triggerArea;

    protected BotState botState;

    private float cooldown = 3f;
    private int healthPoint;

    protected virtual void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        triggerArea = GetComponentInChildren<TriggerArea>();
    }

    protected virtual void Start()
    {
        cooldown = botData.cooldownTime;
        healthPoint = botData.healthPoint;

        ChangeState(BotState.Idle, "idle");
    }

    protected virtual void Update()
    {
        switch (botState)
        {
            case BotState.Idle:

                Idle();
                break;

            case BotState.Move:

                Move();
                break;

            case BotState.Attack:

                Attack();
                break;

            case BotState.Cooldown:

                Cooldown();
                break;
        }
    }

    protected void ChangeState(BotState newState, string newAnim)
    {
        botState = newState;

        ChangeAnimation(newAnim);
    }

    protected void Idle()
    {
        if (triggerArea.PlayerInRange)
        {
            ChangeState(BotState.Move, "move");
        }
    }

    protected void Move()
    {
        agent.SetDestination(triggerArea.Target.position);

        if(triggerArea.Distance <= 2f)
        {
            ChangeState(BotState.Attack, "attack");
        }
        else if (!triggerArea.PlayerInRange)
        {
            ChangeState(BotState.Idle, "idle");
        }
    }

    protected void Attack()
    {

    }

    public void StartCooldown()
    {
        ChangeState(BotState.Cooldown, "idle");
        Debug.Log("Start Cooldown");
    }

    protected void Cooldown()
    {
        cooldown -= Time.deltaTime;

        if(cooldown <= 0)
        {
            if (triggerArea.PlayerInRange)
            {
                ChangeState(BotState.Move, "move");
                cooldown = botData.cooldownTime;
            }
            else
            {
                ChangeState(BotState.Idle, "idle");
                cooldown = botData.cooldownTime;
            }
        }
    }

    protected virtual void Die()
    {
        ChangeState(BotState.Dead, "idle");
        agent.isStopped = true;
    }

    public void GetDamage(int damagePoint)
    {
        healthPoint -= damagePoint;

        if(healthPoint <= 0)
        {
            Die();
        }
    }

    private void ChangeAnimation(string newAnim)
    {
        animator.SetBool("idle", false);
        animator.SetBool("move", false);
        animator.SetBool("attack", false);

        animator.SetBool(newAnim, true);
    }

}
