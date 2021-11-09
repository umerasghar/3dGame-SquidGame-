using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class Player 
{
    [Header("Player Components")]
    public GameObject playerObject;
    public Animator animatorController;
    public Rigidbody playerRigidBody;
    public GameObject playerRagdoll;
    public Avatars[] characterAvatars;


}
[Serializable]
public class Avatars
{
    public int avatarID;
    public Avatar animationAvatar;
    public string animationType;
}
