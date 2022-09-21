//using System.Collections.Generic;
//using UnityEngine;
//using Unity.MLAgents;
//using Unity.MLAgents.Sensors;
//using Unity.MLAgents.Actuators;
//using Unity.MLAgents.Policies;
//using System;

//// RollerAgent
//public class RollerAgent : Agent
//{
//    public Transform target; // TargetのTransform
//    Rigidbody rBody; // RollerAgentのRigidBody

//    // 初期化時に呼ばれる
//    public override void Initialize()
//    {
//        // RollerAgentのRigidBodyの参照の取得
//        this.rBody = GetComponent<Rigidbody>();
//    }

//    // エピソード開始時に呼ばれる
//    public override void OnEpisodeBegin()
//    {
//        // RollerAgentが床から落下している時
//        if (this.transform.localPosition.y < 0)
//        {
//            // RollerAgentの位置と速度をリセット
//            this.rBody.angularVelocity = Vector3.zero;
//            this.rBody.velocity = Vector3.zero;
//            this.transform.localPosition = new Vector3(0.0f, 0.5f, 0.0f);
//        }

//        // Targetの位置のリセット
//        target.localPosition = new Vector3(
//            UnityEngine.Random.value*8-4, 0.5f, UnityEngine.Random.value*8 - 4);
//    }

//    // 状態取得時に呼ばれる
//    //public override void CollectObservations(VectorSensor sensor)
//    //{
//    //    sensor.AddObservation(target.localPosition.x); //TargetのX座標
//    //    sensor.AddObservation(target.localPosition.z); //TargetのZ座標
//    //    sensor.AddObservation(this.transform.localPosition.x); //RollerAgentのX座標
//    //    sensor.AddObservation(this.transform.localPosition.z); //RollerAgentのZ座標
//    //    sensor.AddObservation(rBody.velocity.x); // RollerAgentのX速度
//    //    sensor.AddObservation(rBody.velocity.z); // RollerAgentのZ速度
//    //}

//    // 行動実行時に呼ばれる
//    public override void OnActionReceived(ActionBuffers actionBuffers)
//    {
//        // RollerAgentに力を加える
//        Vector3 controlSignal = Vector3.zero;
//        controlSignal.x = actionBuffers.ContinuousActions[0];
//        controlSignal.z = actionBuffers.ContinuousActions[1];
//        rBody.AddForce(controlSignal * 10);

//        // RollerAgentがTargetの位置にたどりついた時
//        float distanceToTarget = Vector3.Distance(
//            this.transform.localPosition, target.localPosition);
//        if (distanceToTarget < 1.42f)
//        {
//            AddReward(1.0f);
//            EndEpisode();
//        }

//        // RollerAgentが床から落下した時
//        if (this.transform.localPosition.y < 0)
//        {
//            EndEpisode();
//        }
//    }

//    // ヒューリスティックモードの行動決定時に呼ばれる
//    public override void Heuristic(in ActionBuffers actionsOut)
//    {
//        var continuousActionsOut = actionsOut.ContinuousActions;
//        continuousActionsOut[0] = Input.GetAxis("Horizontal");
//        continuousActionsOut[1] = Input.GetAxis("Vertical");
//    }
//}

//using System.Collections.Generic;
//using UnityEngine;
//using Unity.MLAgents;
//using Unity.MLAgents.Actuators;


//// RollerAgent
//public class RollerAgent : Agent
//{
//    public Transform target; // TargetのTransform
//    Rigidbody rBody; // RollerAgentのRigidBody

//    // 初期化時に呼ばれる
//    public override void Initialize()
//    {
//        // RollerAgentのRigidBodyの参照の取得
//        this.rBody = GetComponent<Rigidbody>();
//    }

//    // エピソード開始時に呼ばれる
//    public override void OnEpisodeBegin()
//    {
//        // RollerAgentが床から落下している時
//        if (this.transform.localPosition.y < 0)
//        {
//            // RollerAgentの位置と速度をリセット
//            this.rBody.angularVelocity = Vector3.zero;
//            this.rBody.velocity = Vector3.zero;
//            this.transform.localPosition = new Vector3(0.0f, 0.5f, 0.0f);
//        }

//        // Targetの位置のリセット
//        target.localPosition = new Vector3(
//            UnityEngine.Random.value * 8 - 4, 0.5f, UnityEngine.Random.value * 8 - 4);
//    }

//    ////状態取得時に呼ばれる
//    //public override void CollectObservations(VectorSensor sensor)
//    //{
//    //    sensor.AddObservation(target.localPosition.x); //TargetのX座標
//    //    sensor.AddObservation(target.localPosition.z); //TargetのZ座標
//    //    sensor.AddObservation(this.transform.localPosition.x); //RollerAgentのX座標
//    //    sensor.AddObservation(this.transform.localPosition.z); //RollerAgentのZ座標
//    //    sensor.AddObservation(rBody.velocity.x); // RollerAgentのX速度
//    //    sensor.AddObservation(rBody.velocity.z); // RollerAgentのZ速度
//    //}

//    // 行動実行時に呼ばれる
//    public override void OnActionReceived(ActionBuffers vectorActions)
//    {
//        // RollerAgentに力を加える
//        Vector3 dirToGo = Vector3.zero;
//        Vector3 rotateDir = Vector3.zero;
//        int action = (int)vectorActions.DiscreteActions[0];

//        if (action == 1) dirToGo = transform.forward;
//        if (action == 2) dirToGo = transform.forward * -1.0f;
//        if (action == 3) rotateDir = transform.up * -1.0f;
//        if (action == 4) rotateDir = transform.up;
//        transform.Rotate(rotateDir, Time.deltaTime * 200f);
//        rBody.AddForce(dirToGo * 0.4f,ForceMode.VelocityChange);


//        // RollerAgentがTargetの位置にたどりついた時
//        float distanceToTarget = Vector3.Distance(
//            this.transform.localPosition, target.localPosition);
//        if (distanceToTarget < 1.42f)
//        {
//            AddReward(1.0f);
//            EndEpisode();
//        }

//        // RollerAgentが床から落下した時
//        if (this.transform.localPosition.y < -0.1f)
//        {
//            EndEpisode();
//        }
//    }

//    // ヒューリスティックモードの行動決定時に呼ばれる
//    public override void Heuristic(in ActionBuffers actionsOut)
//    {
//        var actions = actionsOut.DiscreteActions; 
//        actions[0] = 0;
//        Debug.Log("A");
//        if (Input.GetKey(KeyCode.UpArrow)) actions[0] = 1;
//        if (Input.GetKey(KeyCode.DownArrow)) actions[0] = 2;
//        if (Input.GetKey(KeyCode.LeftArrow)) actions[0] = 3;
//        if (Input.GetKey(KeyCode.RightArrow)) actions[0] = 4;

//    }
//}

//using System.Collections.Generic;
//using UnityEngine;
//using Unity.MLAgents;
//using Unity.MLAgents.Sensors;
//using Unity.MLAgents.Actuators;
//using Unity.MLAgents.Policies;
//using System;

//// RollerAgent
//public class RollerAgent : Agent
//{
//    public int agentId;
//    public GameObject ball;
//    Transform ballTf;
//    Rigidbody ballRb;
//    public override void Initialize()
//    {
//        this.ballTf = this.ball.transform;
//        this.ballRb = this.ball.GetComponent<Rigidbody>();
//    }
//    public override void CollectObservations(VectorSensor sensor)
//    {
//        float dir = (agentId == 0) ? 1.0f : -1.0f;
//        sensor.AddObservation(ballTf.localPosition.x * dir);
//        sensor.AddObservation(ballTf.localPosition.z * dir);
//        sensor.AddObservation(ballRb.velocity.x * dir);
//        sensor.AddObservation(ballRb.velocity.z * dir);
//        sensor.AddObservation(transform.localPosition.x * dir);

//    }
//    private void OnCollisionEnter(Collision collision)
//    {
//        AddReward(0.1f);
//    }
//    public override void OnActionReceived(ActionBuffers actions)
//    {
//        float dir = (agentId == 0) ? 1.0f : -1.0f;
//        int action = actions.DiscreteActions[0];
//        Vector3 pos = transform.localPosition;
//        if (action == 1)
//        {
//            pos.x -= 0.2f * dir;
//        }
//        else if (action == 2)
//        {
//            pos.x += 0.2f * dir;
//        }
//        if (pos.x < -4.0f) pos.x = -4.0f;
//        if (pos.x > 4.0f) pos.x = 4.0f;
//        transform.localPosition = pos;
//    }
//    public override void Heuristic(in ActionBuffers actionsOut)
//    {
//        var action = actionsOut.DiscreteActions;
//        action[0] = 0;
//        if (Input.GetKey(KeyCode.LeftArrow)) action[0] = 1;
//        if (Input.GetKey(KeyCode.RightArrow)) action[0] = 2;
//    }
//}

//using System.Collections.Generic;
//using UnityEngine;
//using Unity.MLAgents;
//using Unity.MLAgents.Sensors;
//using Unity.MLAgents.Actuators;
//using Unity.MLAgents.Policies;
//using System;

//// RollerAgent
//public class RollerAgent : Agent
//{
//    Rigidbody rBody;
//    int lastCheckPoint;
//    int checkPointCount;
//    public override void Initialize()
//    {
//        this.rBody = GetComponent<Rigidbody>();
//    }

//    public override void OnEpisodeBegin()
//    {
//        this.lastCheckPoint = 0;
//        this.checkPointCount = 0;
//    }
//    public override void CollectObservations(VectorSensor sensor)
//    {
//        sensor.AddObservation(rBody.velocity.x);
//        sensor.AddObservation(rBody.velocity.z);

//    }

//    public override void OnActionReceived(ActionBuffers actions)
//    {
//        Vector3 diraToGo = Vector3.zero;
//        Vector3 rotateDir = Vector3.zero;
//        int action = actions.DiscreteActions[0];
//        if (action == 1) diraToGo = transform.forward;
//        if (action == 2) diraToGo = transform.forward*-1.0f;
//        if (action == 3) rotateDir = transform.up*-1.0f;
//        if (action == 4) rotateDir = transform.up;
//        this.transform.Rotate(rotateDir, Time.deltaTime * 200f);
//        this.rBody.AddForce(diraToGo * 0.4f, ForceMode.VelocityChange);

//        AddReward(-0.001f);
//    }

//    public void EnterCheckPoint(int checkPoint)
//    {
//        if (checkPoint == (this.lastCheckPoint + 1) % 4)
//        {
//            this.checkPointCount++;
//            AddReward(0.4f);
//            if (this.checkPointCount >= 4)
//            {
//                AddReward(0.6f);
//                EndEpisode();
//            }
//        }
//        else if (checkPoint == (this.lastCheckPoint - 1 + 4) % 4)
//        {
//            this.checkPointCount--;
//            AddReward(-0.4f);
//        }
//        this.lastCheckPoint = checkPoint;
//    }
//    public override void Heuristic(in ActionBuffers actionsOut)
//    {
//        var action = actionsOut.DiscreteActions;
//        action[0] = 0;
//        if (Input.GetKey(KeyCode.UpArrow)) action[0] = 1;
//        if (Input.GetKey(KeyCode.DownArrow)) action[0] = 2;
//        if (Input.GetKey(KeyCode.LeftArrow)) action[0] = 3;
//        if (Input.GetKey(KeyCode.RightArrow)) action[0] = 4;
//    }
//}

//using System.Collections.Generic;
//using UnityEngine;
//using Unity.MLAgents;
//using Unity.MLAgents.Sensors;
//using Unity.MLAgents.Actuators;
//using Unity.MLAgents.Policies;
//using System;

//// RollerAgent
//public class RollerAgent : Agent
//{
//    Rigidbody rBody;
//    int lastCheckPoint;
//    int checkPointCount;

//    float checkPointReward;
//    float episodeReward;
//    float stepReward;

//    public void SetEnvParameter()
//    {
//        EnvironmentParameters envParams = Academy.Instance.EnvironmentParameters;
//        this.checkPointReward = envParams.GetWithDefault("checkpoint_reward", 0.0f);
//        this.episodeReward = envParams.GetWithDefault("episode_reward", 2.0f);
//        this.stepReward = envParams.GetWithDefault("step_reward", -0.001f);
//    }
//    public override void Initialize()
//    {
//        this.rBody = GetComponent<Rigidbody>();
//    }

//    public override void OnEpisodeBegin()
//    {
//        this.lastCheckPoint = 0;
//        this.checkPointCount = 0;
//        SetEnvParameter();
//    }
//    public override void CollectObservations(VectorSensor sensor)
//    {
//        sensor.AddObservation(rBody.velocity.x);
//        sensor.AddObservation(rBody.velocity.z);

//    }

//    public override void OnActionReceived(ActionBuffers actions)
//    {
//        Vector3 diraToGo = Vector3.zero;
//        Vector3 rotateDir = Vector3.zero;
//        int action = actions.DiscreteActions[0];
//        if (action == 1) diraToGo = transform.forward;
//        if (action == 2) diraToGo = transform.forward * -1.0f;
//        if (action == 3) rotateDir = transform.up * -1.0f;
//        if (action == 4) rotateDir = transform.up;
//        this.transform.Rotate(rotateDir, Time.deltaTime * 200f);
//        this.rBody.AddForce(diraToGo * 0.4f, ForceMode.VelocityChange);

//        AddReward(this.stepReward);
//    }

//    public void EnterCheckPoint(int checkPoint)
//    {
//        if (checkPoint == (this.lastCheckPoint + 1) % 4)
//        {
//            this.checkPointCount++;
//            AddReward(this.checkPointReward);
//            if (this.checkPointCount >= 4)
//            {
//                AddReward(this.episodeReward);
//                EndEpisode();
//            }
//        }
//        else if (checkPoint == (this.lastCheckPoint - 1 + 4) % 4)
//        {
//            this.checkPointCount--;
//            AddReward(-this.checkPointReward);
//        }
//        this.lastCheckPoint = checkPoint;
//    }
//    public override void Heuristic(in ActionBuffers actionsOut)
//    {
//        var action = actionsOut.DiscreteActions;
//        action[0] = 0;
//        if (Input.GetKey(KeyCode.UpArrow)) action[0] = 1;
//        if (Input.GetKey(KeyCode.DownArrow)) action[0] = 2;
//        if (Input.GetKey(KeyCode.LeftArrow)) action[0] = 3;
//        if (Input.GetKey(KeyCode.RightArrow)) action[0] = 4;
//    }
//}

//using System.Collections.Generic;
//using UnityEngine;
//using Unity.MLAgents;
//using Unity.MLAgents.Sensors;
//using Unity.MLAgents.Actuators;
//using Unity.MLAgents.Policies;
//using System;

//// RollerAgent
//public class RollerAgent : Agent
//{
//    public Transform target; // TargetのTransform
//    Rigidbody rBody; // RollerAgentのRigidBody

//    // 初期化時に呼ばれる
//    public void SetEnvParameter()
//    {
//        EnvironmentParameters envParams = Academy.Instance.EnvironmentParameters;
//        rBody.mass = envParams.GetWithDefault("mass", 1.0f);
//        var scale = envParams.GetWithDefault("scale", 1.0f);
//        rBody.gameObject.transform.localScale = new Vector3(scale, scale, scale);
//    }
//    public override void Initialize()
//    {
//        // RollerAgentのRigidBodyの参照の取得
//        this.rBody = GetComponent<Rigidbody>();
//        SetEnvParameter();
//    }

//    // エピソード開始時に呼ばれる
//    public override void OnEpisodeBegin()
//    {
//        // RollerAgentが床から落下している時
//        if (this.transform.localPosition.y < 0)
//        {
//            // RollerAgentの位置と速度をリセット
//            this.rBody.angularVelocity = Vector3.zero;
//            this.rBody.velocity = Vector3.zero;
//            this.transform.localPosition = new Vector3(0.0f, 0.5f, 0.0f);
//        }

//        // Targetの位置のリセット
//        target.localPosition = new Vector3(
//            UnityEngine.Random.value * 8 - 4, 0.5f, UnityEngine.Random.value * 8 - 4);
//    }

//    //状態取得時に呼ばれる
//    public override void CollectObservations(VectorSensor sensor)
//    {
//        sensor.AddObservation(target.localPosition.x); //TargetのX座標
//        sensor.AddObservation(target.localPosition.z); //TargetのZ座標
//        sensor.AddObservation(this.transform.localPosition.x); //RollerAgentのX座標
//        sensor.AddObservation(this.transform.localPosition.z); //RollerAgentのZ座標
//        sensor.AddObservation(rBody.velocity.x); // RollerAgentのX速度
//        sensor.AddObservation(rBody.velocity.z); // RollerAgentのZ速度
//    }

//    // 行動実行時に呼ばれる
//    public override void OnActionReceived(ActionBuffers actionBuffers)
//    {
//        // RollerAgentに力を加える
//        Vector3 controlSignal = Vector3.zero;
//        controlSignal.x = actionBuffers.ContinuousActions[0];
//        controlSignal.z = actionBuffers.ContinuousActions[1];
//        rBody.AddForce(controlSignal * 10);

//        // RollerAgentがTargetの位置にたどりついた時
//        float distanceToTarget = Vector3.Distance(
//            this.transform.localPosition, target.localPosition);
//        if (distanceToTarget < 1.42f)
//        {
//            AddReward(1.0f);
//            EndEpisode();
//        }

//        // RollerAgentが床から落下した時
//        if (this.transform.localPosition.y < 0)
//        {
//            EndEpisode();
//        }
//    }

//    // ヒューリスティックモードの行動決定時に呼ばれる
//    public override void Heuristic(in ActionBuffers actionsOut)
//    {
//        var continuousActionsOut = actionsOut.ContinuousActions;
//        continuousActionsOut[0] = Input.GetAxis("Horizontal");
//        continuousActionsOut[1] = Input.GetAxis("Vertical");
//    }
//}

using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Policies;

// RollerAgent
public class RollerAgent : Agent
{
    Rigidbody rBody;
    public Transform[] targets;
    public GameObject[] boards;
    int boardId;

    public override void Initialize()
    {
        this.rBody = GetComponent<Rigidbody>();
    }

    public override void OnEpisodeBegin()
    {
        this.rBody.angularVelocity = Vector3.zero;
        this.rBody.velocity = Vector3.zero;
        this.transform.localPosition = new Vector3(0.0f, 0.5f, -5.5f);
        this.transform.rotation = Quaternion.Euler(0f, 0f, 0f);

        this.boardId = Random.Range(0, 2);
        this.boards[0].SetActive(boardId == 0);
        this.boards[1].SetActive(boardId == 1);
        if (Random.Range(0, 2) == 0)
        {
            this.targets[0].localPosition = new Vector3(-3f, 0.5f, 5f);
            this.targets[1].localPosition = new Vector3(3f, 0.5f, 5f);
        }
        else
        {
            this.targets[0].localPosition = new Vector3(3f, 0.5f, 5f);
            this.targets[1].localPosition = new Vector3(-3f, 0.5f, 5f);
        }
    }
    

    public override void OnActionReceived(ActionBuffers actions)
    {
        Vector3 diraToGo = Vector3.zero;
        Vector3 rotateDir = Vector3.zero;
        int action = actions.DiscreteActions[0];
        if (action == 1) diraToGo = transform.forward;
        if (action == 2) diraToGo = transform.forward * -1.0f;
        if (action == 3) rotateDir = transform.up * -1.0f;
        if (action == 4) rotateDir = transform.up;
        this.transform.Rotate(rotateDir, Time.deltaTime * 200f);
        this.rBody.AddForce(diraToGo * 0.4f, ForceMode.VelocityChange);

        for (int i = 0; i < 2; i++)
        {
            float distanceToTarget = Vector3.Distance(
                this.transform.localPosition, targets[i].localPosition);
            if(distanceToTarget < 1.42f)
            {
                if (i == boardId)
                {
                    AddReward(1.0f);
                }
                EndEpisode();
            }
        }
        AddReward(-0.0005f);
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var action = actionsOut.DiscreteActions;
        action[0] = 0;
        if (Input.GetKey(KeyCode.UpArrow)) action[0] = 1;
        if (Input.GetKey(KeyCode.DownArrow)) action[0] = 2;
        if (Input.GetKey(KeyCode.LeftArrow)) action[0] = 3;
        if (Input.GetKey(KeyCode.RightArrow)) action[0] = 4;
    }
}