
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.ShaderData;

public class QTE : MonoBehaviour
{
    [Header("Params")]
    public int combinationAmount;
    [SerializeField] Combination[] combination;
    [SerializeField] internal Combination[] combinationTable;
    [SerializeField] float maxTime = 3;
    
    [Header("References")]
    [SerializeField] Trombonette trombonette;
    [SerializeField] UI ui;

    public int currentCombinationIndex = 0;
    Combination currentCombination;
    bool lockQte = true;
    float timer = 1;
    
    internal delegate void QTEFailed();
    internal QTEFailed onQTEFailed;

    internal delegate void QTEPassed();
    internal QTEPassed onQTEPassed;

    internal delegate void QTEEnded();
    internal QTEEnded onQTEEnded;

    private void Start()
    {
        onQTEFailed += QTEFail;
        onQTEPassed += QTEPass;
        onQTEEnded += QTEEnd;
    }

    internal void StartQTE()
    {
        Debug.Log("QTE Started");
        combinationTable = new Combination[combinationAmount];
        for (int i = 0; i < combinationAmount; i++)
        {
            combinationTable[i] = combination[Random.Range(0, combination.Length)];
            Debug.Log(combinationTable[i].ToString());
        }
        currentCombination = combinationTable[currentCombinationIndex];
        lockQte = false;
        timer = maxTime;

    }
    public void QTEPass()
    {
        currentCombinationIndex++;
        if (currentCombinationIndex == 3) onQTEEnded();
        currentCombination = combinationTable[currentCombinationIndex];
        timer = maxTime;
    }

    public void QTEFail()
    {
        currentCombinationIndex++;
        Debug.Log("Current index : " + currentCombinationIndex);
        if (currentCombinationIndex == 3) onQTEEnded();
        currentCombination = combinationTable[currentCombinationIndex];
        timer = maxTime;
    }

    internal void QTEEnd()
    {
        lockQte = true;
        currentCombinationIndex = 0;
    }

    private void Update()
    {
        if (lockQte) return;
        else timer -= 1 * Time.deltaTime;

        if (timer <= 0)
        {
            Debug.Log("Failed the QTE");
            onQTEFailed();
            return;
        }

        if (trombonette.blowValue >= 100 && trombonette.GetCombination().IsValid(currentCombination))
        {
            Debug.Log("Passed the QTE");
            onQTEPassed();
        }
        Debug.Log("lives : " + GameManager.instance.lives);
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

    bool IsHeld(float slideLevel)
    {
        return slideLevel <= 50;
    }

    internal bool IsValid(Combination Combination)
    {
        return 
            Combination.isAHold == isAHold 
            && Combination.isBHold == isBHold 
            && Combination.isCHold == isCHold 
            && IsHeld(Combination.slideLevel);
    }

    public override string ToString()
    {
        return $"{isAHold}, {isBHold}, {isCHold}, {slideLevel}";
    }

}
