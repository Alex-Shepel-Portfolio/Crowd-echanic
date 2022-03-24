using UnityEngine;

public class CameraFallow : MonoBehaviour
{
    
    private Transform PlayerPos;
    [SerializeField] private float movingSpeed;
   

    private void Start()
    {
        PlayerPos = GameObject.FindGameObjectWithTag("Player").transform;

        this.transform.position = new Vector3()
        {
            x = this.PlayerPos.position.x,
            y = this.PlayerPos.position.y + 30,
            z = this.PlayerPos.position.z-40,
        };
    }


    private void Update()
    {

        if (PlayerPos.position.y != transform.position.y || PlayerPos.position.x != transform.position.x)
        {
            
            Vector3 target = new Vector3()
            {
                x = this.PlayerPos.position.x,
                y = this.PlayerPos.position.y + 30,
                z = this.PlayerPos.position.z-40,
            };


            Vector3 pos = Vector3.Lerp(a: this.transform.position, b: target, t: this.movingSpeed * Time.deltaTime);

            this.transform.position = pos;
        }


    }
}
