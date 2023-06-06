using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Newtonsoft.Json.Linq;


public class TextLoader : MonoBehaviour
{
    public Text textComponent;
    public Text Cointext;

    public PlayerValue value;
    public string filePath = "ShopLog.txt";

    private Dictionary<string, List<string>> npcDialogues;

    void Update()
    {
        Cointext.text = value.coin.ToString();
    }

    public void LoadTextFile()
    {
        string fullPath = Path.Combine(Application.streamingAssetsPath, filePath);

        if (File.Exists(fullPath))
        {
            npcDialogues = new Dictionary<string, List<string>>();
            string[] lines = File.ReadAllLines(fullPath);

            foreach (string line in lines)
            {
                string[] dialogueData = line.Split('[');

                if (dialogueData.Length >= 2)
                {
                    string npc = dialogueData[1].Split(']')[0];
                    string dialogue = dialogueData[2].Split(']')[0];

                    if (npcDialogues.ContainsKey(npc))
                    {
                        npcDialogues[npc].Add(dialogue);
                    }
                    else
                    {
                        npcDialogues.Add(npc, new List<string>() { dialogue });
                    }
                }
            }
        }
        else
        {
            Debug.LogError("Text file not found at path: " + fullPath);
        }
    }

    public IEnumerator TypeText()
    {
        while (true)
        {
            string randomNpc = GetRandomNpc();
            List<string> dialogues = npcDialogues[randomNpc];
            string randomDialogue = dialogues[Random.Range(0, dialogues.Count)];

            textComponent.text = "";

            foreach (char letter in randomDialogue)
            {
                textComponent.text += letter;
                yield return new WaitForSeconds(0.05f);
            }

            yield return new WaitForSeconds(2.5f);
        }
    }

    string GetRandomNpc()
    {
        List<string> npcList = new List<string>(npcDialogues.Keys);
        return npcList[Random.Range(0, npcList.Count)];
    }
}
