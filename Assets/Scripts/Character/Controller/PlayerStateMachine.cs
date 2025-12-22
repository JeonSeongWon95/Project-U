using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStateMachine : MonoBehaviour
{
    private IState currentState;

    public PlayerIdleState IdleState {  get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    public Vector2 moveAmount;

    private void Awake()
    {
        IdleState = new PlayerIdleState(this);
        MoveState = new PlayerMoveState(this);
        moveAmount = Vector2.zero;
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

    private void OnMove(InputValue inputValue) 
    {
        Vector2 newVector2 = inputValue.Get<Vector2>();

        if (newVector2.x != 0 || newVector2.y != 0)
        {
            moveAmount = newVector2;
            ChangeState(MoveState);
        }
        else 
        {
            ChangeState(IdleState);
        }

    }
}
