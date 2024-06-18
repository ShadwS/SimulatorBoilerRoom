using UnityEngine;

public class NameObject : MonoBehaviour
{
    [SerializeField] private string _nameObject;

    public string GetNameObject() => _nameObject;
}
