
using System;
using System.Collections;
using System.Collections.Generic;
using static UnityEngine.Random;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using Unity.VisualScripting;

public class AgentController : Agent
{
    private float moveSpeed = 10.0f; //agent speed
    private float rotateSpeed = 3.0f; //agent rotate speed

    [SerializeField] SoapSpawner soapSpawner; //objects spawning sooaps
    private Rigidbody rigidBody; //rigid body of agent

    [SerializeField] GameObject checkPoint1;
    [SerializeField] GameObject checkPoint2;


    public override void Initialize()
    {
        base.Initialize();

        rigidBody = GetComponent<Rigidbody>();

    }

    public override void OnEpisodeBegin()
    {
        transform.localPosition = new Vector3(20.5f,0.55f,21.5f);

        //rigidBody.velocity = Vector3.zero;

        soapSpawner.SpawnSoap();

        //reset checkpoints
        checkPoint1.gameObject.SetActive(true);
        checkPoint2.gameObject.SetActive(true);
    }

  

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.localPosition);
        //sensor.AddObservation(target1.localPosition);
        //sensor.AddObservation(target2.localPosition);
        //sensor.AddObservation(target3.localPosition);
    }

    public override void OnActionReceived(ActionBuffers actions)
    {   

        //AddReward(-1f / MaxStep); //lower reward for less steps used
        //AddReward(0.005f); //reward for taking action

        /*
        //if actionspace is set to discrete
        var direction = Vector3.zero;
        var rotation = Vector3.zero;

        var action = actions.DiscreteActions[0];
        switch (action)
        {
            case 1:
                direction = transform.forward * 1f;
                AddReward(0.05f);
                break;
            case 2:
                direction = transform.forward * -1f;
                break;
            case 3:
                rotation = transform.up * 1f;
                break;
            case 4:
                rotation = transform.up * -1f;
                break;
        }
        transform.Rotate(rotation, Time.deltaTime * 100f);
        rigidBody.MovePosition(transform.position + direction *moveSpeed *Time.deltaTime);
        */
        
        //if actionspace is set to continuous
        float rotate = actions.ContinuousActions[0];
        float forward = actions.ContinuousActions[1];

        /*
        if (forward > 0.0f)
        {
            AddReward(0.1f);
        }
        */
        //Debug.Log(move); 

        //move forward
        rigidBody.MovePosition(transform.position + transform.forward * forward * moveSpeed * Time.deltaTime);
        //rotate around Y-axis
        transform.Rotate(0f, rotate * rotateSpeed, 0f, Space.Self);
        
        
    


        /*
        float distance1 = Vector3.Distance(transform.position, target1.transform.position);
        float distance2 = Vector3.Distance(transform.position, target2.transform.position);
        float distance3 = Vector3.Distance(transform.position, target3.transform.position);

        if(distance1 < 2.0f || distance1 < 2.0f || distance1 < 2.0f)
        {
            AddReward(.5f);
        }
    */
        //Debug.Log(distance);


        //rigidBody.AddForce(dirToGo * 1.2f, ForceMode.VelocityChange);

        //float moveSpeed = 10.0f;

        //rigidBody.MovePosition(transform.position + transform.forward * moveForward * moveSpeed * Time.deltaTime);
        //transform.Rotate(0f, moveRotate * moveSpeed, 0f, Space.Self);



        
        /*
        float moveRotate = actions.ContinuousActions[0];
        float moveForward = actions.ContinuousActions[1];

        float moveSpeed = 10.0f;

        rigidBody.MovePosition(transform.position + transform.forward * moveForward * moveSpeed * Time.deltaTime);
        transform.Rotate(0f, moveRotate * moveSpeed, 0f, Space.Self);

        //Vector3 velocity = new Vector3(moveX, 0.0f, moveZ) * Time.deltaTime * moveSpeed;



        //transform.localPosition += velocity;
        */    
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        /*
        //ActionSpace structure for discrete actions
        var discreteActionsOut = actionsOut.DiscreteActions;
        if (Input.GetKey(KeyCode.D))
        {
            discreteActionsOut[0] = 3;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            discreteActionsOut[0] = 1;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            discreteActionsOut[0] = 4;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            discreteActionsOut[0] = 2;
        }
        */
        
        
        //If actionspace is continuous
        ActionSegment<float> continuousActions = actionsOut.ContinuousActions;
        continuousActions[0] = Input.GetAxisRaw("Horizontal");
        continuousActions[1] = Input.GetAxisRaw("Vertical");
        
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "goal_difficulty_1")
        {
            AddReward(0.20f);
            other.gameObject.SetActive(false);

        }
        if (other.gameObject.tag == "goal_difficulty_2")
        {
            AddReward(0.50f);
            other.gameObject.SetActive(false);

        }

        if (other.gameObject.tag == "goal_difficulty_3")
        {
            AddReward(1.0f);
            other.gameObject.SetActive(false);
    
        }

        if (other.gameObject.tag == "wall")
        {
            AddReward(-1.0f);
            EndEpisode();
        }

        if (other.gameObject.tag == "checkpoint1")
        {
            AddReward(0.5f);
            other.gameObject.SetActive(false);
            Debug.Log("Checkpoint");
            
        }

        if (other.gameObject.tag == "checkpoint2")
        {
            AddReward(0.75f);
            other.gameObject.SetActive(false);
            Debug.Log("Checkpoint");
            
        }          
    }
}
