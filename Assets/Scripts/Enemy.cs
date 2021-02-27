using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    public int positionsTillReturning = 2;
    private int curPosition;
    private Vector3 targetPos;

    public override void Start()
    {
        targetPos = transform.position;

        base.Start();
    }

    public override void Update()
    {
        //always gets latest transform position
        var transPos = transform.position;

        //if current position is 0.5 orders of magnitude away from original position
        if ((targetPos - transPos).magnitude < 0.5f)
        {
            //then if enemy is 2 positions away from original position, turn back
            if(curPosition < positionsTillReturning)
            {
                curPosition++;
                var targetPos2D = 24.5f * Random.insideUnitCircle;
                targetPos = new Vector3(targetPos2D.x, 0, targetPos2D.y);
            }
            else
            {
                curPosition = 0;
                targetPos = areaVertices[GetClosestAreaVertice(transPos)];
            }
        }

        //current direction should be towards target position
        curDir = (targetPos - transPos).normalized;

        base.Update();
    }
}
