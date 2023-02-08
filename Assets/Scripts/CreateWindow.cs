using UnityEngine;
using UnityEngine.UI;

public class CreateWindow : MonoBehaviour
{
    private Button _button;
    
    // Program to launch
    public GameObject program;
    // UI Canvas to put window on
    public Canvas canvas;
    
    void Awake() {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnMouseDown);
    }

    void OnMouseDown()
    {
        Instantiate(program, canvas.transform);
    }
}
