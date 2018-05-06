using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class DieRoller : MonoBehaviour
{
	// Sets of sprites for the respective die rolls (one or zero)
	// Each will have three possible sprites, set in the editor
	public Sprite[] DieValueOneSprites;
	public Sprite[] DieValueZeroSprites;

	private int _currentRoll = 0;
	
	public int CurrentRoll
	{
		get { return _currentRoll; }
	}
	
	private bool _diceRolled = false;
	
	public bool DiceRolled
	{
		get { return _diceRolled; }
	}

	public void TurnEnded()
	{
		_diceRolled = false;
	}

	public void RollDice()
	{	
		if (_diceRolled) return;
		
		_currentRoll = 0;
		
		// The DieRoller has four child sprite elements for the four dice being rolled
		// Here we iterate over those sprites and set them for the new die roll
		for (var i = 0; i < 4; i++)
		{
			// Assign dieValue either 0 or 1
			var dieValue = Random.Range(0, 2);
			
			_currentRoll += dieValue;
			
			// Get the appropriate set of sprites based on the die roll
			var sprites = (dieValue == 1) ? DieValueOneSprites : DieValueZeroSprites;
			
			// Get the image component for the die we're currently rolling
			var image = transform.GetChild(i).GetComponent<Image>();
			
			// Pick a sprite at random from the appropriate set, and set the image to that sprite
			image.sprite = sprites[Random.Range(0, 3)];
			
			// Before you roll, the sprites are silhouetted in black
			// To be able to see the sprite, set it's color to white
			image.color = Color.white;
		}
		
		_diceRolled = true;
	}
}
