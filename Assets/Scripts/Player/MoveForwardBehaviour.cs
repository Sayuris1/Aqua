using UnityEngine;

public class MoveForwardBehaviour : MonoBehaviour
{
    public float Speed;

    void Update()
    {
        Vector3 newPos = transform.position;       
        //newPos.z += Speed * Mathf.PerlinNoise1D(Time.time) * Time.deltaTime;
        newPos.z += Speed * Time.deltaTime;
        transform.position = newPos;
    }
}
