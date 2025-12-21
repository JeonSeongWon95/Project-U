using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public PlayerIdleState(PlayerStateMachine playerStateMachine) : base(playerStateMachine) { }
    public override void Enter()
    {

    }

    public override void Tick()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        if (h != 0f && v != 0f)
        {
            player.ChangeState(player.MoveState);
        }
    }

    public override void Exit()
    {

    }
}
