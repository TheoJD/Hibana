using UnityEngine;
using System.Collections;

public class FloraAndFauna : MonoBehaviour {
    public int _numberOfTreesBurned = 0;
    public int _numberOfBeastsKilled = 0;
	
    public void TreeBurned()
    {
        ++_numberOfTreesBurned;
        Debug.Log("Tree burned " + _numberOfTreesBurned);
    }

    public void BeastKilled()
    {
        ++_numberOfBeastsKilled;
        Debug.Log("Beast Killed " + _numberOfBeastsKilled);
    }

    public int FloraAndFaunaDestuctionIndex()
    {
        return _numberOfTreesBurned + _numberOfBeastsKilled;
    }
}
