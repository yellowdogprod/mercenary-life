using UnityEngine;

[CreateAssetMenu(menuName = "AI/State")]
public class State : ScriptableObject
{
    public Action[] actions;
    public Transition[] transitions;
    public Color sceneGizmoColor = Color.grey;

    public void UpdateState(AI ai)
    {
        ai.actionTp1 += Time.deltaTime;
        ai.actionTp2 += Time.deltaTime;
        DoActions(ai);
        CheckTransitions(ai);
    }

    private void DoActions(AI ai)
    {
        foreach (Action act in actions)
        {
            act.Act(ai);
        }
    }

    private void CheckTransitions(AI ai)
    {
        foreach (Transition t in transitions)
        {
            bool decision = t.decision.Decide(ai);
            if (decision)
            {
                ai.TransitionToState(t.trueState);
            }
            else
            {
                ai.TransitionToState(t.falseState);
            }

            return;
        }
    }
}