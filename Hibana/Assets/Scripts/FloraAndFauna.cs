using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FloraAndFauna : MonoBehaviour {
    public int _numberOfTreesBurned = 0;
    public int _numberOfBeastsKilled = 0;
    public Text _treeText;
    public Text _beastText;
    public void TreeBurned()
    {
        ++_numberOfTreesBurned;
        _treeText.text = _numberOfTreesBurned.ToString();
//        Debug.Log("Tree burned " + _numberOfTreesBurned);
    }

    public void BeastKilled()
    {
        ++_numberOfBeastsKilled;
        _beastText.text = _numberOfBeastsKilled.ToString();
//        Debug.Log("Beast Killed " + _numberOfBeastsKilled);
    }

    public int FloraAndFaunaDestuctionIndex()
    {
        return _numberOfTreesBurned + _numberOfBeastsKilled;
    }
}
