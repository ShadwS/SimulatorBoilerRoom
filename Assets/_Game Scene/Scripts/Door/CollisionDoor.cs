using UnityEngine;

public class CollisionDoor : Door
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>() != null) 
        {
            StartCoroutine(OpenDoorStreet());
        }
    }
}
