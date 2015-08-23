using UnityEngine;
using System.Collections;

[RequireComponent(typeof(UnityMIDISynth))]
public class UnityMIDIKeyboard : MonoBehaviour {

	public enum Octave
	{
		C0,
		C1,
		C2,
		C3,
		C4,
		C5,
		C6,
		C7,
		C8 
	}

	UnityMIDISynth midiModule;
	
	public Octave octave = Octave.C4;

	[Range(0, 127)]
	public int midiNoteVolume = 127;

	[Range(0, 127)]
	public int midiInstrument = 1;

	private int midiNote;
	private Octave lastOctave;

	// Use this for initialization
	void Awake () {
		midiModule = GetComponent<UnityMIDISynth>();
		midiNote = GetCurrentMidiNote(octave);
		lastOctave = octave;
	}
	
	// Update is called once per frame
	void Update () {
		if (octave != lastOctave)
		{
			midiNote = GetCurrentMidiNote(octave);
			lastOctave = octave;
		}

		CheckKeyboardInput();

	}

	void CheckKeyboardInput () {
		//Demo of direct note output
		if (Input.GetKeyDown(KeyCode.A))
			midiModule.NoteOn (1, midiNote, midiNoteVolume, midiInstrument);
		if (Input.GetKeyUp(KeyCode.A))
			midiModule.NoteOff (1, midiNote);
		if (Input.GetKeyDown(KeyCode.W))
			midiModule.NoteOn (1, midiNote + 1, midiNoteVolume, midiInstrument);
		if (Input.GetKeyUp(KeyCode.W))
			midiModule.NoteOff (1, midiNote + 1);
		if (Input.GetKeyDown(KeyCode.S))
			midiModule.NoteOn (1, midiNote + 2, midiNoteVolume, midiInstrument);
		if (Input.GetKeyUp(KeyCode.S))
			midiModule.NoteOff (1, midiNote + 2);		
		if (Input.GetKeyDown(KeyCode.E))
			midiModule.NoteOn (1, midiNote + 3, midiNoteVolume, midiInstrument);
		if (Input.GetKeyUp(KeyCode.E))
			midiModule.NoteOff (1, midiNote + 3);
		if (Input.GetKeyDown(KeyCode.D))
			midiModule.NoteOn (1, midiNote + 4, midiNoteVolume, midiInstrument);
		if (Input.GetKeyUp(KeyCode.D))
			midiModule.NoteOff (1, midiNote + 4);
		if (Input.GetKeyDown(KeyCode.F))
			midiModule.NoteOn (1, midiNote + 5, midiNoteVolume, midiInstrument);
		if (Input.GetKeyUp(KeyCode.F))
			midiModule.NoteOff (1, midiNote + 5);
		if (Input.GetKeyDown(KeyCode.T))
			midiModule.NoteOn (1, midiNote + 6, midiNoteVolume, midiInstrument);
		if (Input.GetKeyUp(KeyCode.T))
			midiModule.NoteOff (1, midiNote + 6);
		if (Input.GetKeyDown(KeyCode.G))
			midiModule.NoteOn (1, midiNote + 7, midiNoteVolume, midiInstrument);
		if (Input.GetKeyUp(KeyCode.G))
			midiModule.NoteOff (1, midiNote + 7);		
		if (Input.GetKeyDown(KeyCode.Y))
			midiModule.NoteOn (1, midiNote + 8, midiNoteVolume, midiInstrument);
		if (Input.GetKeyUp(KeyCode.Y))
			midiModule.NoteOff (1, midiNote + 8);
		if (Input.GetKeyDown(KeyCode.H))
			midiModule.NoteOn (1, midiNote + 9, midiNoteVolume, midiInstrument);
		if (Input.GetKeyUp(KeyCode.H))
			midiModule.NoteOff (1, midiNote + 9);
		if (Input.GetKeyDown(KeyCode.U))
			midiModule.NoteOn (1, midiNote + 10, midiNoteVolume, midiInstrument);
		if (Input.GetKeyUp(KeyCode.U))
			midiModule.NoteOff (1, midiNote + 10);
		if (Input.GetKeyDown(KeyCode.J))
			midiModule.NoteOn (1, midiNote + 11, midiNoteVolume, midiInstrument);
		if (Input.GetKeyUp(KeyCode.J))
			midiModule.NoteOff (1, midiNote + 11);		
		if (Input.GetKeyDown(KeyCode.K))
			midiModule.NoteOn (1, midiNote + 12, midiNoteVolume, midiInstrument);
		if (Input.GetKeyUp(KeyCode.K))
			midiModule.NoteOff (1, midiNote + 12);
		if (Input.GetKeyDown(KeyCode.O))
			midiModule.NoteOn (1, midiNote + 13, midiNoteVolume, midiInstrument);
		if (Input.GetKeyUp(KeyCode.O))
			midiModule.NoteOff (1, midiNote + 13);
		if (Input.GetKeyDown(KeyCode.L))
			midiModule.NoteOn (1, midiNote + 14, midiNoteVolume, midiInstrument);
		if (Input.GetKeyUp(KeyCode.L))
			midiModule.NoteOff (1, midiNote + 14);
		if (Input.GetKeyDown(KeyCode.P))
			midiModule.NoteOn (1, midiNote + 15, midiNoteVolume, midiInstrument);
		if (Input.GetKeyUp(KeyCode.P))
			midiModule.NoteOff (1, midiNote + 15);
		if (Input.GetKeyDown(KeyCode.Semicolon))
			midiModule.NoteOn (1, midiNote + 16, midiNoteVolume, midiInstrument);
		if (Input.GetKeyUp(KeyCode.Semicolon))
			midiModule.NoteOff (1, midiNote + 16);

		if (Input.GetKeyDown (KeyCode.Z))
			OctaveDown ();
		if (Input.GetKeyDown (KeyCode.X))
			OctaveUp ();
	}

	void OctaveUp()
	{
		int currentOctave = (int)octave;
		currentOctave++;
		if (currentOctave > 8)
			octave = (Octave)8;
		else
			octave = (Octave)currentOctave;
	}

	void OctaveDown()
	{
		int currentOctave = (int)octave;
		currentOctave--;
		if (currentOctave < 0)
			octave = (Octave)0;
		else
			octave = (Octave)currentOctave;
	}

	int GetCurrentMidiNote(Octave octave)
	{
		return 12 + ((int)octave * 12);
	}
}
