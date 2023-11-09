using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorTest : MonoBehaviour
{
    public Animator animator;

    public KeyCode Keytotrigger = KeyCode.A;
    public KeyCode KeytoExit = KeyCode.S;

    public string triggerToPlay = "Fly";

    private void OnValidate()
    {
        if (animator == null) animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        /* if (Input.GetKeyDown(Keytotrigger))
        {
            animator.SetTrigger(triggerToPlay);
        } */

        if (Input.GetKeyDown(Keytotrigger))
        {
            animator.SetBool(triggerToPlay, true);
        }
        else if (Input.GetKeyDown(KeytoExit))
        {
            animator.SetBool(triggerToPlay, false);
        }
    }
}
