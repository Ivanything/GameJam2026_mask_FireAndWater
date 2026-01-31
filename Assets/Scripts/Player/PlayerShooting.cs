using UnityEngine;
using UnityEngine.Android;

public class PlayerShooting : MonoBehaviour
{
    public Animator playerAnim;
    public GameObject bullet;
    public PlayerController controller;
    public int maxAmmo;
    int ammo;
    private void Start()
    {
        Reload();
    }
    private void Update()
    {
        if (ammo <= 0)
        {
            return;
        }
        if (controller.shootInput())
        {
            Instantiate(bullet, transform.position, transform.rotation);
            if (playerAnim)
                playerAnim.SetTrigger("Shoot");
            ammo--;
        }
    }
    public void Reload()
    {
        ammo = maxAmmo;
    }
    
}