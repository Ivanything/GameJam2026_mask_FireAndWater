using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bullet;
    public PlayerController controller;
    private void Update()
    {
        if (controller.shootInput())
        {
            print("pew");
        }
    }
}