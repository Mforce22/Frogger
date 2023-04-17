using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    [Tooltip("speed of the platform")]
    [SerializeField] private float _Speed = 10;

    [SerializeField] private int _StartLine = 1;



    private Vector3 _restartPosition;
    // Start is called before the first frame update
    void Start()
    {
        switch (_StartLine)
        {
            case 1:
                _restartPosition = new Vector3(4.72f, 0.98f, 0);
                break;
            case 2:
                _restartPosition = new Vector3(-4.77f, 1.68f, 0);
                break;
            case 3:
                _restartPosition = new Vector3(4.72f, 2.38f, 0);
                break;
            case 4:
                _restartPosition = new Vector3(-4.77f, 3.08f, 0);
                break;
            case 5:
                _restartPosition = new Vector3(4.72f, 3.78f, 0);
                break;
            default:
                _restartPosition = new Vector3(4.72f, 0.98f, 0);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        XMovement(_Speed);
    }

    private void XMovement(float speed)
    {
        speed = speed * Time.deltaTime;
        transform.position += new Vector3(speed, 0, 0);
    }

    public void Reset()
    {
        transform.position = _restartPosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("WorldBarrier"))
        {
            Reset();
        }

    }
}
