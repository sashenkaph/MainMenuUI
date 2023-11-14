using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonEvent : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    Color highlightedByEmission = new(3.355232f, 5.190451f, 1.787278f, 2.792784f);

    private Image imageComp;
    private Color emissionColor;

    // Start is called before the first frame update
    void Start()
    {
        imageComp = GetComponent<Image>();
        emissionColor = imageComp.material.GetColor("_EmissionColor");
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        imageComp.material.SetColor("_EmissionColor", highlightedByEmission);
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        imageComp.material.SetColor("_EmissionColor", emissionColor);
    }
}
