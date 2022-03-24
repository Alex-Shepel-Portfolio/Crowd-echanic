using UnityEngine;

public class Bolvanchik : MonoBehaviour
{
    private Vector3 _moveVector;

    private MoveController _vector;

    [SerializeField] private Transform _playerPos;
    [SerializeField] private float _radius = 3;
    
    private Vector3 _direction;

   
 
    void Start()
    {
        _playerPos = GameObject.FindGameObjectWithTag("Player").transform;


        _vector = FindObjectOfType<MoveController>();
        _moveVector = _vector.MoveVector;

        

    }


    void Update()
    {
        
       bool getTarget = Vision.vision.findObj;



        if (getTarget) { _direction = Vision.vision.target;  _direction -= this.transform.position; }
        else { if (_moveVector != new Vector3(0f, 0f, 0f)) _direction = _moveVector; }; 

            Quaternion rotation = Quaternion.LookRotation(_direction);
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, rotation, 10f * Time.deltaTime);
        


        int col = Score.SetScore.count;
        _radius = col / 5;

        Vector3 center = _playerPos.position;
        center.y = this.transform.position.y;

        float distance = Vector3.Distance(this.transform.position, center);

        if (distance > _radius)
        {

            this.transform.position += -(this.transform.position - center) * Time.deltaTime;
        }

        PlayerMove();

        
    }


    
    private void OnCollisionEnter(Collision collider)
    {
        if (collider.collider.tag == "Enemy" || collider.collider.tag == "Killer")
        {
            ReturnToPull();
        }
       

    }
    
    private void PlayerMove()
    {
        _moveVector = Vector3.zero;
        _moveVector = _vector.MoveVector;
        _moveVector.y = 0f;
        transform.localPosition += _moveVector* Time.deltaTime;
    }

    public void ReturnToPull()
    {
        Score.SetScore.count --;
        gameObject.SetActive(false);
    }
}
