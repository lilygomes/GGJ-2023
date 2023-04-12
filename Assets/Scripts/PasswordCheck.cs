using TMPro;
using UnityEngine;

public class PasswordCheck : MonoBehaviour {
    private string _password = "TEST"; // TODO pick a better password

    public TMP_InputField PasswordEntry;
    public GameObject browserWindow;
    
    public void CheckPassword() {
        // TODO explicit matching on a plain string? are you actually fucking kidding?
        if (PasswordEntry.text.Equals(_password)) {
            Instantiate()
        }
        else {
            Debug.Log("Text \'" + PasswordEntry.text + "\' does not match.");
        }
    }
}
