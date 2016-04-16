using UnityEngine;
using System.Collections;

public class Opacity : MonoBehaviour {

	void Awake()
    {
        GetComponent<CanvasRenderer>().SetAlpha(0.6f);
    }
}
