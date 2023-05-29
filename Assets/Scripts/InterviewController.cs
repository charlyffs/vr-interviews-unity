using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterviewController : MonoBehaviour
{

    private Animator animator;
    private AudioSource audioSource;
    private AudioSource recordSource; //Objeto para manejar el la grabacion de respuestas
    private List<Interview> interviews;
    private int cont; //Contador para enlistar grabaciones
    private bool condition; //Condicional para definir cuando guardar las grabaciones
    void Start()
    {
        GameObject interviewer = GameObject.FindGameObjectWithTag("Interviewer");
        animator = interviewer.gameObject.GetComponent<Animator>();
        audioSource = interviewer.gameObject.GetComponent<AudioSource>();
        recordSource = interviewer.gameObject.GetComponent<AudioSource>(); //Inicializacion
        Interview interview1;
        cont = 1;//Inicializacion
        condition = true; //Inicializacion
        interview1 = new Interview("1 To 1", "personal");

        interview1.addStep(new InterviewStep("Speaking", "Intro 1", interview1));
        interview1.addStep(new InterviewStep(2, "Nodding", interview1));
        interview1.addStep(new InterviewStep("Speaking2", "EA 1", interview1));
        interview1.addStep(new InterviewStep(10, "Nodding", interview1));
        interview1.addStep(new InterviewStep("Speaking2", "EA 2.1", interview1));
        interview1.addStep(new InterviewStep(10, "Nodding", interview1));
        interview1.addStep(new InterviewStep("Speaking2", "EA 3", interview1));
        interview1.addStep(new InterviewStep(10, "Nodding", interview1));
        interview1.addStep(new InterviewStep("Speaking2", "EA 4", interview1));
        interview1.addStep(new InterviewStep(10, "Nodding", interview1));

        print("starting interview");
        StartCoroutine(runInterview(interview1));
    }

    private IEnumerator runInterview(Interview interview)
    {
       
        List<InterviewStep> steps = interview.getSteps();
        
        foreach (InterviewStep step in steps)
        {
            animator.runtimeAnimatorController = step.getAnimatorController();
            if (step.getAudioClip() != null)
            {
                audioSource.clip = step.getAudioClip();
                audioSource.Play();
                condition = true; //Al no ser un paso para responder, la condicional se vuelve true para impedir el guardado de audio
            }
            else
            {
                //Se obtiene el primer dispositivo de audio disponible
                string recordDevice = Microphone.devices[0];
                //Se inicia la grabacion, donde el parametro step.getDuration define la duracion del archivo grabado
                recordSource.clip = Microphone.Start(recordDevice, true, step.getDuration()+1, 44100);
                //La condicional se vuelve false para permitir el guardado de audio
                condition = false;
            }
            
            for (int i = 0; i < step.getDuration(); i++)
            {
                print((step.getDuration() - i).ToString());
                yield return new WaitForSeconds(1);
            }
            //Se verifica si se debe guardar el archivo de audio.
            if (!condition)
            {
                SavWav.Save("Record_Answer_" + cont, recordSource.clip);
                cont++;
            }
            audioSource.Stop();
            animator.runtimeAnimatorController = null;
            audioSource.clip = null;
        }
        yield return new WaitForSeconds(1);
    }

}
