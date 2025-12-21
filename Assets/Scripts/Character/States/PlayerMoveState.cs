using UnityEngine;

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
        float h = Input.GetAxisRaw("Horizontal"); // ÁÂ¿ì°ª °¡Á®¿È
        float v = Input.GetAxisRaw("Vertical"); // »óÇÏ°ª °¡Á®¿È

        if(h == 0 && v == 0) 
        {
            player.ChangeState(player.IdleState);
        }

        //TODO :
        //Move Speed, Attack, Attack Speed etc Export
        Vector3 dir = new Vector3(h, 0, v).normalized;
        player.transform.Translate(dir * 5.0f * Time.deltaTime);
    }

    public override void Exit() 
    {
        //TODO
        //Disable Move Animation.

    }
}
