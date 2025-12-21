using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    private IState currentState;

    public PlayerIdleState IdleState {  get; private set; }
    public PlayerMoveState MoveState { get; private set; }

    private void Awake()
    {
        IdleState = new PlayerIdleState(this);
        MoveState = new PlayerMoveState(this);
    }

    private void Start()
    {
        ChangeState(IdleState);
    }

    private void Update()
    {
        currentState?.Tick();
    }

    public void ChangeState(IState newState) 
    {
        if (currentState != newState)
        {
            currentState?.Exit();
            currentState = newState;
            currentState?.Enter();
        }
    }
}
