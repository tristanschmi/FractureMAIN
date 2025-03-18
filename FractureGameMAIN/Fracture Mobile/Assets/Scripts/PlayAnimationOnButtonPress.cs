using UnityEngine;

public class PlayAnimationOnButtonPress : MonoBehaviour
{
    public Animator animator;
    public string animationName;

    public void PlayAnimation()
    {
        animator.Play(animationName);
    }
}