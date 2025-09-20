using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trans :  PersistentSingleton<Trans>
{
    [SerializeField] private Animator animator;
    private void Start()
    {
    }
    public void TransOut()
    {
        animator.Play("TranOut");
    }
    public void TransIn()
    {
        animator.Play("TranIn");
    }
}
