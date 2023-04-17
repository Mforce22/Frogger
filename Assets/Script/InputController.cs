using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputController : MonoBehaviour
{

    //start y = -4.62
    [Header("Movement Settings")]
    [Tooltip("Speed of the main character")]
    [SerializeField] private float _Speed = 1.0f;

    [Tooltip("The delay between the player input")]
    [SerializeField] private float _PlayerDelay = 0.3f;

    [SerializeField] protected MoveController _MoveController;

    private float _currentDelay = 0.0f;
    private bool _movementCheck = true;

    private Vector2 _restartPosition;

    private bool _gameEnded = false;
    // Start is called before the first frame update ef
    void Start()
    {
        _restartPosition = transform.position;

        //set game aspect ratio , should be 14:16
        Screen.SetResolution(1080, 945, true);
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
        if (!_gameEnded)
        {
            //check for the platform
            Collider2D platform = Physics2D.OverlapBox(transform.position, Vector2.zero, 0, LayerMask.GetMask("Platform"));
            Collider2D water = Physics2D.OverlapBox(transform.position, Vector2.zero, 0, LayerMask.GetMask("Water"));
            if (platform != null)
            {
                //Debug.Log("You have reached the platform");
                transform.SetParent(platform.transform);
            }
            else if (water != null)
            {
                transform.SetParent(null);
                GetComponent<CollisionController>().Defeat();
            }
            else
            {
                transform.SetParent(null);
            }


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
        else
        {
            if (Input.GetKey(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
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

    public void EndGame()
    {
        _gameEnded = true;
    }

    public void Restart()
    {
        transform.position = _restartPosition;
    }
}
