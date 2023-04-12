using emilyFS;
using TMPro;
using UnityEngine;

public class PasswordCheck : MonoBehaviour {
    public TMP_InputField PasswordEntry;
    public Folder target;
    public string password;
    
    public void CheckPassword() {
        // TODO explicit matching on a plain string? are you actually fucking kidding?
        if (PasswordEntry.text.Equals(password))
            // Open the target folder 
            Instantiate(FileOpener.LoadFolder(target, Resources.Load<Sprite>("Sprites/FolderZip18x18")));
        else
            Debug.Log("Text \'" + PasswordEntry.text + "\' does not match.");
    }
}
