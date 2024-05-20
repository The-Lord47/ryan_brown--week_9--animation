using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorOpenScript : MonoBehaviour
{
    public Transform player;
    public float doorOpenRange;
    public GameObject floatingE;
    public GameObject floatingE2;

    private Animator _anim;

    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //checking to see if the player is in range of the door
        if(Vector3.Distance(transform.position, player.position) < doorOpenRange)
        {
            //if on the front side of the door
            if (Vector3.Distance(floatingE.transform.position, player.position) < Vector3.Distance(floatingE2.transform.position, player.position))
            {
                //setting the floating UI
                floatingE.SetActive(true);
                floatingE2.SetActive(false);

                //if the player interacts with the door
                if (Input.GetKeyDown(KeyCode.E))
                {
                    //checking to see if the door is open already
                    if (_anim.GetBool("isDoorOpen") == false && _anim.GetBool("isDoorOpenBack") == false)
                    {
                        //opens the door towards the inside
                        _anim.SetBool("isDoorOpen", true);
                    }

                    //closes the door if it is open
                    else
                    {
                        _anim.SetBool("isDoorOpen", false);
                        _anim.SetBool("isDoorOpenBack", false);
                    }
                }
            }

            //if on the back side of the door
            else
            {
                //setting the floating UI
                floatingE2.SetActive(true);
                floatingE.SetActive(false);

                //if the player interacts with the door
                if (Input.GetKeyDown(KeyCode.E))
                {
                    //checking to see if the door is open already
                    if (_anim.GetBool("isDoorOpenBack") == false && _anim.GetBool("isDoorOpen") == false)
                    {
                        //opens the door towards the inside
                        _anim.SetBool("isDoorOpenBack", true);
                    }

                    //closes the door if it is open
                    else
                    {
                        _anim.SetBool("isDoorOpen", false);
                        _anim.SetBool("isDoorOpenBack", false);
                    }
                }
            }
        }
        else
        {
            floatingE.SetActive(false);
            floatingE2.SetActive(false);
        }
    }
}
