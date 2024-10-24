using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movement)), RequireComponent(typeof(Stats))]

public class HeroCombat : MonoBehaviour
{
    public GameObject targetedEnemy;
    public enum HeroAttackType { Melee, Ranged};
    public HeroAttackType heroAttackType;
    public float attackRange;
    public float rotateSpeedForAttack;

    private Movement MovementScript; 

    public bool basicAtkIdle = false;
    public bool isHeroAlive; 
    public bool performMeleeAttack = true;

    private Stats StatsScript;  
    private float attackInterval;
    private float nextAttackTime = 0;
    


    // Start is called before the first frame update
    void Start()
    {
        MovementScript = GetComponent<Movement>();
        StatsScript = GetComponent<Stats>();
    }

    // Update is called once per frame
    void Update()
    {

        attackInterval = StatsScript.attackSpeed / ((500 + StatsScript.attackSpeed) * 0.01f);

        targetedEnemy = MovementScript.targetedEnemy;

        if(targetedEnemy != null)
        {
            if(Vector3.Distance(gameObject.transform.position, targetedEnemy.transform.position) > attackRange)
            {
                MovementScript.agent.SetDestination(targetedEnemy.transform.position);
                MovementScript.agent.stoppingDistance = attackRange;

                Quaternion rotationToLookAt = Quaternion.LookRotation(targetedEnemy.transform.position - transform.position);
                float rotationY = Mathf.SmoothDampAngle(transform.eulerAngles.y, rotationToLookAt.eulerAngles.y, 
                    ref MovementScript.rotateVelocity, 
                    rotateSpeedForAttack * (Time.deltaTime * 5));

                transform.eulerAngles = new Vector3(0, rotationY, 0);
            }

            else
            {
                if(heroAttackType == HeroAttackType.Melee)
                {
                    if(performMeleeAttack)
                    {
                        StatsScript.TakeDamage(targetedEnemy, StatsScript.damage);

                        nextAttackTime = Time.time + attackInterval;
                    }
                }
            }
        }
    }
}
