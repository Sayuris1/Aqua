using UnityEngine;

public class FallowObjectBehaviour : MonoBehaviour
{
    public bool IsXFollow = false;
    public float FollowSpeed = 0.1f;
    public GameObject GameObjectToFollow;

    private Vector3 _distance;

    private void Awake()
    {
        _distance = transform.position - GameObjectToFollow.transform.position;
    }

    void Update()
    {
        Vector3 newPos = GameObjectToFollow.transform.position + _distance;        
        if(!IsXFollow)
            newPos.x = 0;
        
        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed);
    }
}