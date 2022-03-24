using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Pool))]

public class Gun : MonoBehaviour
{
    //Gun stats
    [SerializeField] private float _damage;
    [SerializeField] private float _timeBetweenShooting, _range;
    [SerializeField] private bool _allowButtonHold;
  

    //bools 
    private bool _shooting, _readyToShoot;

    //Reference
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private RaycastHit _rayHit;

    [SerializeField] private LineRenderer _line;

    [SerializeField]
    private LayerMask WhatIsEnemy;



    private Vector3 direction;

    private void Awake()
    {
         _readyToShoot = true;
    }

    private void Update()
    {
        Input();
    }

    private void Input()
    {
        if (Vision.vision.findObj) _shooting = true;
        else  _shooting = false;

        //Shoot
        if (_readyToShoot && _shooting )
        {
           
            Shoot();
        }
    }

    private void Shoot()
    {
        _readyToShoot = false;


        direction = Vision.vision.target;


        //RayCast
        if (Physics.Linecast(_attackPoint.transform.position, direction, out _rayHit, WhatIsEnemy))
        {
           
           if (_rayHit.collider.CompareTag("Enemy"))
            {
                if (_rayHit.collider.gameObject.GetComponent<Enemy>() != null)
                {
                    _rayHit.collider.gameObject.GetComponent<Enemy>().TakeDamage(_damage * Time.deltaTime);
                }
                 
                _line.SetPosition(0, _attackPoint.transform.position);
                _line.SetPosition(1, direction);
                StartCoroutine(ShootEffect());
            }     
        }

        Invoke("ResetShot", _timeBetweenShooting);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(_attackPoint.transform.position, direction);
    }

    private void ResetShot()
    {
        _readyToShoot = true;
    }
   
    IEnumerator ShootEffect()
    {
        _line.enabled = true;
        yield return new WaitForSeconds(_timeBetweenShooting);
        _line.enabled = false;
    }
}

