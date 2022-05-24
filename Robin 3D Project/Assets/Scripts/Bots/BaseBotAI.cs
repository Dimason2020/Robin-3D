using System;
using UnityEngine;
using UnityEngine.AI;

public class BaseBotAI : MonoBehaviour
{
    [SerializeField] public BaseBotData botData;

    protected RagdollController ragdollController;
    private CapsuleCollider capsuleCollider;
    protected NavMeshAgent agent;
    protected Animator animator;
    protected Player player;
    private Rigidbody rb;


    private HealthBar healthBar;
    private ArmorBar armorBar;
    protected TriggerArea triggerArea;


    [SerializeField] protected BotState botState;
    public CharacterType Type { get => characterType; }
    [SerializeField] protected CharacterType characterType;

    protected float cooldown = 3f;
    protected int healthPoint;
    protected int armorPoint;

    public bool IsDead { get => dead; }
    private bool dead;
    public Action<BaseBotAI> OnBotDead;

    protected virtual void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        ragdollController = GetComponentInChildren<RagdollController>();
        triggerArea = GetComponentInChildren<TriggerArea>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        healthBar = GetComponentInChildren<HealthBar>();
        armorBar = GetComponentInChildren<ArmorBar>();
        rb = GetComponent<Rigidbody>();
    }

    protected virtual void Start()
    {
        player = Player.Instance;

        cooldown = botData.cooldownTime;
        healthPoint = botData.healthPoint;
        armorPoint = botData.armorPoint;

        agent.speed = botData.movementSpeed;

        healthBar.SetMaxValue(botData.healthPoint);
        healthBar.SetValue(healthPoint);

        if(armorBar != null)
        {
            armorBar.SetMaxValue(botData.armorPoint);
            armorBar.SetValue(armorPoint);
        }

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

    protected virtual void Idle()
    {
        agent.isStopped = true;

        if (triggerArea.PlayerInRange)
        {
            ChangeState(BotState.Move, "move");
        }
    }

    protected virtual void Move()
    {
        agent.isStopped = false;
        agent.SetDestination(triggerArea.Target.position);

        if(triggerArea.Distance <= botData.attackDistance)
        {
            ChangeState(BotState.Attack, "attack");
        }
        else if (!triggerArea.PlayerInRange)
        {
            ChangeState(BotState.Idle, "idle");
        }
    }

    protected virtual void Attack()
    {
        agent.isStopped = true;

        RotateToTarget();
    }

    public void StartCooldown()
    {
        ChangeState(BotState.Cooldown, "idle");
        Debug.Log("Start Cooldown");
    }

    protected virtual void Cooldown()
    {
        agent.isStopped = true;

        cooldown -= Time.deltaTime;
        if (cooldown <= 0)
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

        dead = true;
        OnBotDead?.Invoke(this);
        animator.enabled = false;
        capsuleCollider.enabled = false;
        ragdollController.SetRagdoll(true);
    }

    public virtual void GetDamage(int damagePoint)
    {
        if(armorPoint > 0)
        {
            armorPoint -= damagePoint;
            armorBar.SetValue(armorPoint);
        }
        else
        {
            healthPoint -= damagePoint;

            healthBar.SetValue(healthPoint);

            if (healthPoint <= 0)
            {
                Die();
            }
        }
        
    }

    protected void RotateToTarget()
    {
        Vector3 directionToPlayer = player.transform.position
            - transform.position;

        float rotateAngle = Mathf.Atan2(directionToPlayer.x,
            directionToPlayer.z) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0,
            rotateAngle + botData.rotationOffset,
            0);
    }

    private void ChangeAnimation(string newAnim)
    {
        animator.SetBool("idle", false);
        animator.SetBool("move", false);
        animator.SetBool("attack", false);
        animator.SetBool("rush", false);

        animator.SetBool(newAnim, true);
    }

}
