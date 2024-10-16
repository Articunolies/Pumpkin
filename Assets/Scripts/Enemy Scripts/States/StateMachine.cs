public class StateMachine
{
    public State currentState;

    public void SetState(State newState)
    {
        if (currentState != null)
        {
            currentState.OnExit();
        }

        currentState = newState;

        if (currentState != null)
        {
            currentState.OnEnter();
        }
    }

    public void Update()
    {
        if (currentState != null)
        {
            // Check transitions before updating the current state
            foreach (Transition transition in currentState.GetTransitions())
            {
                if (transition.ShouldTransition())
                {
                    SetState(transition.GetNextState());
                    return;
                }
            }

            // Update the current state
            currentState.OnUpdate();
        }
    }
}
