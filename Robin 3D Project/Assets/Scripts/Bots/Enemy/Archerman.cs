using UnityEngine;
using UnityEngine.AI;

public class Archerman : BaseRangeBot
{
    public float radius = 10.0f;
    private Vector3 randomPoint;

    public void SetRandomPosition()
    {
        if (!GroundCheck())
        {
            SetRandomPosition();
        }
        else
        {
            agent.isStopped = false;
            agent.SetDestination(randomPoint);

            ChangeState(BotState.Move, "move");
        }
        
    }

    private bool GroundCheck()
    {
        randomPoint = transform.position + Random.insideUnitSphere * radius;
        randomPoint = new Vector3(randomPoint.x, transform.position.y, randomPoint.z);

        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 1f, NavMesh.AllAreas))
        {
            return true;
        }

        return false;
    }

    protected override void Move()
    {
        float distance = Vector3.Distance(transform.position, randomPoint);

        if (distance <= 1f) ChangeState(BotState.Idle, "idle");
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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(randomPoint, 0.5f);
    }
}
