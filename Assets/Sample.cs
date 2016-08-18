using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Sample : MonoBehaviour {

	public GameObject Icon;
	public Transform Content;

	private int _height = 60; //Iconの大きさ＋余白の長さ
	private int _brforeIndex = 1 ; //見えない部分をどこまで表示するか
	private int _afterIndex = 9; //上から何列目まで表示するか


	// Use this for initialization
	void Start () {
		int _RandNum = Random.Range(100, 1000); 

		//ONにする
		GridLayoutGroup LayoutGroup = Content.GetComponent<GridLayoutGroup>();
		LayoutGroup.enabled = true;


		for (int i=0; i<_RandNum; i++)
		{
			GameObject _Icon =  GameObject.Instantiate (Icon);
			_Icon.gameObject.SetActive( true );
			_Icon.transform.SetParent (Content, false);

		}
		//サイズ
		RectTransform RectTrans = Content.GetComponent<RectTransform>();
		RectTrans.sizeDelta = new Vector2(0, _height * (int)( _RandNum /3 + 1));

		StartCoroutine("_OffLayout");
	
	}
	
	// Update is called once per frame
	void Update () {
		_UpdateList();
	}

	private IEnumerator _OffLayout()
	{
		yield return null;
		GridLayoutGroup LayoutGroup = Content.GetComponent<GridLayoutGroup>();
		LayoutGroup.enabled = false;

	}
	private void _UpdateList()
	{
		GridLayoutGroup LayoutGroup = Content.GetComponent<GridLayoutGroup>();
		if (LayoutGroup.enabled == false){
			float _position_y = Content.localPosition.y ;
			int _index = (int)(_position_y / _height ) - _brforeIndex;
			if (_index < 0) _index = 0;
			int i = 0;
			foreach (Transform _Icon in Content)
			{
				if (_index  * 3 <= i && i <= (_index + _afterIndex) * 3){
					_Icon.gameObject.SetActive( true );
				} else {
					_Icon.gameObject.SetActive( false );
				}
				i++;
			}
		}
	}
}
