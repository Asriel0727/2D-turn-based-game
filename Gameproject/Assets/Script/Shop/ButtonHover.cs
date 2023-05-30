using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image buttonImage;
    public Text buttonText;

    private Color originalColor;

    private void Start()
    {
        originalColor = buttonImage.color;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonImage.enabled = false;
        buttonText.gameObject.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {;
        buttonImage.enabled = true;
        buttonText.gameObject.SetActive(false);
    }
}
