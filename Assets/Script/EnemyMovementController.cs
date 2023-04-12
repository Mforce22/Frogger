using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementController : MonoBehaviour
{
    [Tooltip("speed of the enemy")]
    [SerializeField] private float _Speed = 0.01f;

    private Vector3 _startPosition;
    // Start is called before the first frame update
    void Start()
    {
        _startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        XMovement(_Speed);
    }

    private void XMovement(float speed)
    {
        transform.position += new Vector3(speed, 0, 0);
    }

    public void Reset()
    {
        transform.position = _startPosition;
    }
}
