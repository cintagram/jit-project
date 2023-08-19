using UnityEngine;

namespace KartGame.KartSystems {

    public class KeyboardInput : BaseInput
    {
        public string TurnInputName = "Horizontal";
        public string AccelerateButtonName = "Accelerate";
        public string BrakeButtonName = "Brake";

        public Transform orientation;
        public float trigger_value = 30f;

        public override InputData GenerateInput() {
            int turnInput;
            float local_rotation = orientation.rotation.eulerAngles.y - transform.rotation.eulerAngles.y;
            //local_rotation *= 180f;
            if (local_rotation > 180f)
                local_rotation -= 360f;
            else if (local_rotation < -180f)
                local_rotation += 360f;


            if(local_rotation > trigger_value) 
                turnInput = 1;
            else if(local_rotation < -trigger_value)
                turnInput = -1;
            else
                turnInput = 0;

            return new InputData
            {
                Accelerate = true,
                //Accelerate = Input.GetButton(AccelerateButtonName),
                Brake = Input.GetButton(BrakeButtonName),
                TurnInput = turnInput
                //TurnInput = Input.GetAxis("Horizontal")
            };
        }
    }
}
