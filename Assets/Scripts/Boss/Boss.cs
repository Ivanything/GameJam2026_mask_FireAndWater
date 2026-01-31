using System.Runtime.InteropServices;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public float speed;

    private int pathNum;

    private float timer;
    public float timeToNextPoint;
    public bool atPoint;

    void Update()
    {
        
        //check to see if theings exsits
        if (GameManager.instance == null) return;
        if (GameManager.instance.bossPath.Count == 0) return;
        if (pathNum >= GameManager.instance.bossPath.Count) return;

        //make vars
        Transform targetPoint = GameManager.instance.bossPath[pathNum];
        Vector3 target = targetPoint.position;
        if(GameManager.instance.bossPath.Count!= pathNum)
        {
            if (Vector3.Distance(transform.position, target) < 0.1f) {// If close enough → go to next point
               timer += Time.deltaTime; 
                atPoint = true;
                if (timer >= timeToNextPoint)
                {
                    NextPos();
                    timer = 0;
                }
            } else{
                atPoint = false;
                transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);   
            }

        }
        
    }

    public void NextPos()
    {
        pathNum++;

        // Optional: stop at last point
        if (pathNum >= GameManager.instance.bossPath.Count)
        {
            pathNum = GameManager.instance.bossPath.Count - 1;
            // OR disable movement:
            // enabled = false;
        }
    }
}
