
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    public float speed = 10f;
    public float jumpforce=10f;
    public Animator playeranimator;

    
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
        //check if the player is on the block or platform
        if (collision.gameObject.tag == "block" || collision.gameObject.tag=="platform")
        {
            _ontheblock = true;
        }

        //Add points 
        if (collision.gameObject.tag == "point")
        {
            
            scoreText.score += 1;
            Destroy(collision.gameObject);
            
        }

        //check if the player made a collition with the winflag object or an obstacle
        if (collision.gameObject.tag == "winflag")
        {
            SceneManager.LoadScene("WinScene");
        }else if (collision.gameObject.tag == "obstacle")
        {
            SceneManager.LoadScene("GameOver");

        }

        //platform movement
        if (collision.gameObject.tag == "platform")
        {
            this.transform.parent = collision.transform;
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //return false if the object is jumping out from the block
        if (collision.gameObject.tag == "block" || collision.gameObject.tag=="platform")
        {
            _ontheblock = false;
            this.transform.parent = null;
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
        //revert the run animation
        playeranimator.SetFloat("speed", Mathf.Abs(_horizontal));

        if (_horizontal >= 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        
        //adding jump physics 
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

//dedicatoria a Jhan Bolivar xd
