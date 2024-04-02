using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName = "Action/Roam")]
public class RoamAction : Action
{
    public float maxRoamingDistance = 5f;
    public override void Act(AI ai)
    {
        if (ai.actionTp1 < 0f)
        {
            return;
        }
        if(ai.currentDir == Vector2.zero)
        {
            ai.currentDir = PickNewDir();
        }
        float dist = Vector3.Distance(ai.transform.position, ai.spawnPos);
        float changeDirectionWeight = Mathf.Clamp01((dist - maxRoamingDistance/2f) / maxRoamingDistance);
        ai.unit.Move(ai.currentDir);
        ai.currentDir = ai.currentDir + (ai.currentDir.Perpendicular1() * changeDirectionWeight);

        if (ai.actionTp1 > ai.actionTime1)
        {
            ai.actionTp1 = Random.Range(-3f, -1f);
            ai.actionTime1 = Random.Range(1.5f, 3.5f);
        }
        
    }

    private Vector2 PickNewDir()
    {
        return new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
    }
    
}