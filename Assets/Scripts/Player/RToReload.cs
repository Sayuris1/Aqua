using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class RToReload : MonoBehaviour
{
    public void ReloadScene(InputAction.CallbackContext ctx)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
