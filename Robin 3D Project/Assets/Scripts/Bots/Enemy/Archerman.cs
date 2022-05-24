using UnityEngine;
using UnityEngine.AI;

public class Archerman : BaseRangeBot
{
    public float radius = 10.0f;
    private NavMeshPath navMeshPath;
    private Vector3 randomPoint;

    protected override void Start()
    {
        base.Start();
        navMeshPath = new NavMeshPath();
    }

    public void SetRandomPosition()
    {
        randomPoint = transform.position + Random.insideUnitSphere * radius;
        randomPoint = new Vector3(randomPoint.x, transform.position.y, randomPoint.z);
        if (!GroundCheck())
        {
            SetRandomPosition();
        }
        if (agent.CalculatePath(transform.position, navMeshPath))
        {
            agent.isStopped = false;
            agent.SetDestination(randomPoint);
        }
        else
        {
            Debug.Log("NavMeshAgent not on nav mesh.");
        }

        ChangeState(BotState.Move, "move");
    }

    private bool GroundCheck()
    {
        Debug.Log(new Vector3(randomPoint.x, -randomPoint.y, randomPoint.z));
        return Physics.Raycast(randomPoint, new Vector3(randomPoint.x, -randomPoint.y, randomPoint.z), Mathf.Infinity, 3);
    }

    protected override void Move()
    {
        float distance = Vector3.Distance(transform.position, randomPoint);

        if (distance <= 0.1f) ChangeState(BotState.Idle, "idle");
    }

    protected override void Cooldown()
    {
        agent.isStopped = true;

        cooldown -= Time.deltaTime;
        if (cooldown <= 0)
        {
            ChangeState(BotState.Idle, "idle");
            cooldown = botData.cooldownTime;
        }
    }


}
