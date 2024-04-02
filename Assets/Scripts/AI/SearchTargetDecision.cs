using System;
using UnityEngine;

public class SearchTargetDecision : Decision
{
    public override bool Decide(AI ai)
    {
        LayerMask enemyLayer = ai.unit.enemyLayer;
        float scanRange = 50f;
        var hits = Physics2D.OverlapCircleAll(ai.transform.position, scanRange, enemyLayer);
        Collider2D closest = null;
        float closestDist = Mathf.Infinity;
        foreach (var coll in hits)
        {
            if (closest == null)
            {
                closest = coll;
            }
            else
            {
                var dist = Vector2.Distance(closest.transform.position, ai.transform.position);
                if (dist < closestDist)
                {
                    closest = coll;
                    closestDist = dist;
                }
            }
        }

        ai.target = closest.transform;
        return closest != null;
    }
}