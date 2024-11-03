using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CollideToReload : MonoBehaviour
{
    [SerializeField] private MoveForwardBehaviour move;
    [SerializeField] private DrunkMovementBehaviour drunk;
    private static bool willReset = false;
    private Animator animator;

    void OnTriggerEnter(Collider other)
    {
        

        Debug.Log($"COLLIDED WITH {other.gameObject.name}");

        if (other.gameObject.tag == "Obstacle")
        {
            var animator = other.GetComponent<Animator>();
            animator.SetTrigger("Fall");
            move.Speed = 0f;
            drunk.enabled = false;


            if (willReset) return;
            willReset = true;
            Invoke(nameof(ResetScene), 2f);
        }
    }

    private void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        willReset = false;
    }
}
