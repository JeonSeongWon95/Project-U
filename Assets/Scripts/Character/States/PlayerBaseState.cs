using UnityEngine;

public abstract class PlayerBaseState : IState
{
    protected PlayerStateMachine player;

    public PlayerBaseState(PlayerStateMachine newPlayer) 
    {
        this.player = newPlayer;
    }

    public abstract void Enter();
    public abstract void Tick();

    public abstract void Exit();
}
