using UnityEngine;

public class CharacterInputContoller : MonoBehaviour
{
    private IControlable _controlable;
    void Start()
    {
        _controlable = GetComponent<IControlable>();
        if (_controlable == null) 
        {
            throw new MissingComponentException($"There is no IControlable in {gameObject.name}");
        }
    }

    // Update is called once per frame
    void Update()
    {
        var direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Horizontal"));
        _controlable.Move(direction);

        if (Input.GetButtonDown("Jump"))
        {
            _controlable.Jump();
        }
        if (Input.GetButtonUp("Jump"))
        {
            _controlable.JumpStop();
        }
    }
}
