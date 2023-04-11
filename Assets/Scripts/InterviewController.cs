using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterviewController : MonoBehaviour
{

    public GameObject dummy;
    private Animator animator;
    public RuntimeAnimatorController runtimeAnimatorController;

    // Start is called before the first frame update
    void Start()
    {
        animator = dummy.gameObject.GetComponent<Animator>();
        animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("/Animations/Controllers/Capoeira.controller");
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator InterviewFlow()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);

    }
}
