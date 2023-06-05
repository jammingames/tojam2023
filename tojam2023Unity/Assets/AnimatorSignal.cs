using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimatorSignal : MonoBehaviour
{
    
    public int Stage = 1;
    int prevStage;
    public bool PlaceBrick;
    public bool Attack;
    public bool Growth;

    Animator[] animators;

    public GameObject stage1;
    public GameObject stage2;
    public GameObject stage3;
    public int cooldown;
    public int timer;

    public Animator playerAnim;
    public GameObject nextButton;
    public GameObject resetButton; 


    void Start()
    {
        animators = FindObjectsByType<Animator>(FindObjectsSortMode.None);

        nextButton.SetActive(true);
        resetButton.SetActive(false);

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

            UpdateStage(Stage);
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

        if (timer > 0)
            timer--;

        if (Input.GetKeyDown(KeyCode.Escape))
            ExitGame();
            
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

        int rand1 = Random.Range(0, animators.Length);
        int rand2 = Random.Range(0, animators.Length);
        int rand3 = Random.Range(0, animators.Length);
        int rand4 = Random.Range(0, animators.Length);

        if (animators[rand1].tag == "Brick")
            animators[rand1].SetTrigger(value);
        if (animators[rand2].tag == "Brick")
            animators[rand2].SetTrigger(value);
        if (animators[rand3].tag == "Brick")
            animators[rand3].SetTrigger(value);
        if (animators[rand4].tag == "Brick")
            animators[rand4].SetTrigger(value);


        /*        foreach (Animator anim in animators)
                {
                    anim.SetTrigger(value);

                }*/

    }

    public void TriggerAll()
    {
        foreach (Animator anim in animators)
        {
            anim.SetTrigger("PlaceBrick");

        }
    }

    void UpdateStage(int Stage)
    {
        foreach (Animator anim in animators)
        {
            anim.SetInteger("Stage", Stage);

        }

    }

    public void NextButton()
    {

        /*            public int Stage = 1;
            int prevStage;
            public bool PlaceBrick;
            public bool Attack;
            public bool Growth;*/

        if (timer <= 0)
        {
            if (playerAnim.GetInteger("Damage") < 5) {
                AttackFunction();
                Trigger("PlaceBrick");
            } else
            {

                if (playerAnim.GetInteger("Growth") < 5)
                {
                    AttackFunction();
                    TriggerAll();
                    UpdateStage(2);
                    DoThing("Growth");
                }
                else
                {
                    UpdateStage(3);
                    nextButton.SetActive(false);
                    resetButton.SetActive(true);
                }
            }




            timer = cooldown;
        }



}

    public void Reset()
    {
           Stage = 1;
        SceneManager.LoadScene(0);

    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
