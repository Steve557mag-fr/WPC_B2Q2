using System.Collections.Generic;
using UnityEngine;

public class QTE : MonoBehaviour
{
    [Header("Params")]
    [SerializeField] combination[] combination;
    [SerializeField] float maxTime = 3;
    
    [Header("References")]
    [SerializeField] Trombonette trombonette;
    [SerializeField] UI ui;

    combination currentcombination;
    bool lockQte = true;
    float timer = 1;
    
    internal delegate void QTEFailed();
    internal QTEFailed onQTEFailed;

    internal delegate void QTEPassed();
    internal QTEPassed onQTEPassed;

    internal void StartQTE()
    {
        Debug.Log("QTE Started");
        currentcombination = combination[Random.Range(0, combination.Length)];
        lockQte = false;
        timer = maxTime;
        Debug.Log("Current Combination : " + currentcombination + "      timer : " + timer);
    }

    internal void StartQTE(combination combination)
    {
        currentcombination = combination;
    }

    private void Update()
    {
        if (lockQte) return;
        else timer -= 1 * Time.deltaTime;

        if (timer <= 0)
        {
            Debug.Log("In Failed ?  " + lockQte);
            lockQte = true;
            GameManager.instance.SetTileSpeed(3);
            //onQTEFailed();
            Debug.Log("Missed The QTE !"); 
            return;
        }

        /*if ( /* trombenette.blowValue >= 100 // trombonette.isBlowing == true // trombonette.GetBlowValue() >= 100 && [* /] trombonette.Getcombination().IsValid(currentcombination))
        {
            lockQte = true;
            GameManager.instance.SetTileSpeed(3);
            onQTEPassed();
        }
        */
    }

}



[System.Serializable]
internal struct combination
{
    [Tooltip("Need to hold the A button on the controller")]
    [SerializeField] internal bool isAHold;

    [Tooltip("Need to hold the B button on the controller")]
    [SerializeField] internal bool isBHold;

    [Tooltip("Need to hold the C button on the controller")]
    [SerializeField] internal bool isCHold;

    [Tooltip("The level of slide you need to achieve this combinaison. Between 0 and 100")]
    [Range(0, 100)]
    [SerializeField] internal float slideLevel;

    [Tooltip("The threshold to validate the slider")]
    [SerializeField] internal float threshold;

    bool IsBetween(float asked_combination, float input, float t)
    {
        return asked_combination <= input + t
               && asked_combination >= input - t;
    }

    internal bool IsValid(combination combination)
    {
        return 
            combination.isAHold == isAHold 
            && combination.isBHold == isBHold 
            && combination.isCHold == isCHold 
            && IsBetween(combination.slideLevel, slideLevel, threshold);
    }

}
