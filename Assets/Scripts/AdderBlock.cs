using UnityEngine;
using TMPro;

public class AdderBlock : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private int _countBolvan = 0;
  
 
    private void Start()
    {
       
        _scoreText.text = ("+"+_countBolvan).ToString();
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<Bolvanchik>() != null)
        {
           
            SpawnBolvanov.Instance.SpawnBolvanchik(_countBolvan+1);
            
            gameObject.SetActive(false);
        }
    }
}
