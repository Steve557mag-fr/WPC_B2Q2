using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UI : MonoBehaviour
{

    [Header("_Inputs_")]
    [SerializeField] Image inputA;
    [SerializeField] Image inputB;
    [SerializeField] Image inputC;

    [Header("_Lifes_")]
    [SerializeField] Image lifeA;
    [SerializeField] Image lifeB;
    [SerializeField] Image lifeC;
    [SerializeField] Sprite LifeOn, LifeOff;

    [Header("_Grid_")]
    [SerializeField] Image gridSucess;
    [SerializeField] GameObject gridContainer;
    [SerializeField] TextMeshProUGUI gridTextInfo;
    [SerializeField] GameObject[] gridLine;
    [SerializeField] Sprite noteBlue, noteRed;


    [Header("_References_")]
    [SerializeField] Trombonette trombonette;
    [SerializeField] GameManager gameManager;
    [SerializeField] QTE QTE;

    private void Update()
    {
        // inputs
        inputA.color = trombonette.blowValue >= trombonette.threslholdBlow && trombonette.isAHold ? new Color(1, 1, 1, 1) : new Color(1, 1, 1, 0);
        inputB.color = trombonette.blowValue >= trombonette.threslholdBlow && trombonette.isBHold ? new Color(1, 1, 1, 1) : new Color(1, 1, 1, 0);
        inputC.color = trombonette.blowValue >= trombonette.threslholdBlow && trombonette.isCHold ? new Color(1, 1, 1, 1) : new Color(1, 1, 1, 0);

        //health
        lifeA.sprite = gameManager.lives >= 1 ? LifeOn : LifeOff;
        lifeB.sprite = gameManager.lives >= 2 ? LifeOn : LifeOff;
        lifeC.sprite = gameManager.lives >= 3 ? LifeOn : LifeOff;

        //grid
        if (QTE.isQTEActive)
        {
            // status
            gridSucess.color = 
                QTE.combinationTable[QTE.currentCombinationIndex].IsValid(trombonette.GetCombination()) 
                ? Color.green : Color.white;

            gridContainer.SetActive(true);
            for (int i = 0; i < gridLine.Length; i++)
            {
                Combination comb = QTE.combinationTable[i];
                gridLine[i].transform.Find("A").gameObject.GetComponent<Image>().color = comb.isAHold ? new Color(1, 1, 1, 1) : new Color(1, 1, 1, 0);
                gridLine[i].transform.Find("B").gameObject.GetComponent<Image>().color = comb.isBHold ? new Color(1, 1, 1, 1) : new Color(1, 1, 1, 0);
                gridLine[i].transform.Find("C").gameObject.GetComponent<Image>().color = comb.isCHold ? new Color(1, 1, 1, 1) : new Color(1, 1, 1, 0);
            }

        }
        else gridContainer.SetActive(false);
        gridTextInfo.text = $"status:{QTE.isQTEActive}\nQTE_ID:{QTE.currentCombinationIndex}\ntime:{QTE.timeLeft}";

    }


}
