using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterviewController : MonoBehaviour
{

    private Animator animator;
    private AudioSource audioSource;
    private List<Interview> interviews;

    void Start()
    {
        GameObject interviewer = GameObject.FindGameObjectWithTag("Interviewer");
        animator = interviewer.gameObject.GetComponent<Animator>();
        audioSource = interviewer.gameObject.GetComponent<AudioSource>();

        Interview interview1;
        interview1 = new Interview("1 To 1", "personal"); 
        interview1.addStep(new InterviewStep("talking", "1", interview1));
        interview1.addStep(new InterviewStep(3, "idle", interview1));
        interview1.addStep(new InterviewStep("talking", "2", interview1));

        print("starting interview");
        StartCoroutine(runInterview(interview1));
    }

    private IEnumerator runInterview(Interview interview)
    {
        List<InterviewStep> steps = interview.getSteps();

        foreach(InterviewStep step in steps){
            animator.runtimeAnimatorController = step.getAnimatorController();
            if (step.getAudioClip() != null){
                audioSource.clip = step.getAudioClip();
                audioSource.Play();
            }
            for (int i = 0; i < step.getDuration(); i++) {
                print((step.getDuration() - i).ToString());
                yield return new WaitForSeconds(1);
            }
            audioSource.Stop();
            animator.runtimeAnimatorController = null;
            audioSource.clip = null;
        }
        yield return new WaitForSeconds(1);
    }

}
