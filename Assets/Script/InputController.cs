using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{

    [Header("Movement Settings")]
    [Tooltip("Speed of the main character")]
    [SerializeField] private float _Speed = 1.0f;

    [Tooltip("The delay between the player input")]
    [SerializeField] private float _PlayerDelay = 0.3f;

    [SerializeField] protected MoveController _MoveController;

    private float _currentDelay = 0.0f;
    private bool _movementCheck = true;
    // Start is called before the first frame update ef
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        IController();
        DelayController();
    }

    private void DelayController()
    {
        if (_currentDelay > 0)
        {
            _currentDelay -= Time.deltaTime;
        }
        else if (!_movementCheck)
        {
            _movementCheck = true;
        }
    }

    private void IController()
    {
        if (Input.GetKey(KeyCode.UpArrow) && _movementCheck)
        {
            ToggleMovement();
            _MoveController.YMovement(_Speed);
            //Debug.Log("up pressed");
            _currentDelay = _PlayerDelay;
        }

        else if (Input.GetKey(KeyCode.DownArrow) && _movementCheck)
        {
            ToggleMovement();
            _MoveController.YMovement(-_Speed);
            //Debug.Log("up pressed");
            _currentDelay = _PlayerDelay;
        }
        else if (Input.GetKey(KeyCode.RightArrow) && _movementCheck)
        {
            ToggleMovement();
            _MoveController.XMovement(_Speed);
            //Debug.Log("up pressed");
            _currentDelay = _PlayerDelay;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && _movementCheck)
        {
            ToggleMovement();
            _MoveController.XMovement(-_Speed);
            //Debug.Log("up pressed");
            _currentDelay = _PlayerDelay;
        }
    }

    private void ToggleMovement()
    {
        if (!_movementCheck)
        {
            _movementCheck = true;
        }
        else
        {
            _movementCheck = false;
        }
    }
}
