using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour
{
    public float speed = 1.0f;
    Rigidbody2D r2d;
    Animator _animator;
    Vector3 charPos;
    SpriteRenderer herosSprite;
    [SerializeField] GameObject camera;

    // Start is called before the first frame update
    void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        charPos = transform.position;
        herosSprite = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        //r2d.velocity = new Vector2(speed, 0f);

    }

    // Update is called once per frame
    void Update()
    {
        
        charPos = new Vector3(charPos.x + (Input.GetAxis("Horizontal") * speed * Time.deltaTime), charPos.y);
        transform.position = charPos;

        if(Input.GetAxis("Horizontal") > 0.1f){
            herosSprite.flipX = false;
        }
        else if(Input.GetAxis("Horizontal") < - 0.1f)
        {
            herosSprite.flipX = true;
        }

        if (Input.GetAxis("Horizontal") == 0)
        {
            _animator.SetFloat("speed", 0.0f); 
        }
        else
        { 
            _animator.SetFloat("speed", 1.0f);
        }
    }
    private void LateUpdate()
    {
        camera.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
    }



}
