using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DripScript : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        animator.SetTrigger("splash");
    }

    public void kill()
    {
        Destroy(gameObject);
    }
}
