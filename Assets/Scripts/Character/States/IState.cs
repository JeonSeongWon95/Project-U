using UnityEngine;

/// <summary>
/// 모든 State의 부모가 되는 State Interface
/// </summary>
public interface IState
{
    void Enter(); // 상태 진입 시
    void Tick(); // 매 프레임 실행 
    void Exit(); // 상태 종료 시
}
