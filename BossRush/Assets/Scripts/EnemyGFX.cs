using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class EnemyGFX : MonoBehaviour
{
    public AIPath aiPath;
    [SerializeField] private GameObject totemSolution;
    totem_solution totemscript;
    private void Start()
    {
        totemscript = totemSolution.GetComponent<totem_solution>();
    }
    // Update is called once per frame
    void Update()
    {
        if(aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        } else if (aiPath.desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        if (totemscript.current_active == 4)
        {
            aiPath.maxSpeed = 7;
        }
        
    }
}
