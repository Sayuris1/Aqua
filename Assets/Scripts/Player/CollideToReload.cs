using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(MoveForwardBehaviour ))]
[RequireComponent(typeof(DrunkMovementBehaviour ))]
public class CollideToReload : MonoBehaviour
{
    private MoveForwardBehaviour _moveForwardBehaviour;
    private DrunkMovementBehaviour _drunkMovementBehaviour;
    private static bool _willReset = false;

    private void Start()
    {
        _moveForwardBehaviour = GetComponent<MoveForwardBehaviour>();
        _drunkMovementBehaviour = GetComponent<DrunkMovementBehaviour>();

        _willReset = false;
    }

    void OnCollisionEnter(Collision other)
    {
        Debug.Log($"COLLIDED WITH {other.gameObject.name}");

        if (!other.gameObject.CompareTag("Obstacle"))
            return;

        if (other.gameObject.TryGetComponent(out Animator animator))
            animator.SetTrigger("Fall");

        _moveForwardBehaviour.Speed = 0f;
        _drunkMovementBehaviour.enabled = false;

        if (_willReset)
            return;

        _willReset = true;
        Invoke(nameof(ResetScene), 2f);
    }

    private void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        _willReset = false;
    }
}
