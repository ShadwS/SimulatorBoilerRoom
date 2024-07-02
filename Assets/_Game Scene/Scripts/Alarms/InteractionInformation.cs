using UnityEngine;

[CreateAssetMenu(fileName = "InteractionInfoSelection", menuName = "infoObjectInteraction", order = 1)]
public class InteractionInformation : ScriptableObject
{
    public string[] NameButtons { get { return _nameButtons; } }
    public int CorrectButtonNumber { get { return _correctButtonNumber; } }
    public string ObjectState { get { return _objectState; } }
    public string ActionObject {  get { return _actionObject; } }

    [SerializeField] private string[] _nameButtons;
    [SerializeField] private int _correctButtonNumber;
    [SerializeField] private string _objectState;
    [SerializeField] private string _actionObject;
}
