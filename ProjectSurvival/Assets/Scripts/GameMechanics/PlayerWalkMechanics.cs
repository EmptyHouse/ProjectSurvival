using UnityEngine;
using System.Collections;

public class PlayerWalkMechanics : WalkMechanics {

	
	
	// Update is called once per frame
	protected override void Update () {
        setHInput(Input.GetAxis("Horizontal"));
        setVInput(Input.GetAxis("Vertical"));
        base.Update();

	}
}
