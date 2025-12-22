using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMoveState : PlayerBaseState
{
    public PlayerMoveState(PlayerStateMachine newPlayer) : base(newPlayer) {}

    public override void Enter()
    {
        //TODO :
        //Start Move
        //Add Move Animation
    }

    public override void Tick() 
    {
        if(player.moveAmount == Vector2.zero)
        {
            player.ChangeState(player.IdleState);
            return;
        }

        Vector3 moveAmount = new Vector3(player.moveAmount.x, 0, player.moveAmount.y);
        moveAmount.Normalize();
        player.transform.Translate(moveAmount * 5.0f * Time.deltaTime);

    }

    public override void Exit() 
    {
        //TODO
        //Disable Move Animation.

    }
}
