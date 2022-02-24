using UnityEngine;
using TMPro;

public class InteractWithLandmark : MonoBehaviour
{
    public TextMeshProUGUI infobox;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                GameObject obj = hit.collider.gameObject;
                Debug.Log(obj.name);
                infobox.text = obj.GetComponentInParent<LandmarkDescription>().text;
            }
        }
    }
}
