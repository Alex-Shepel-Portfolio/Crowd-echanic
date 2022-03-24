using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PoolObject))]
public class Bulet : MonoBehaviour
{
    private PoolObject _poolObject;

    [SerializeField] private float _lifeTime = 2;
    [SerializeField] private float _speed = 100;

    private void Start()
    {
       
        _poolObject = GetComponent<PoolObject>();
    }

    private void OnEnable()
    {   
        StartCoroutine(Destroy());
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * (_speed * Time.deltaTime));
        
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag != "Bolvanchik"|| other.tag != "Bullet")
        {
            _poolObject.ReturnToPool();
        }

        if (other.tag == "Enemy")
        {
            other.gameObject.SetActive(false);
            _poolObject.ReturnToPool();
        }
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(_lifeTime);
        _poolObject.ReturnToPool();
        
    }
}
