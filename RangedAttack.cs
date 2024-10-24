using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RangedAttack : MonoBehaviour
{
    public Vector3 target;
    public int iD;
    public float Speed;
    public float dmg;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(target != null)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, target, Speed); 
        }

        if(this.transform.position == target)
        {
            
        }
    }
}
