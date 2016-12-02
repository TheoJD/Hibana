using UnityEngine;
using System.Collections;

public class AlternativeEndings : MonoBehaviour {
    enum State {GOOD, HALF, BAD };
    [TextArea(2, 10)]
    public string _faunaGoodEnding;
    [TextArea(2, 10)]
    public string _faunaHalfGoodEnding;
    [TextArea(2, 10)]
    public string _floraGoodEnding;
    [TextArea(2, 10)]
    public string _floraHalfGoodEnding;
    [TextArea(2, 10)]
    public string _goodEnding;
    [TextArea(2, 10)]
    public string _goodBadEnding;
    [TextArea(2, 10)]
    public string _badGoodEnding;
    [TextArea(2, 10)]
    public string _halfEnding;
    private State _faunaState = State.BAD;
    private State _floraState = State.BAD;
    //private State _globalState = State.BAD;
    private TextController _textController;
    // Use this for initialization
    void Start () {
        _textController = GetComponent<TextController>();
        float beastRatio = GameManager.GetInstance().BeastsRatio();
        float treeRatio = GameManager.GetInstance().TreesRatio();

        if (beastRatio == 0)
        {
            _faunaState = State.GOOD;
            _textController.ChangeParagraph(1, _faunaGoodEnding);
        }
        else if (beastRatio < 0.5)
        {
            _faunaState = State.HALF;
            _textController.ChangeParagraph(1, _faunaHalfGoodEnding);
        }

        if (treeRatio == 0)
        {
            _floraState = State.GOOD;
            _textController.ChangeParagraph(2, _floraGoodEnding);
        }
        else if (treeRatio < 0.5)
        {
            _floraState = State.HALF;
            _textController.ChangeParagraph(2, _floraHalfGoodEnding);
        }

        if (_floraState == State.GOOD &&_faunaState == State.GOOD)
        {
                _textController.ChangeParagraph(3, _goodEnding);
        }
        else if (_floraState == State.BAD && _faunaState != State.BAD)
        {
            _textController.ChangeParagraph(3, _goodBadEnding);
        }
        else if (_floraState != State.BAD && _faunaState == State.BAD)
        {
            _textController.ChangeParagraph(3, _badGoodEnding);
        }
        else if (_floraState == State.HALF || _faunaState == State.HALF)
        {
            _textController.ChangeParagraph(3, _halfEnding);
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
