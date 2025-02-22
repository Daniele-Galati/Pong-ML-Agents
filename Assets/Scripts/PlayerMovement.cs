using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;

public class PlayerMovement : Agent
{
    [SerializeField] float speed = 3f;
    [SerializeField] float courtHeight = 8f;
    [SerializeField] Ball targetBall;
    public bool playerOne = true;

    public override void OnEpisodeBegin()
    {
        targetBall.ResetBall();
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        // position observation
        sensor.AddObservation(transform.localPosition.z);

        // ball observations
        sensor.AddObservation(targetBall.transform.localPosition.x);
        sensor.AddObservation(targetBall.transform.localPosition.z);
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        float movement = actions.ContinuousActions[0];
        if (movement > 0 && transform.localPosition.z < courtHeight / 2)
            transform.position = transform.position + Vector3.forward * Time.deltaTime * speed;
        else if (movement < 0 && transform.localPosition.z > -courtHeight / 2)
            transform.position = transform.position + Vector3.back * Time.deltaTime * speed;
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        // heuristic is inside fixedupdate, the movement feels clunky

        var continuousActionsOut = actionsOut.ContinuousActions;

        if (playerOne)
        {
            if (Input.GetKey(KeyCode.W) && transform.localPosition.z < courtHeight/2)
                continuousActionsOut[0] = 1;
            else if (Input.GetKey(KeyCode.S) && transform.localPosition.z > -courtHeight/2)
                continuousActionsOut[0] = -1;
        }
        else
        {
            if (Input.GetKey(KeyCode.I) && transform.localPosition.z < courtHeight/2)
                continuousActionsOut[0] = 1;
            else if (Input.GetKey(KeyCode.K) && transform.localPosition.z > -courtHeight / 2)
                continuousActionsOut[0] = -1;
        }


    }

    public void RewardPlayer(float reward)
    {
        SetReward(reward);
        Debug.Log("END EPISODE");
        EndEpisode();
    }
}
