using UnityEngine;
using static UnityEngine.Random;

public class ObstacleMove : MonoBehaviour
{
    [SerializeField]
    private AgentAvoidController agentAvoidController;

    [SerializeField]
    [Range(0.5f, 25.0f)]
    private float speed = 5.0f;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();   
    }

    private void Move()
    {
        transform.localPosition = new Vector3(transform.localPosition.x  + Time.deltaTime * speed, transform.localPosition.y, transform.localPosition.z );
    }

    private void ResetObstacle()
    {
    
        //set obstacle to a random of three positions
        int rand = Range(0, 3);

        if (rand == 0) 
        {
            transform.localPosition = new Vector3(-17.5f, 1f, 0);
            transform.localRotation = Quaternion.identity;
        }
        
        if (rand == 1) 
        {
            transform.localPosition = new Vector3(-17.5f, 1f, -10f);
            transform.localRotation = Quaternion.identity;
        }
        
        if (rand == 2) 
        {
            transform.localPosition = new Vector3(-17.5f, 1f, 10f);
            transform.localRotation = Quaternion.identity;
        }
    }

    void OnCollisionEnter(Collision other) {

        if(other.transform.tag == "wall")
        {
            agentAvoidController.AddReward(1.0f);
            agentAvoidController.EndEpisode();
            ResetObstacle();
        }

        if(other.transform.tag == "agent")
        {
            agentAvoidController.AddReward(-0.1f);
            agentAvoidController.EndEpisode();
            ResetObstacle();
        }
    }
}
