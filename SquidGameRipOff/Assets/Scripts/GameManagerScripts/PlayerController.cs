using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public enum CurrentAnimation { idle,walk,jump};
    public Player mainPlayer;
    private Transform playerTransform;
    public float movementSpeed;
    public float jumpSpeed;
    private Animator playerAnimator;
    private Transform cameraObject;
    private int currentState = 0;
    float horizontal, vertical;
    Vector3 direction;
    Quaternion rotation;
    bool canJump = false, isgrounded;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = mainPlayer.playerObject.transform;
        playerAnimator = mainPlayer.animatorController;
        cameraObject = Camera.main.gameObject.transform;
      //  distanceFromPlayer = followCam.transform.position - playerTransform.position;
        playerAnimator.avatar = mainPlayer.characterAvatars[currentState].animationAvatar;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        direction = cameraObject.forward * vertical;
        direction = direction + cameraObject.right * horizontal;
        direction.Normalize();
        direction.y = 0;



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
        //if (Input.GetKeyDown(KeyCode.D))
        //{
        //    mainPlayer.playerObject.SetActive(false);
        //    mainPlayer.playerRagdoll.transform.position = playerTransform.position;
        //    mainPlayer.playerRagdoll.SetActive(true);
        //    isgrounded = true;
        //}
        RaycastHit hit;
    
        if(Physics.Raycast(playerTransform.position,Vector3.down,out hit, Mathf.Infinity))
        {
            Debug.DrawRay(playerTransform.position, Vector3.down*hit.distance,Color.red);
            Debug.Log(hit.collider.gameObject.name);
        }
        //  if (!isgrounded)
       // isgrounded = Physics.Raycast(playerTransform.position, Vector3.down, LayerMask.NameToLayer("Ground"));
      //  Debug.Log(isgrounded);
        if (!isgrounded) 
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("jump");
                playerAnimator.SetBool("Jump", true);
                mainPlayer.playerRigidBody.AddForce(Vector3.up * jumpSpeed);
                isgrounded = true;

            }


            playerAnimator.SetFloat("velocityY", vertical);
            playerAnimator.SetFloat("velocityX", horizontal);
            mainPlayer.playerRigidBody.velocity = direction * movementSpeed;
            Vector3 rotationDirection = direction;
            if (rotationDirection == Vector3.zero)
            {
                rotationDirection = mainPlayer.playerObject.transform.forward;
            }

            rotation = Quaternion.LookRotation(rotationDirection);
            mainPlayer.playerObject.transform.rotation = Quaternion.Slerp(mainPlayer.playerObject.transform.rotation, rotation,
                movementSpeed * Time.deltaTime);
        }

        //if (horizontal > 0)
        //{

        //}
        //if (vertical > 0)
        //{
        //    currentState = (int)CurrentAnimation.walk;
        //    playerAnimator.avatar = mainPlayer.characterAvatars[currentState].animationAvatar;
        //    playerAnimator.SetFloat("velocityY", vertical);
        //}
        //else if (vertical < 0)
        //{
        //    Debug.Log("Move Back");
        //}
        //else
        //{
        //    currentState = (int)CurrentAnimation.idle;
        //    playerAnimator.avatar = mainPlayer.characterAvatars[currentState].animationAvatar;
        //    playerAnimator.SetInteger("State", 0);
        //}
    }
    private void LateUpdate()
    {
        //if (mainPlayer.playerRigidBody.velocity.y < 0)
        //{
        //    mainPlayer.playerRigidBody.AddForce(-Vector3.up * jumpSpeed );
        //}
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {

            playerAnimator.SetBool("Jump", false);
            isgrounded = false;
        }
        if ( collision.gameObject.tag == "Obstacle")
        {
           // collision.gameObject.GetComponent<BoxCollider>().isTrigger = true;
            mainPlayer.playerObject.SetActive(false);
            mainPlayer.playerRagdoll.transform.position = playerTransform.position;
            mainPlayer.playerRagdoll.SetActive(true);
            isgrounded = true;
        }
    }


}
