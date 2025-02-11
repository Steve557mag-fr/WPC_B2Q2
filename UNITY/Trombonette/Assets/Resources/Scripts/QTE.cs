using UnityEngine;

public class QTE : MonoBehaviour
{
    [Header("Params")]
    [SerializeField] Combinaison[] combinaisons;
    [SerializeField] float maxTime = 4;
    
    [Header("References")]
    [SerializeField] Trombonette trombonette;
    [SerializeField] UI ui;

    Combinaison currentCombinaison;
    bool lockQte = false;
    float timer;
    
    internal delegate void QTEFailed();
    internal QTEFailed onQTEFailed;

    internal delegate void QTEPassed();
    internal QTEPassed onQTEPassed;

    internal void StartQTE()
    {
        currentCombinaison = combinaisons[Random.Range(0, combinaisons.Length)];
    }

    internal void StartQTE(Combinaison combinaison)
    {
        currentCombinaison = combinaison;
    }

    private void Update()
    {
        if (lockQte) return;

        if(timer <= 0)
        {
            lockQte = true;
            onQTEFailed();
            return;
        }

        if (trombonette.GetCombinaison().IsValid(currentCombinaison))
        {
            lockQte = true;
            onQTEPassed();
        }

        timer -= Time.deltaTime;
    }

}

[System.Serializable]
internal struct Combinaison
{
    [Tooltip("Need to hold the A button on the controller")]
    [SerializeField] internal bool isAHold;
    
    [Tooltip("Need to hold the B button on the controller")]
    [SerializeField] internal bool isBHold;
    
    [Tooltip("Need to hold the C button on the controller")]
    [SerializeField] internal bool isCHold;

    [Tooltip("The level of slide you need to achieve this combinaison. Between 0 and 100")]
    [Range(0,100)]
    [SerializeField] internal float slideLevel;

    internal bool IsValid(Combinaison other)
    {
        return 
            other.isAHold == isAHold 
            && other.isBHold == isBHold 
            && other.isCHold == isCHold 
            && other.slideLevel >= slideLevel;
    }

}
