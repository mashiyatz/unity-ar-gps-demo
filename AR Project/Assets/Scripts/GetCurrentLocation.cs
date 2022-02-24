using UnityEngine;
using TMPro;

public class GetCurrentLocation : MonoBehaviour
{
    public Transform canvas;

    public void UpdateLocation()
    {
        canvas.Find("InputLatitude").GetComponent<TMP_InputField>().text = Input.location.lastData.latitude.ToString();
        canvas.Find("InputLongitude").GetComponent<TMP_InputField>().text = Input.location.lastData.longitude.ToString();
    }
}
