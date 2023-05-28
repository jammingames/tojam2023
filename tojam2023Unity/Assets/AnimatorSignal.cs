using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorSignal : MonoBehaviour
{
    
    public int Stage = 1;
    int prevStage;
    public bool PlaceBrick;
    public bool Attack;
    public bool Growth;

    Animator[] animators; 

    void Start()
    {
        animators = FindObjectsByType<Animator>(FindObjectsSortMode.None);
    }


    void Update()
    {
        if(Growth)
        {
            DoThing("Growth");
            Growth = false; 
        }

        if (Stage != prevStage)
        {

            UpdateStage();
            prevStage = Stage;
        }

        if (PlaceBrick)
        {
            Trigger("PlaceBrick");
            PlaceBrick = false;
        }

        if (Attack)
        {
            AttackFunction();
            Attack = false;
        }
    }

    void DoThing(string term)
    {

        foreach (Animator anim in animators)
        {

            int currentValue = anim.GetInteger("Growth");
            anim.SetInteger("Growth", currentValue + 1);
        }

    }

    void AttackFunction()
    {

        foreach (Animator anim in animators)
        {
            anim.SetTrigger("Attack");
            int currentValue = anim.GetInteger("Damage");
            anim.SetInteger("Damage", currentValue + 1);

        }

    }


    void Trigger(string value)
    {

        foreach (Animator anim in animators)
        {
            anim.SetTrigger(value);

        }

    }

    void UpdateStage()
    {
        foreach (Animator anim in animators)
        {
            anim.SetInteger("Stage", Stage);

        }

    }

}
