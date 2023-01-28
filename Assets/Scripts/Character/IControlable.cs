using UnityEngine;

public interface IControlable
{
    void Move(Vector2 direction);
    void Jump();
    void JumpStop();
}
