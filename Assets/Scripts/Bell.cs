using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bell : MonoBehaviour
{
    [SerializeField] private Animator PlateAnimator, CakeAnimator;
    // Start is called before the first frame update

    public void Ding()
    {
        Debug.Log("Ding! Cake Done!");
        PlateAnimator.Play("RefreshPlate");
        CakeAnimator.Play("CakeRefresh");
    }
}
