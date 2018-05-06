using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{

	public Tile[] NextTile;

	public Tile NextTileForPlayer(int playerNumber)
	{
		if (NextTile.Length == 0)
		{
			return null;
		}
		
		// True only for Center 8 tile (last tile before split)
		if (NextTile.Length > 1)
		{
			// Player number is expected to be 1 or 2
			// `NextTile[0]` is for Player One, and `NextTile[1]` is for Player Two
			return NextTile[playerNumber - 1];
		}
		else
		{
			return NextTile[0];
		}
	}
}
