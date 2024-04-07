using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FaxMachineManager : MonoBehaviour
{
    public List<CakeRequest> Requests;
    public Animator FaxAnimator;
    private bool Unhidden = false;
    public TextMeshProUGUI TaskText;
    private int requestIndex = 0;

    public CakeCardType checkRequiredCard()
    {
        if (requestIndex == 0) return CakeCardType.GeorgeGirraffe;
        return Requests[requestIndex - 1].type;
    }
    
    public void NewTask()
    {
        TaskText.text = Requests[requestIndex].RequestText;
        requestIndex++;
        FaxAnimator.Play("NewTaskAnim");
    }
    
    public void TaskReveal()
    {
        FaxAnimator.Play("TaskUnHide");
        Unhidden = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            NewTask();
        }
        if (Unhidden && Input.GetMouseButtonDown(0))
        {
            Unhidden = false;
            FaxAnimator.Play("TaskReHide");
        }
    }
}
