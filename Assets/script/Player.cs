
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    public float speed = 10f;
    public float jumpforce = 12f;
    public Animator playeranimator;

    public static bool gameOver;
    private Rigidbody2D _rigidbody2D;
    private float _horizontal;
    private bool _isjumping = false;
    private bool _ontheblock = false;


    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = this.GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "block")
        {
            _ontheblock = true;
        }

        if (collision.gameObject.tag == "point")
        {
            
            scoreText.score += 1;
            Destroy(collision.gameObject);
            
        }

        if (collision.gameObject.tag == "winflag")
        {
            SceneManager.LoadScene("WinScene");
        }else if (collision.gameObject.tag == "obstacle")
        {
            SceneManager.LoadScene("GameOver");

        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "block")
        {
            _ontheblock = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        _horizontal = Input.GetAxis("Horizontal");

        if (Input.GetButton("Vertical") && _ontheblock == true){
            _isjumping = true;
        }
    }

   
    private void FixedUpdate()
    {
        playeranimator.SetFloat("speed", Mathf.Abs(_horizontal));

        if (_horizontal >= 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        
        if (_isjumping == true)
        {
            _isjumping = false;
            playeranimator.SetBool("jump", true);
            _rigidbody2D.AddForce(new Vector2(0, jumpforce), ForceMode2D.Impulse);
        }
        else
        {
            playeranimator.SetBool("jump", false);
        }

        transform.position += new Vector3(_horizontal, 0, 0) * Time.fixedDeltaTime * speed;

    }
}
