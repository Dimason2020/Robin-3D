using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spearman : BaseMeleeBot
{
    private Vector3 rushTarget;

    protected override void Update()
    {
        base.Update();

        if (botState == BotState.Rush)
            Rush();
    }

    protected override void Attack()
    {
        base.Attack();
    }

    protected override void Move()
    {
        base.Move();

        if(triggerArea.Distance <= botData.rushStartDistance
            && triggerArea.Distance > botData.attackDistance)
        {
            StartRushing();
        }
    }

    private void StartRushing()
    {
        rushTarget = player.transform.position;
        agent.speed = botData.rushSpeed;
        agent.SetDestination(rushTarget);
        ChangeState(BotState.Rush, "rush");

        Debug.Log("Start Rushing!");
    }

    private void Rush()
    {
        float distanceToRushTarget = Vector3.Distance(transform.position, rushTarget);

        if(triggerArea.Distance <= botData.attackDistance
            || distanceToRushTarget <= botData.attackDistance)
        {
            ChangeState(BotState.Attack, "attack");

            agent.speed = botData.movementSpeed;
        }
    }
}
