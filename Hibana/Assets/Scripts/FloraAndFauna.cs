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
        GameManager.GetInstance().TreeBurned();
    }

    public void BeastKilled()
    {
        GameManager.GetInstance().BeastKilled();
    }

    public int FloraAndFaunaDestuctionIndex()
    {
        return _numberOfTreesBurned + _numberOfBeastsKilled;
    }
}
