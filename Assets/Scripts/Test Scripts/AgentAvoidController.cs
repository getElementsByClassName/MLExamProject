
using static UnityEngine.Random;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;


public class AgentAvoidController : Agent
{

    [SerializeField]
    private Transform obstacle;


    //speed of agent
    [SerializeField]
    private float speed = 10.0f;

    //discrete positions that agent can have

    [SerializeField]
    private Vector3 idlePosition = new Vector3(20.0f, 0f, 0f);
    [SerializeField]
    private Vector3 rightPosition = new Vector3(20.0f, 0f, 10f);
    [SerializeField]
    private Vector3 leftPosition = new Vector3(20.0f, 0, -10f);

    private Vector3 moveTo = Vector3.zero;
    private Vector3 prevPosition = Vector3.zero;



    public override void OnEpisodeBegin()
    {
        //set agent to idle position
        transform.localPosition = idlePosition;

        //set obstacle to a random of three positions
        int rand = Range(0, 3);

        if (rand == 0) 
        {
            obstacle.localPosition = new Vector3(-17.5f, 1f, 0);
        }
        
        if (rand == 1) 
        {
            obstacle.localPosition = new Vector3(-17.5f, 1f, -10f);
        }
        
        if (rand == 2) 
        {
            obstacle.localPosition = new Vector3(-17.5f, 1f, 10f);
        }

    }

    public override void CollectObservations(VectorSensor sensor)
    {
        //track x, y, z for agent
        sensor.AddObservation(transform.localPosition);

        //track x, y, z for obstacle
        sensor.AddObservation(obstacle.transform.localPosition);
    
    }
    
    public override void OnActionReceived(ActionBuffers actions)
    {
        int direction = Mathf.FloorToInt(actions.DiscreteActions[0]);
        //prevPosition = moveTo;
        //int direction = Mathf.FloorToInt(actions);
        //moveTo = idlePosition;

        switch (direction)
        {
            case 0:
                moveTo = idlePosition;
                break;
            case 1:
                moveTo = leftPosition;
                break;
            case 2:
                moveTo = rightPosition;
                break;
        }

        transform.localPosition = Vector3.MoveTowards(transform.localPosition, moveTo, Time.fixedDeltaTime * speed);
        
        /*
        float move = actions.ContinuousActions[0];
        float moveSpeed = 2.0f;

        transform.localPosition += new Vector3(move, 0.0f) * Time.deltaTime * moveSpeed; 
        */   
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        Debug.Log("Heuristic");
        //ActionSegment<int> discreteActions = actionsOut.DiscreteActions;
        var discreteActions = actionsOut.DiscreteActions;

        //continuousActions[0] = Input.GetAxisRaw("Horizontal");
        //idle
        if (Input.GetKey(KeyCode.DownArrow))
        {
            Debug.Log("Down");
            discreteActions[0] = 0;
        }

        //move left
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            discreteActions[0] = 1;
        }

        //move right
        if (Input.GetKey(KeyCode.RightArrow))
        {
            discreteActions[0] = 2;
        }

    }

    private void OnTriggerEnter(Collider other) 
    {
      
    }
}
