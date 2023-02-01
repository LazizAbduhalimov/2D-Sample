using UnityEngine;

public class CharacterInputContoller : MonoBehaviour
{
    private IControlable _controlable;
    private IFigthtable _figthtable;
    private void Start()
    {
        _controlable = GetComponent<IControlable>();
        _figthtable = GetComponent<IFigthtable>();
        if(_controlable == null) 
        {
            throw new MissingComponentException($"There is no IControlable in {gameObject.name}");
        }
        
    }

    private void Update()
    {
        var direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Horizontal"));
        _controlable.Move(direction);

        if(Input.GetButtonDown("Jump"))
        {
            _controlable.Jump();
        }
        if(Input.GetButtonUp("Jump"))
        {
            _controlable.JumpStop();
        }
        if (Input.GetButtonDown("Fire1"))
        {
            _figthtable?.Attack();
        }
    }
}
