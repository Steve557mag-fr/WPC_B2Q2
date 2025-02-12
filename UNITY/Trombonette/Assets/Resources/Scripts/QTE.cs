
using System.Collections.Generic;
using UnityEngine;

public class QTE : MonoBehaviour
{
    [Header("Params")]
    public int combinationAmount;
    [SerializeField] Combination[] combination;
    [SerializeField] Combination[] combinationTable;
    [SerializeField] float maxTime = 3;
    
    [Header("References")]
    [SerializeField] Trombonette trombonette;
    [SerializeField] UI ui;

    int currentCombinationIndex;
    Combination currentCombination;
    bool lockQte = true;
    float timer = 1;
    
    internal delegate void QTEFailed();
    internal QTEFailed onQTEFailed;

    internal delegate void QTEPassed();
    internal QTEPassed onQTEPassed;

    private void Start()
    {
        
    }

    internal void StartQTE()
    {
        Debug.Log("QTE Started");
        combinationTable = new Combination[combinationAmount];
        for (int i = 0; i < combinationAmount; i++)
        {
            combinationTable[i] = combination[Random.Range(0, combination.Length)];
        }
        lockQte = false;
        timer = maxTime;

    }

    internal void EndQTE()
    {
        GameManager.instance.SetTileSpeed(3);
        lockQte = true;
        currentCombinationIndex = combinationAmount;
    }

    private void Update()
    {
        if (lockQte) return;
        else timer -= 1 * Time.deltaTime;

        if (timer <= 0)
        {
            Debug.Log("Failed the QTE");
            onQTEFailed();
            if(currentCombinationIndex == 0) EndQTE();
            return;
        }

        if (trombonette.blowValue >= 100 && trombonette.GetCombination().IsValid(currentCombination))
        {
            Debug.Log("Passed the QTE");
            onQTEPassed();
        }
        
    }

}



[System.Serializable]
internal struct Combination
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

    bool IsBetween(float asked_Combination, float input, float t)
    {
        return asked_Combination <= input + t
               && asked_Combination >= input - t;
    }

    internal bool IsValid(Combination Combination)
    {
        return 
            Combination.isAHold == isAHold 
            && Combination.isBHold == isBHold 
            && Combination.isCHold == isCHold 
            && IsBetween(Combination.slideLevel, slideLevel, threshold);
    }

}
