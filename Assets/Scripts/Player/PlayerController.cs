using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public InputActionAsset inputs;
    public Vector2 moveInput()
    {
        return inputs["Move"].ReadValue<Vector2>();
    }
    public float mouseInput()
    {
        return inputs["Look"].ReadValue<Vector2>().x;
    }
    public bool jumpInput()
    {
        return inputs["Jump"].triggered;
    }
    public bool shootInput()
    {
        return inputs["Attack"].triggered;
    }
}
