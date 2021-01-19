using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public Text tooltip;
    public Text go;
    public Text re;
    public Text mainmenu;
    public Text restart;
    public Text win;
    public Text back;
    public Text cont;
    //public Text finish;

    bool gameHasEnded = false;
    int stage = 0; //refers to what part they are at to get which tool tip
    
    

    public void GameOver()
    {
        if (!gameHasEnded)
        {
            player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            //Debug.Log("yes im here");
            go.enabled = true;
            re.enabled = true;
            gameHasEnded = true;
            Debug.Log("GAMEOVER");
        }
    }
    public void Proceed()
    {
        if (SceneManager.GetActiveScene().name.Equals("Tutorial"))
        {
            tooltip.text = "Good job, you did it!" +
                    "\nNow hit ESC and go to the Main Menu!" +
                    "\nOr restart to try again!";
        }
        else
        {
            if (SceneManager.GetActiveScene().name.Equals("One"))
            {
                if (!gameHasEnded)
                {
                    player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                    win.enabled = true;
                    back.enabled = true;
                    cont.enabled = true;
                    gameHasEnded = true;
                }
            }
            if (SceneManager.GetActiveScene().name.Equals("Two"))
            {
                if (!gameHasEnded)
                {
                    player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                    win.enabled = true;
                    back.enabled = true;
                    cont.enabled = true;
                    gameHasEnded = true;
                }
            }
            if (SceneManager.GetActiveScene().name.Equals("Three"))
            {
                if (!gameHasEnded)
                {
                    player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                    win.enabled = true;
                    back.enabled = true;
                    cont.enabled = true;
                    gameHasEnded = true;
                }
            }
            if (SceneManager.GetActiveScene().name.Equals("Four"))
            {
                if (!gameHasEnded)
                {
                    player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                    win.enabled = true;
                    back.enabled = true;
                    cont.enabled = true;
                    gameHasEnded = true;
                }
            }
        }
    }

    public void Continue()
    {
        if (SceneManager.GetActiveScene().name.Equals("One"))
        {
            Debug.Log("CONTINUEONE");
            SceneManager.LoadScene("Two");
        }
        if (SceneManager.GetActiveScene().name.Equals("Two"))
        {
            Debug.Log("CONTINUETWO");
            SceneManager.LoadScene("Three");
        }
        if (SceneManager.GetActiveScene().name.Equals("Three"))
        {
            Debug.Log("CONTINUETHREE");
            SceneManager.LoadScene("Four");
        }
        if (SceneManager.GetActiveScene().name.Equals("Four"))
        {
            Debug.Log("CONTINUEFOUR");
            SceneManager.LoadScene("Levels");
        }
    }

    public void Fallen()
    {
        if (SceneManager.GetActiveScene().name.Equals("Four"))
        {
            //nothing because fall death is not enabled on this level
        }
        else
        {
            if(player.GetComponent<Rigidbody>().transform.position.y < -10)
            {
                Debug.Log("FallDeath");
                GameOver();
            }
            
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
     
    public void TitleScreen()
    {
        SceneManager.LoadScene("Title Screen");
    }
    
    //used for creating tooltips
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !gameHasEnded)
        {
            mainmenu.enabled = !mainmenu.enabled;
            restart.enabled = !restart.enabled;
        }
        //tool tips are only need in tutorial
        if (SceneManager.GetActiveScene().name.Equals("Tutorial"))
        {
            if(player.GetComponent<Rigidbody>().position.x > 30 && stage < 1)
            {
                stage = 1;
                tooltip.text = "Try hitting shift!" +
                    "\nThen control with WASD!";
            }
            if (player.GetComponent<Rigidbody>().position.x > 80 && stage < 2)
            {
                stage = 2;
                tooltip.text = "Beware of the Blue Block!" +
                    "\nIt will destroy you!";
            }
            if (player.GetComponent<Rigidbody>().position.x > 110 && stage < 3)
            {
                stage = 3;
                tooltip.text = "Land on the Green Platform to Win!";
            }
        }
        if (SceneManager.GetActiveScene().name.Equals("One"))
        {

        }
        if (SceneManager.GetActiveScene().name.Equals("Two"))
        {

        }
        if (SceneManager.GetActiveScene().name.Equals("Three"))
        {
            if(Time.realtimeSinceStartup > 45)
            {
                tooltip.text = "Level 3" +
                    "\nHint: Jump!";
            }
        }
        if (SceneManager.GetActiveScene().name.Equals("Four"))
        {
            
        }
        Fallen();
    }
}
