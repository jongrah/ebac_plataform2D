using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public Rigidbody2D myRigidbody;

    [Header("Setup")]
    public SOPlayerSetup soPlayerSetup;

    /*[Header("Speed Setup")]
    //public Vector2 velocity;
    public Vector2 friction = new Vector2(-.1f, 0);
    public float speed;
    public float speedRun;
    public float forceJump = 2;

    [Header("Animation Setup")]
    public float jumpScaleY = 1.5f;
    public float jumpScaleX = .7f;
    public float animationDuration = .3f;
    public SOFloat soJumpScaleY;
    public SOFloat soJumpScaleX;
    public SOFloat soAnimationDuration;

    public Ease ease = Ease.OutBack;

    [Header("Animation Setup")]
    public string boolRun = "Run";
    public Animator animator;
    public string triggerDeath = "Death";
    public float playerSwipeDuration = .1f;*/

    private Animator _currentPlayer;

    private float _currentSpeed;
    //private bool _isRunning = false;

    [SerializeField] private HeathBase _heathBase;

    private void Awake()
    {
        if (_heathBase != null)
        {
            _heathBase.OnKill += OnPlayerKill;
        }

        _currentPlayer = Instantiate(soPlayerSetup.player,transform);
    }

    private void OnPlayerKill()
    {
        _heathBase.OnKill -= OnPlayerKill;

        _currentPlayer.SetTrigger(soPlayerSetup.triggerDeath);
    }


    private void Update()
    {
        HandleJump();
        HandleMoviment();

    }

    private void HandleMoviment()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            _currentSpeed = soPlayerSetup.speedRun;
            _currentPlayer.speed = 1.5f;
        }
        else
        {
            _currentSpeed = soPlayerSetup.speed;
            _currentPlayer.speed = 1;
        }
        //_isRunning = Input.GetKey(KeyCode.LeftControl);

       if (Input.GetKey(KeyCode.LeftArrow))
        {
            //myRigidbody.MovePosition(myRigidbody.position - velocity * Time.deltaTime);
            myRigidbody.velocity = new Vector2(-_currentSpeed, myRigidbody.velocity.y);

            if (myRigidbody.transform.localScale.x != -1)
            {
                myRigidbody.transform.DOScaleX(-1, soPlayerSetup.playerSwipeDuration);
            }
            _currentPlayer.SetBool(soPlayerSetup.boolRun, true);
        }
       else if (Input.GetKey(KeyCode.RightArrow))
        {
            //myRigidbody.MovePosition(myRigidbody.position + velocity * Time.deltaTime);
            myRigidbody.velocity = new Vector2(_currentSpeed, myRigidbody.velocity.y);

            if (myRigidbody.transform.localScale.x != 1)
            {
                myRigidbody.transform.DOScaleX(1, soPlayerSetup.playerSwipeDuration);
            }
            _currentPlayer.SetBool(soPlayerSetup.boolRun, true);
        }
       else
        {
            _currentPlayer.SetBool(soPlayerSetup.boolRun, false);
        }

       if(myRigidbody.velocity.x > 0)
        {
            myRigidbody.velocity += soPlayerSetup.friction;
        }

       else if (myRigidbody.velocity.x < 0)
        {
            myRigidbody.velocity -= soPlayerSetup.friction;
        }
       
    }



    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //myRigidbody.MovePosition(myRigidbody.position - velocity * Time.deltaTime);
            myRigidbody.velocity = Vector2.up * soPlayerSetup.forceJump;

            if (myRigidbody.transform.localScale.x != 1)
            {
                myRigidbody.transform.DOScaleX(1, soPlayerSetup.playerSwipeDuration);
            }

            else if (myRigidbody.transform.localScale.x != -1)
            {
                myRigidbody.transform.DOScaleX(-1, soPlayerSetup.playerSwipeDuration);
            }
            DOTween.Kill(myRigidbody.transform);
            //HandleScaleJump();
        }

    }

    /*private void HandleScaleJump()
    {
        myRigidbody.transform.DOScaleY(soPlayerSetup.jumpScaleY, soPlayerSetup.animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(soPlayerSetup.ease);
        myRigidbody.transform.DOScaleX(soPlayerSetup.jumpScaleX, soPlayerSetup.animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(soPlayerSetup.ease);
    } */

    public void DestroyMe()
    {
        Destroy(gameObject);
    }
}
