using System.Collections.Generic;
using UnityEngine;
using ARLocation;
using TMPro;

public class CreateLandmark : MonoBehaviour
{
    public Transform canvas;
    public GameObject landmarkPrefab;
    public GameObject markerPrefab;

    private float lat;
    private float lon;
    private string lab;
    private TMP_Dropdown dropdown;

    public Dictionary<string, Vector2> locations = new Dictionary<string, Vector2>();

    private void Start()
    {
        dropdown = canvas.Find("Dropdown").GetComponent<TMP_Dropdown>();
    }

    public void Generate()
    {
        float.TryParse(canvas.Find("InputLatitude").GetComponent<TMP_InputField>().text, out lat);
        float.TryParse(canvas.Find("InputLongitude").GetComponent<TMP_InputField>().text, out lon);
        lab = canvas.Find("InputLabel").GetComponent<TMP_InputField>().text;

        // TODO: connect pathfinder to menu
        AddToMenu();

        GameObject newLandmark;
        // newLandmark = Instantiate(landmarkPrefab);
        newLandmark = Instantiate(markerPrefab);

        newLandmark.GetComponent<PlaceAtLocation>().Location = new Location()
        {
            Latitude = lat,
            Longitude = lon,
            Altitude = 0,
            AltitudeMode = AltitudeMode.DeviceRelative,
            Label = lab,
        };

        newLandmark.gameObject.name = lab;

        newLandmark.GetComponent<PlaceAtLocation>().PlacementOptions = new PlaceAtLocation.PlaceAtOptions()
        {
            HideObjectUntilItIsPlaced = true,
            MaxNumberOfLocationUpdates = 2,
            MovementSmoothing = 0.1f,
            UseMovingAverage = false
        };

        // Instantiate(markerPrefab, newLandmark.transform);
        // Can I replace landmarkPrefab with markerPrefab? I think original intention of separating them
        // is to make it possible to use different prefab assets for marker (e.g., capsule, cube, etc.) but
        // it seems like an extra unnecessary step.

    }

    private void AddToMenu()
    {
        
        if (lab != "")
        {
            // Check if menu item already exists.
            for (int i = 0; i < dropdown.options.Count; i++)
            {
                if (dropdown.options[i].text == lab) { return; }
            }
            locations.Add(lab, new Vector2(lat, lon)); // Check if label exists in dict. If not, add label:(lat, lon) to dict.
            List<string> coords = new List<string> { lab }; 
            dropdown.AddOptions(coords); // Add label to menu, if it's not already added.
            dropdown.RefreshShownValue();
        }
    }

    public void ChooseFromMenu(int value)
    {
        if (value == 0) { return; }
        string label = dropdown.options[value].text;
        canvas.Find("InputLabel").GetComponent<TMP_InputField>().text = label;
        canvas.Find("InputLatitude").GetComponent<TMP_InputField>().text = locations[label][0].ToString();
        canvas.Find("InputLongitude").GetComponent<TMP_InputField>().text = locations[label][1].ToString();
    }
}
