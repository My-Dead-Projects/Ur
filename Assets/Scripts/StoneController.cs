using UnityEngine;

public class StoneController : MonoBehaviour
{
	private DieRoller _dieRoller;
	
	void Start ()
	{
		_dieRoller = GameObject.FindObjectOfType<DieRoller>();
	}

	void OnMouseUp()
	{
		// TODO: Check if it is our turn
		
		// Don't allow clicks until the turn starts
		if (!_dieRoller.DiceRolled) return;
		
	}
}
