using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMoveState : PlayerBaseState
{
    public enum EDIRECTION
    {
        North = 0,
        South = 180,
        East = 90,
        West = 270,
        North_West = 315,
        South_East = 135,
        North_East = 45,
        South_West = 225
    }
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


        EDIRECTION direction = EDIRECTION.North;

        if (player.moveAmount.y == 0)
        {
            direction = player.moveAmount.x > 0 ? EDIRECTION.East : EDIRECTION.West;
        }
        else if (player.moveAmount.y < 0) 
        {
            direction = player.moveAmount.x == 0 ? EDIRECTION.South : player.moveAmount.x > 0 ? EDIRECTION.South_East : EDIRECTION.South_West;
        }
        else
        {
            direction = player.moveAmount.x == 0 ? EDIRECTION.North : player.moveAmount.x > 0 ? EDIRECTION.North_East : EDIRECTION.North_West;
        }

        Vector3 angle = player.transform.eulerAngles; //(player.transform.up, (float)direction);
        angle.y = (float)direction;
        player.transform.eulerAngles = angle;
        player.transform.Translate(moveAmount * 5.0f * Time.deltaTime, Space.World);

    }

    public override void Exit() 
    {
        //TODO
        //Disable Move Animation.

    }
}
