using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class MoveToTargetAT : ActionTask {

		public BBParameter<Transform> currentTarget;
		public BBParameter<float> speed;
		public float energyRate;

		private Blackboard agentBlackboard;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			agentBlackboard = agent.GetComponent<Blackboard>();

			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {

			float currentEnergy = agentBlackboard.GetVariableValue<float>("energy");

			if (currentEnergy >= 90f)
            {
				speed.value = 20f;
            }

			if (currentEnergy <= 90f && currentEnergy >= 75f)
			{
				speed.value = 16f;
            }

			else
            {
				speed.value = 12f;
            }

			if (currentEnergy <= 10f)
            {
				speed.value = 6f;
            }
									// rather than using in OnUpdate, this allows for easier interruptions
									// move a little bit, check for detection, move a little bit, check-- and so on

			Vector3 directionToMove = (currentTarget.value.position - agent.transform.position);

			agent.transform.position += directionToMove.normalized * speed.value * Time.deltaTime;

			if (currentEnergy >= 0f)
            {
				currentEnergy -= energyRate * Time.deltaTime;
            }

			agentBlackboard.SetVariableValue("energy", currentEnergy);

			EndAction(true);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {


		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}