using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SlotMachine : MonoBehaviour
{
    public Image[] reel1Symbols;
    public Image[] reel2Symbols;
    public Image[] reel3Symbols;

    public Button spinButton;
    public MachineReturn mreturn;

    private bool isSpinning = false;
    private int spinCount = 0;
    private int[] reel1Combination = { 1, 2, 3, 4, 5, 6, 7};
    private int[] reel2Combination = { 1, 2, 3, 4, 5, 6, 7 };
    private int[] reel3Combination = { 1, 2, 3, 4, 5, 6, 7 };

    // Start is called before the first frame update
    void Start()
    {
        spinButton.onClick.AddListener(SpinButtonClick);
    }

    // Update is called once per frame
    void Update()
    {
        if (isSpinning)
        {
            SpinReels();
        }
    }

    void SpinReels()
    {
        int reel1Index = Random.Range(0, reel1Symbols.Length);
        int reel2Index = Random.Range(0, reel2Symbols.Length);
        int reel3Index = Random.Range(0, reel3Symbols.Length);

        for (int i = 0; i < reel1Symbols.Length; i++)
        {
            if (i == reel1Index)
            {
                reel1Symbols[i].gameObject.SetActive(true);
                reel1Symbols[i].transform.DOLocalMoveY(0f, 1f).SetEase(Ease.OutQuad);
            }
            else
            {
                reel1Symbols[i].gameObject.SetActive(false);
                reel1Symbols[i].transform.DOLocalMoveY(100f, 1f).SetEase(Ease.OutQuad);
            }
        }

        for (int i = 0; i < reel2Symbols.Length; i++)
        {
            if (i == reel2Index)
            {
                reel2Symbols[i].gameObject.SetActive(true);
                reel2Symbols[i].transform.DOLocalMoveY(0f, 1f).SetEase(Ease.OutQuad);
            }
            else
            {
                reel2Symbols[i].gameObject.SetActive(false);
                reel2Symbols[i].transform.DOLocalMoveY(100f, 1f).SetEase(Ease.OutQuad);
            }
        }

        for (int i = 0; i < reel3Symbols.Length; i++)
        {
            if (i == reel3Index)
            {
                reel3Symbols[i].gameObject.SetActive(true);
                reel3Symbols[i].transform.DOLocalMoveY(0f, 1f).SetEase(Ease.OutQuad);
            }
            else
            {
                reel3Symbols[i].gameObject.SetActive(false);
                reel3Symbols[i].transform.DOLocalMoveY(100f, 1f).SetEase(Ease.OutQuad);
            }
        }

        spinCount++;

        if (spinCount >= 20)
        {
            isSpinning = false;
            spinCount = 0;

            int[] combination = { reel1Combination[reel1Index], reel2Combination[reel2Index], reel3Combination[reel3Index] };
            Debug.Log("Combination: " + combination[0] + ", " + combination[1] + ", " + combination[2]);
            Chack(combination);
        }
    }

    void SpinButtonClick()
    {
        if (!isSpinning)
        {
            isSpinning = true;
        }
    }

    void Chack(int[] combination)
    {
        if (combination[0] == combination[1] && combination[1] == combination[2])
        {
            Debug.Log("三個數字相同");
            mreturn.Threenum();
        }
        else if (combination[0] == combination[1] || combination[1] == combination[2] || combination[0] == combination[2])
        {
            Debug.Log("兩個數字相同");
            mreturn.Twonum();
        }
        else
        {
            Debug.Log("沒有相同數字");
        }
    }
}
