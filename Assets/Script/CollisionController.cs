using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionController : MonoBehaviour
{
    private int[] _Homes = new int[] { 0, 0, 0, 0, 0 };

    [SerializeField] private GameObject _EndScreen;

    [SerializeField] private Sprite deadFrog;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("ciao");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("hahahahahahaahahah sei morto");


        if (collision.CompareTag("Enemy"))
        {
            Defeat();
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else if (collision.CompareTag("Home"))
        {
            Debug.Log("You have reached the home");
            int index = collision.GetComponent<Home>().getIndex();
            _Homes[index] = 1;
            if (_Homes[0] == 1 && _Homes[1] == 1 && _Homes[2] == 1 && _Homes[3] == 1 && _Homes[4] == 1)
            {
                //Debug.Log("You have won the game");
                //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                Victory();
            }
            else
            {
                transform.SetParent(null);
                GetComponent<InputController>().Restart();
            }
        }

    }

    public void Victory()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        Debug.Log("You have won the game");
        _EndScreen.GetComponent<TheEnd>().EndGame(0);
        GetComponent<InputController>().EndGame();
    }

    public void Defeat()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<SpriteRenderer>().sprite = deadFrog;
        Debug.Log("You have lost the game");
        _EndScreen.GetComponent<TheEnd>().EndGame(1);
        GetComponent<InputController>().EndGame();
    }
}
