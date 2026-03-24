using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class player_door_interact : MonoBehaviour
{
    private bool nearDoor = false;
    private string sceneToLoad;

    void Update()
    {
        if (nearDoor && Keyboard.current.eKey.wasPressedThisFrame)
        {
            if (!string.IsNullOrEmpty(sceneToLoad))
            {
                SceneManager.LoadScene(sceneToLoad);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Door"))
        {
            door_interaction door = other.GetComponent<door_interaction>();
            if (door != null)
            {
                sceneToLoad = door.sceneToLoad;
                nearDoor = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Door"))
        {
            nearDoor = false;
            sceneToLoad = "";
        }
    }
}
