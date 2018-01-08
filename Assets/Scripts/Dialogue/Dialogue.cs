using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
	public string SpeakerName;
	[TextArea()]
	public string[] sentences;
}
