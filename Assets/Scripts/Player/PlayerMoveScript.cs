using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMoveScript : MonoBehaviour
{
    public float speed;
    public float lookSens;
    CharacterController cc;
    public float gravity;
    public float jumpHeight;
    float fall;
    PlayerController controller;

    void Start()
    {
        cc = GetComponent<CharacterController>();
        controller = GetComponent<PlayerController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Update()
    {
        MovementLogic();
        CameraMove();
        FallingLogic();
    }



    private void MovementLogic()
    {
        Vector3 move = transform.forward * controller.moveInput().y + transform.right * controller.moveInput().x;
        move.Normalize();
        move *= speed;

        cc.Move(move * Time.deltaTime);

        if (controller.jumpInput() && isGrounded())
        {
            fall = jumpHeight;
        }
    }
    private void CameraMove()
    {
        transform.Rotate(0, lookSens * controller.mouseInput(), 0);
    }
    public void FallingLogic()
    {
        if (isGrounded() && fall < 0)
        {
            fall = -0.01f;
        }
        else
        {
            fall -= Time.deltaTime * gravity;
        }
        cc.Move(Vector3.up * fall * Time.deltaTime);
    }
    private bool isGrounded()
    {
        float checkGroundSpot = -cc.height / 2f + cc.radius - 0.2f;
        Collider[] cols = Physics.OverlapSphere(transform.position + Vector3.up * checkGroundSpot, cc.radius * 0.95f);
        for (int i = 0; i < cols.Length; i++)
        {
            if (cols[i].isTrigger) continue;
            if (cols[i] == cc) continue;
            return true;
        }
        return false;
    }
}
