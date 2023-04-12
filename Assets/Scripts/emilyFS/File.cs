using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace emilyFS {
	public class OpenFileBrowser : MonoBehaviour {
		// UI Canvas to put window on
		public Canvas canvas;
		// File browser window to open
		public GameObject browserWindow;
		// Icon of the browser window
		public Sprite windowIcon;
		// Holds the 8 App Launchers inside browserWindow
		private GameObject[] appLaunchers;

		public static void LoadFolder (Folder location) {
			// Create new folder window
			GameObject newInstance = Instantiate(browserWindow, canvas.transform);
			var instanceIcon = newInstance.transform.Find("Icon");
			instanceIcon.GetComponent<Image>().sprite = windowIcon;
			// Get all the App Launchers in browserWindow
			// Yeah, doing it by index, fight me
			appLaunchers = new GameObject[] {
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
			for (int i = 0; i < location.contents.Count; i++) {
				appLaunchers[i].GetComponent<Image>().sprite = location.contents[i].Icon;
				appLaunchers[i].GetComponent<CreateWindow>().program = 
				appLaunchers[i].SetActive(true);
			}
		}
	}
	
	public abstract class File {
		public string Name;
		public Sprite Icon;
		public Object Data;
		public abstract void Open();
	}

	public class Folder : File {
		public Folder parent;
		public List<File> contents;

		public void Open() {
			OpenFileBrowser.LoadFolder(this);
		}
	}
}