using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;
using TMPro;
using System.Diagnostics;

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
        interviewInit();
        StartCoroutine(runInterview(interviews[0]));
    }

    private IEnumerator runInterview(Interview interview)
    {
        List<InterviewStep> steps = interview.getSteps();
        foreach(InterviewStep step in steps){
            animator.runtimeAnimatorController = Resources.Load<AnimatorController>("Interviews/" + interview.getBasePath() + "Animations/" + step.getAnimatorControllerPath());
            // animator.runtimeAnimatorController = Resources.Load<AnimatorController>("Animations/Controllers/Capoeira");
            if (step.getAudioClipPath() != ""){
                audioSource.clip = Resources.Load<AudioClip>("Interviews/" + interview.getBasePath() + "Audio/" + step.getAudioClipPath());
                audioSource.Play();
            }
            for (int i = 0; i < step.getDuration(); i++) {
                debugLog((step.getDuration() - i).ToString());
                yield return new WaitForSeconds(1);
            }
            audioSource.Stop();
            animator.runtimeAnimatorController = null;
            audioSource.clip = null;
        }
    }

    private void debugLog(string text)
    {
        UnityEngine.Debug.Log("Stage " + text + ". At time: " + Time.time);
        textMesh.text = text;
    }

    private void interviewInit(){
        Interview interview1 =new Interview("1 To 1", "personal"); 
        interview1.addStep(5, "Capoeira", "test");
        interview1.addStep(5, "idle", "");
        interview1.addStep(5, "Capoeira", "test");
        interview1.addStep(5, "idle", "");
        interview1.addStep(5, "Capoeira", "test");
        interview1.addStep(5, "idle", "");

        interviews.Add(interview1);
    }

}
