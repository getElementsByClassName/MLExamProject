using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;

public class DuckController : Agent
{

    private Transform position;
    private Rigidbody rigidBody;
    [SerializeField] private Transform target; 
    public override void Initialize()
    {
        base.Initialize();

        rigidBody = GetComponent<Rigidbody>();
    }

    public override void OnEpisodeBegin()
    {
        transform.localPosition = new Vector3(-2.8f, 0.55f, -6.15f);
        //transform.localRotation = Quaternion.Euler(0f, 90f, 0f);
    }
    

    public override void CollectObservations(VectorSensor sensor)
    {
        //sensor.AddObservation(transform.localPosition);
        //sensor.AddObservation(transform.localRotation);
        sensor.AddObservation(target.localPosition);
    }

    
    public override void OnActionReceived(ActionBuffers actions)
    {
        //AddReward(0.1f);
        //float moveForward = actions.ContinuousActions[0];
        //float rotate = actions.ContinuousActions[1];

        //float moveSpeed = 3.0f;

        //rigidbody.MovePosition(transform.position + transform.forward * moveForward * moveSpeed * Time.deltaTime);
        //transform.Rotate(0f, rotate * moveSpeed, 0f, Space.Self);
        /*
        if (transform.localPosition != position.transform.localPosition)
        {
            position.transform.localPosition = transform.localPosition;
            AddReward(0.1f);
        }
        */
        
       
        float moveRotate = actions.ContinuousActions[0];
        float moveForward = actions.ContinuousActions[1];

        float moveSpeed = 4.0f;

        rigidBody.MovePosition(transform.position + transform.forward * moveForward * moveSpeed * Time.deltaTime);
        transform.Rotate(0f, moveRotate * moveSpeed, 0f, Space.Self);
          
    }

    //Heuristic calls OnActionReceived method
    public override void Heuristic(in ActionBuffers actionsOut)
    {
        ActionSegment<float> continuousActions = actionsOut.ContinuousActions;
        continuousActions[0] = Input.GetAxisRaw("Vertical");
        continuousActions[1] = Input.GetAxisRaw("Horizontal");
        
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "goal")
        {
            AddReward(2.0f);
            EndEpisode();
        }

        if (other.gameObject.tag == "wall")
        {
            AddReward(-0.1f);
            EndEpisode();
            //Debug.Log("Wall hit");
        }       
    }
}
