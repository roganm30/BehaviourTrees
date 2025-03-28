using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class RechargeAT : ActionTask {

		public BBParameter<float> speed;
		public float maxEnergy = 100f;
		public float chargeRate;

		private Blackboard agentBlackboard;

		public MeshRenderer characterRenderer;
		public Color outOfChargeColour;
		public Color chargingColour;
		public Color fullyChargedColour;

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

			speed.value = 0f;
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {

			float currentEnergy = agentBlackboard.GetVariableValue<float>("energy");

			if (currentEnergy <= maxEnergy)
            {
				characterRenderer.material.color = outOfChargeColour;

				currentEnergy += chargeRate * Time.deltaTime;

				agentBlackboard.SetVariableValue("energy", currentEnergy);

				if (currentEnergy >= 35f)
                {
					characterRenderer.material.color = chargingColour;
				}

				if (currentEnergy >= maxEnergy)
                {
					characterRenderer.material.color = fullyChargedColour;

					EndAction(true);
                }
			}

		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}