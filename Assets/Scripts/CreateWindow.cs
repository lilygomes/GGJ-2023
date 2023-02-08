using UnityEngine;
using UnityEngine.UI;

public class CreateWindow : MonoBehaviour
{
    private Button _button;
    
    // Program to launch
    public GameObject program;
    // UI Canvas to put window on
    public Canvas canvas;
    // Icon of window (default: empty folder)
    public Sprite icon; // TODO implement fallback icon

    void Awake() {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnMouseDown);
    }

    void OnMouseDown()
    {
        var instance = Instantiate(program, canvas.transform);
        var instanceIcon = instance.transform.Find("Icon");
        instanceIcon.GetComponent<Image>().sprite = icon;
    }
}
