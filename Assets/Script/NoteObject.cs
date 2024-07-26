using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    public bool canBePressed;

    public KeyCode keyToPress;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            if (canBePressed)
            {
                gameObject.SetActive(false);

                //GameManager.instance.NoteHit();

                if (Mathf.Abs(transform.position.y) > 0.25)
                {
                    GameManager.instance.NormalHit();
                }
                else if (Mathf.Abs(transform.position.y) > 0.05f)
                {
                    GameManager.instance.GoodHit();
                }
                else
                {
                    GameManager.instance.PerfectHit();
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Activator")
        {
            canBePressed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            if (gameObject.activeSelf == true)
            {
                GameManager.instance.NoteMissed();
                canBePressed = false;
            }          
        }
    }
}
