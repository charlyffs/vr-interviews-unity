using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;
using TMPro;

public class InterviewController : MonoBehaviour
{

    private GameObject dummy;
    private Animator animator;
    private AudioSource audioSource;
    public TextMeshProUGUI textMesh;
    private List<Interview> interviews;

    void Start()
    {
        dummy = GameObject.FindGameObjectWithTag("Player");
        animator = dummy.gameObject.GetComponent<Animator>();
        audioSource = dummy.gameObject.GetComponent<AudioSource>();

        Interview interview1;
        interview1 = new Interview("1 To 1", "personal"); 
        interview1.addStep(new InterviewStep(5, "Capoeira", "test", interview1));
        interview1.addStep(new InterviewStep(2, "", "test", interview1));
        interview1.addStep(new InterviewStep(3, "Capoeira", "", interview1));

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
