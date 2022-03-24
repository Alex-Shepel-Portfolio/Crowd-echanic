using System.Collections.Generic;
using UnityEngine;

public class SpawnBolvanov : MonoBehaviour
{
    public static SpawnBolvanov Instance { get;  private set; }
    public int Count {  get; set; }



    private class ActiveBolvanchik
    {

        public GameObject Bolvanchik;
        public Vector3 Pos;

        public void MoveToPos()
        {

            Bolvanchik.transform.position = Pos;
            
        }

    }


    [SerializeField] private float _radius = 3f;

    [SerializeField] private GameObject _bolvanchikPrefab;

    [SerializeField] private Transform _spawnPoint;

    
    private const int POOL_SIZE = 100;

    
    private Queue<GameObject> _BolvanchikPool = new Queue<GameObject>();

    private List<ActiveBolvanchik> _ActiveBolvanchik = new List<ActiveBolvanchik>();

    private Vector3 _spawnPos;

    public void Awake()
    {
        Instance = this;
    }

   private void Start()
    {
        for (int i = 0; i < POOL_SIZE; i++)
        {
            GameObject temp = Instantiate(_bolvanchikPrefab, transform);
            temp.gameObject.SetActive(false);
            _BolvanchikPool.Enqueue(temp);
        }
    }

   private void Update()
    {
       

        

        for (int i = 0; i < _ActiveBolvanchik.Count; i++)
        {
            ActiveBolvanchik at = _ActiveBolvanchik[i];

            at.Bolvanchik.gameObject.SetActive(true);
            _BolvanchikPool.Enqueue(at.Bolvanchik);
            _ActiveBolvanchik.RemoveAt(i);
            
        }

    }

    public void SpawnBolvanchik(int spawnCount)
    {
        Score.SetScore.count += spawnCount;


        while (spawnCount > 0)
        {
            
            var t = _BolvanchikPool.Dequeue();
            t.gameObject.SetActive(true);
            ActiveBolvanchik at = new ActiveBolvanchik();
            spawnCount--;
            _spawnPos = _spawnPoint.position + Random.insideUnitSphere * _radius;
            _spawnPos.y = 1f;
            at.Pos = _spawnPos;
            at.Bolvanchik = t;
            at.MoveToPos();
            _ActiveBolvanchik.Add(at);

        }
    }
    
}
