using System.Collections;
using emilyFS;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FileOpener: MonoBehaviour {
	// UI Canvas to put window on
	public static Canvas canvas = FindObjectOfType<Canvas>();
	
	// Creates a new File Browser window, populates its icons, and returns it to be instantiated.
	public static GameObject LoadFolder (Folder location, Sprite windowIcon) {
		// File browser window to open
		GameObject browserWindow = Resources.Load<GameObject>("Prefabs/Window");
		// Create new folder window
		GameObject newInstance = Instantiate(browserWindow, canvas.transform);
		// Change window icon
		var instanceIcon = newInstance.transform.Find("Icon");
		instanceIcon.GetComponent<Image>().sprite = windowIcon;
		// Get all the App Launchers in browserWindow
		// Yeah, doing it by index, fight me
		GameObject[] appLaunchers = {
			newInstance.transform.GetChild(5).GameObject(),
			newInstance.transform.GetChild(6).GameObject(),
			newInstance.transform.GetChild(7).GameObject(),
			newInstance.transform.GetChild(8).GameObject(),
			newInstance.transform.GetChild(9).GameObject(),
			newInstance.transform.GetChild(10).GameObject(),
			newInstance.transform.GetChild(11).GameObject(),
			newInstance.transform.GetChild(12).GameObject()
		};
		// Populate the window with app icons
		for (int i = 0; i < location.Contents.Count; i++) {
			appLaunchers[i].GetComponent<Image>().sprite = location.Contents[i].Icon;
			appLaunchers[i].GetComponent<CreateWindow>().target = location.Contents[i];
			appLaunchers[i].SetActive(true);
		}
		// Set the window title to current folder name
		newInstance.GetComponent<TextMeshPro>().text = location.Name;

		return newInstance;
	}

	// If no icon is specified, default to the regular file 18x18 icon.
	public static GameObject LoadFolder(Folder location) {
		return LoadFolder(location, Resources.Load<Sprite>("Sprites/EmptyFolder18x18"));
	}
}