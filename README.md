# Unity AR+GPS Demo 
A simple AR demonstration using the AR+GPS Location package from the Unity Store. The goal of this project is to demonstrate how latitude and longitude GPS coordinates from a device or user input can be used in AR applications.

## Dependencies
* Unity3D 2020.3.8 (LTS)
* [AR+GPS Location](https://assetstore.unity.com/packages/tools/integration/ar-gps-location-134882)

## Quick Start for Developers
1. Clone this repository into an empty directory. 
2. Paste the `ARLocation` folder into the `Assets/` directory of the Unity project.
3. Open the project on Unity3D ver. 2020.3.8. (If Unity prompts you to start in safe mode, leave an issue.) 
4. Change Game View aspect ratio to 1920x1080 portrait. In `File/Build Settings` change platform to Android.  
5. Connect Android device, then Build & Run to device. 

## Main Features
* Create landmarks in AR by inputting latitude and latitude coordinates. Save these coordinates with labels and a menu.
* Find your current location with the press of a button. 
* Click on landmarks to see their text descriptions. 
* Toggle UI on and off so that you can see landmarks onscreen more clearly. 

<div>
<img src="https://user-images.githubusercontent.com/43973044/155573273-ac7177ff-bbf8-4d7a-9c2b-9ef60e19603d.jpg" style="width:30vw"/>
<img src="https://user-images.githubusercontent.com/43973044/155573282-55047e87-d8b3-41d9-860e-3f09d424df1e.jpg" style="width:30vw"/>
</div>


## Code Summary

### [`CreateLandmark.cs`](./AR%20Project/Assets/Scripts/CreateLandmark.cs)
Generates new landmarks using the AR+GPS Location package, given a latitude, longitude, and label into the UI input fields. Adds new landmark entries into the UI dropdown menu, and allows the user to retrieve latitude and longitude through selection from the menu. 

### [`GetPermissions.cs`](./AR%20Project/Assets/Scripts/GetPermissions.cs)
Prompts the user for permission to access the Android device's GPS (fine location) and camera. 

### [`GetCurrentLocation.cs`](./AR%20Project/Assets/Scripts/GetCurrentLocation.cs)
Using the Android device's GPS, retrieve the user's latitude and longitude and display them on the UI input fields.  

### [`LandmarkDescription.cs`](./AR%20Project/Assets/Scripts/LandmarkDescription.cs)
Assigns default to new landmarks. Can potentially be expanded to retrieve text descriptions from API. 

### [`InteractWithLandmark.cs`](./AR%20Project/Assets/Scripts/InteractWithLandmark.cs)
Trigger display of landmark description with touch.

### [`ToggleUI.cs`](./AR%20Project/Assets/Scripts/ToggleUI.cs)
Hide or display UI elements.
