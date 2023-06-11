using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreeMonster : MonoBehaviour
{
    private int hart;
    private int attack;
    public int dropCoin;
    public bool isdead;

    private int randomBreak;

    private int randomSkip;
    private bool isSkip;

    public PlayerValue playerValue;
    public Text hartText;
    public Text debugText;
    public loading loading;

    public RectTransform uiObject;
    public Vector2 moveOffset;
    public float moveDuration;

    private Vector2 originalPosition;

    void Start()
    {
        InitMonsterVelue();
        hartText.text = hart.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        MonsterHartCheck();
    }

    private bool MonsterHartCheck()
    {
        if(hart <= 0)
        {
            Destroy(this.gameObject);
            isdead = true;
            int now = PlayerPrefs.GetInt("InitNow");
            playerValue.coin += dropCoin;
            now += 15;
            PlayerPrefs.SetInt("InitNow", now);
            PlayerPrefs.Save();
            return isdead;
        }
        else
        {
            isdead = false;
            return isdead;
        }
    }

    private void InitMonsterVelue()
    {
        hart = 20;
        attack = 5;
        dropCoin = 5;
        debugText.text = hart.ToString();
    }

    public void BeAttack(int value, string name,bool canskip)
    {
        if (SkipCheck(canskip,name))
        {
            debugText.text += name +　"閃避了" + "你的攻擊" + "\n";
        }
        else
        {
            debugText.text += "你對" + name + "造成" + value + "傷害" + "\n";
            hart = hart - value;
            if(MonsterHartCheck() == false)
            {
                hartText.text = hart.ToString();
            }
        }
    }

    private bool SkipCheck(bool canskip, string name)
    {
        if(canskip)
        {
            int now = PlayerPrefs.GetInt("InitNow");
            playerValue.coin += dropCoin;
            now = 0;
            PlayerPrefs.SetInt("InitNow", now);
            PlayerPrefs.Save();
            isSkip = false;
            debugText.text = name + "受到了特殊攻擊而無法行動\n";
            return isSkip;
        }
        else
        {
            randomSkip = Random.Range(0, 10);
            if (randomSkip > 7)
            {
                isSkip = true;
                return isSkip;
            }
            else
            {
                loading.now += 10;
                isSkip = false;
                return isSkip;
            }
        }
    }

    public void Attack(string name)
    {

        randomBreak = Random.Range(0, 10);
        if(!isdead)
        {
            if (randomBreak > 8)
            {
                attack = 15;
            }
            originalPosition = uiObject.anchoredPosition;
            StartCoroutine(MoveAndReturn());
            playerValue.BeAttack(name, attack);
        }
    }

    private IEnumerator MoveAndReturn()
    {
        Vector2 targetPosition = originalPosition + moveOffset;
        float elapsedTime = 0f;

        while (elapsedTime < moveDuration)
        {
            float t = elapsedTime / moveDuration;
            uiObject.anchoredPosition = Vector2.Lerp(originalPosition, targetPosition, t);

            elapsedTime += Time.deltaTime;
            yield return null;
        }
        yield return new WaitForSeconds(1f);

        elapsedTime = 0f;

        while (elapsedTime < moveDuration)
        {
            playerValue.AnimationHart(false);
            float t = elapsedTime / moveDuration;
            uiObject.anchoredPosition = Vector2.Lerp(targetPosition, originalPosition, t);

            elapsedTime += Time.deltaTime;
            yield return null;
        }
        uiObject.anchoredPosition = originalPosition;
    }
}
