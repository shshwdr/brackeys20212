using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricSpineRenderer : MonoBehaviour
{
    Animator animator;
    public bool isInitialRight = false;
    SkeletonMecanim skeleton;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        skeleton = GetComponent<SkeletonMecanim>();
    }
    public void setSpeed(float speed)
    {
        animator.SetFloat("speed", speed);
    }

    public void attack()
    {
        animator.SetTrigger("attack");
    }

    public void setDirection(Vector2 dir)
    {
        if(dir.x > 0.01)
        {
            skeleton.skeleton.FlipX = true;
        }
        else if(dir.x<=-0.01)
        {

            skeleton.skeleton.FlipX = false;
        }

        animator.SetFloat("speed", dir.magnitude);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
