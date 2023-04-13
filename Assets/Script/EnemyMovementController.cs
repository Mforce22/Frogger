using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementController : MonoBehaviour
{
    [Tooltip("speed of the enemy")]
    [SerializeField] private float _Speed = 10;

    [SerializeField] private int _StartLine = 1;

    [SerializeField] private List<Sprite> _EnemySpriteList;

    private Vector3 _restartPosition;
    // Start is called before the first frame update
    void Start()
    {
        switch (_StartLine)
        {
            case 1:
                _restartPosition = new Vector3(-4.77f, -3.92f, 0);
                break;
            case 2:
                _restartPosition = new Vector3(4.72f, -3.22f, 0);
                break;
            case 3:
                _restartPosition = new Vector3(-4.77f, -2.52f, 0);
                break;
            case 4:
                _restartPosition = new Vector3(4.72f, -1.82f, 0);
                break;
            case 5:
                _restartPosition = new Vector3(-4.77f, -1.12f, 0);
                break;
            case 6:
                _restartPosition = new Vector3(4.72f, -0.42f, 0);
                break;
            default:
                _restartPosition = new Vector3(-4.77f, -3.88f, 0);
                break;
        }

        int spriteIndex = Random.Range(0, _EnemySpriteList.Count);
        GetComponentInChildren<SpriteRenderer>().sprite = _EnemySpriteList[spriteIndex];
        //GetComponent<SpriteRenderer>().sprite = _EnemySpriteList[spriteIndex];

        //_StartLine = transform.position;
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

        int spriteIndex = Random.Range(0, _EnemySpriteList.Count);
        //get child object
        GetComponentInChildren<SpriteRenderer>().sprite = _EnemySpriteList[spriteIndex];

        //GetComponent<Enem>().sprite = _EnemySpriteList[spriteIndex];
    }
}
