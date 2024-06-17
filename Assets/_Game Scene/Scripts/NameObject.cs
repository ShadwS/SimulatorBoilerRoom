using UnityEngine;

public class NameObject : MonoBehaviour
{
    [SerializeField] private string nameObject;
    
    public string GetNameObject() {  return nameObject; }
}
