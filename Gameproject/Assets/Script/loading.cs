using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class loading : MonoBehaviour
{
    public int Max;
    public int now;
    public Text load_text;
    public GameObject specialButton;
    public Text debugText;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("InitNow"))
        {
            now = PlayerPrefs.GetInt("InitNow");
        }
        else
        {
            now = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        now = PlayerPrefs.GetInt("InitNow");
        checkValue(now);
        SpecialAttack(now);
    }
    private void checkValue(float nowValue)
    {
        if(nowValue >= 100)
        {
            this.transform.localPosition = new Vector3(0, 0, 0);
            load_text.text ="100%";
        }
        else if(nowValue < 100 && nowValue > 0)
        {
            this.transform.localPosition = new Vector3((-835 + 835 * (nowValue / Max)), 0, 0);
            load_text.text = now + "%";
        }
        else if(nowValue <= 0)
        {
            this.transform.localPosition = new Vector3(-835, 0, 0);
            load_text.text = "0%";
        }
    }

    public void SpecialAttack(int now)
    {
        if(now >= 100)
        {
            specialButton.SetActive(true);
        }
        else
        {
            specialButton.SetActive(false);
        }
    }
}
