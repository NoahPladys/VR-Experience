using System;
using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using UnityEngine;
using Random = UnityEngine.Random;

public class CubeAgent : Agent
{
    public Transform Target;
    public Transform TargetZone;

    public override void OnEpisodeBegin()
    {
        Target.gameObject.SetActive(true);
        targetPickedUp = false;
        // reset de positie en orientatie als de agent gevallen is
        if (this.transform.localPosition.y < 0)
        {
            this.transform.localPosition = new Vector3(-6, 0.5f, 0); this.transform.localRotation = Quaternion.identity;
        }
        
        // verplaats de target naar een nieuwe willekeurige locatie 
        Target.localPosition = new Vector3(Random.value * 8 - 4, 0.5f, Random.value * 8 - 4);
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        // Agent positie
        sensor.AddObservation(this.transform.localPosition);
    }

    public float speedMultiplier = 0.1f;
    public float rotationMultiplier = 5;
    private bool targetPickedUp = false;
    public override void OnActionReceived(ActionBuffers actionBuffers)
    {
        // Acties, size = 2
        Vector3 controlSignal = Vector3.zero;
        controlSignal.z = actionBuffers.ContinuousActions[0];
        transform.Translate(controlSignal * speedMultiplier);

        transform.Rotate(0.0f, rotationMultiplier * actionBuffers.ContinuousActions[1], 0.0f);

        // Beloningen
        float distanceToTarget = Vector3.Distance(this.transform.localPosition, Target.localPosition);

        // target bereikt
        if (!targetPickedUp && distanceToTarget < 1.42f)
        {
            Target.gameObject.SetActive(false);
            targetPickedUp = true;
            SetReward(1.0f);
        }

        float distanceToTargetZone = Vector3.Distance(this.transform.localPosition, TargetZone.localPosition);
            
        // Terug bij TargetZone
        if (targetPickedUp && this.transform.localPosition.x < -5)
        {
            SetReward(1.0f);
            EndEpisode();
        }

        // Van het platform gevallen?
        else if (this.transform.localPosition.y < 0)
        {
            EndEpisode();
        }
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var continuousActionsOut = actionsOut.ContinuousActions;
        continuousActionsOut[0] = Input.GetAxis("Vertical");
        continuousActionsOut[1] = Input.GetAxis("Horizontal");
    }
}
