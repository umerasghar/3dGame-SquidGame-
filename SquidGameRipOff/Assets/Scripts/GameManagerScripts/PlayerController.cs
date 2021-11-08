using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public enum CurrentAnimation { idle,walk,jump};
    public Player mainPlayer;
    public float cameraMoveSensitvity;

    private Animator playerAnimator;

    private int currentState = 0;
    float horizontal, vertical;
    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = mainPlayer.animatorController;
      //  distanceFromPlayer = followCam.transform.position - playerTransform.position;
        playerAnimator.avatar = mainPlayer.characterAvatars[currentState].animationAvatar;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        //Control Player
        //if (Input.GetKeyDown(KeyCode.W))
        //{
        //    currentState = (int)CurrentAnimation.walk;
        //    playerAnimator.avatar = mainPlayer.characterAvatars[currentState].animationAvatar;
        //    playerAnimator.SetInteger("State", 1);

        //}
        //if (Input.GetKeyUp(KeyCode.W))
        //{
        //    currentState = (int)CurrentAnimation.idle;
        //    playerAnimator.avatar = mainPlayer.characterAvatars[currentState].animationAvatar;
        //    playerAnimator.SetInteger("State", 0);
        //}

        
    }
    private void FixedUpdate()
    {
        if (vertical > 0)
        {
            currentState = (int)CurrentAnimation.walk;
            playerAnimator.avatar = mainPlayer.characterAvatars[currentState].animationAvatar;
            playerAnimator.SetInteger("State", 1);
        }
        else if (vertical < 0)
        {
            Debug.Log("Move Back");
        }
        else
        {
            currentState = (int)CurrentAnimation.idle;
            playerAnimator.avatar = mainPlayer.characterAvatars[currentState].animationAvatar;
            playerAnimator.SetInteger("State", 0);
        }
    }

}
