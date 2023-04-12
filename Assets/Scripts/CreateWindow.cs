using emilyFS;
using UnityEngine;
using UnityEngine.UI;

public class CreateWindow : MonoBehaviour {
	private Button _button;

	// File to launch
	public File target;

	// UI Canvas to put window on
	public Canvas canvas;

	void Awake() {
		_button = GetComponent<Button>();
		_button.onClick.AddListener(OnMouseDown);
	}

	void OnMouseDown() {
		target.Open();
	}
}