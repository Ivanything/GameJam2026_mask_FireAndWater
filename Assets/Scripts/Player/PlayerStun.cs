using UnityEngine;

public class PlayerStun : Death
{
    PlayerMoveScript mover;
    public float stunDuration;
    float isStunned;
    void Start()
    {
        mover = GetComponent<PlayerMoveScript>();
    }
    private void Update()
    {
        mover.enabled = isStunned <= 0;
        if (isStunned > 0)
        {
            isStunned -= Time.deltaTime;
            mover.FallingLogic();
        }
    }
    public override void Die()
    {
        isStunned = stunDuration;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created


}
