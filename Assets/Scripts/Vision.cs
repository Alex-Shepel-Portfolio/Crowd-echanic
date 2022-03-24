using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Vision : MonoBehaviour
{

    public static Vision vision { get;  set; }

    public Collider[] EnemyInsaid;
    public float radiusVision = 20f;
    public Vector3 target;
    public bool findObj;
    public LayerMask Layer;
    // Start is called before the first frame update
    void Awake()
    {
        vision = this;
    }
   
    // Update is called once per frame
    void Update()
    {
        EnterCol();


    }

    void EnterCol()
    {
        Vector3 pos = new Vector3( this.transform.position.x, 1f, this.transform.position.z);
        EnemyInsaid = Physics.OverlapSphere(pos, radiusVision, Layer);

        if(EnemyInsaid.Length == 0) findObj = false;
        for (int i = 0; i < EnemyInsaid.Length; i++)
        {
            if (EnemyInsaid[i].tag == "Enemy")
            {
               
                target = EnemyInsaid[0].gameObject.transform.position;
                findObj = true;
                

            }
             


        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(new Vector3(this.transform.position.x, 1f, this.transform.position.z), radiusVision);
    }
}
