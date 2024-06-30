using UnityEngine;

public class CollisionDoorStreet : Door
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>() != null) 
        {
            StartCoroutine(OpenDoorStreet());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Player>() != null)
        {
            StartCoroutine(ClosetDoor());
        }
    }

}
