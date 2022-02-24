using UnityEngine;
using TMPro;

public class ToggleUI : MonoBehaviour
{
    public Transform canvas;
    public bool isActive;

    void Start()
    {
        isActive = true;
        GetComponentInChildren<TextMeshProUGUI>().text = "-";
        for (int i = 0; i < canvas.childCount; i++)
        {
            canvas.GetChild(i).gameObject.SetActive(true);
        }
    }

    public void UpdateUI()
    {
        isActive = !isActive;
        GetComponentInChildren<TextMeshProUGUI>().text = isActive ? "-" : "+";
        for (int i=0; i < canvas.childCount; i++)
        {
            GameObject child = canvas.GetChild(i).gameObject;
            if (child.name != "ToggleUIButton")
            {
                child.SetActive(isActive);
            }
        }
    }
}
