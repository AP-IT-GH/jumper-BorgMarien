
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

public class Jumper_agent : Agent
{
    public float Force = 15f;
    private Rigidbody rb =null;
    public Transform Orig=null;

    private bool jumping= false;
    public float jumpStrength= 5f;
    public override void Initialize(){
        rb = this.GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotationZ;
       
    }

       public override void OnActionReceived(ActionBuffers actions)
    {
        if(actions.ContinuousActions[0]== 1){
            Thrust();
        }
    
    
    }
    
    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var continiousActionsOut = actionsOut.ContinuousActions;
         if(Input.GetKey(KeyCode.UpArrow)==true){
           
           continiousActionsOut[0]=1;
        }
         
    }
    public override void OnEpisodeBegin(){
        ResetPlayer();
    }

    private void ResetPlayer(){
        this.transform.position = new Vector3(Orig.position.x, Orig.position.y,Orig.position.z);
        rb.velocity = Vector2.zero;
        rb.angularVelocity = Vector3.zero;
    }
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Block")==true){
            AddReward(-1.0f);
            
            Destroy(other.gameObject);
            EndEpisode();
        }
        if(other.gameObject.CompareTag("TopWall")==true){
            AddReward(-1.0f);
            EndEpisode();
        }
    }

    private  void OnTriggerEnter(Collider other) {
        if(other.tag=="WallReward"){
            AddReward(0.1f);
            
        }
    }
    private void Thrust(){
     
         if(rb.position.y < 1 ){
        
             rb.position = new Vector3(Orig.position.x,jumpStrength,Orig.position.z);
         }
    }
}
