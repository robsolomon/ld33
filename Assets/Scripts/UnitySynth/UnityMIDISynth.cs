using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using CSharpSynth.Effects;
using CSharpSynth.Sequencer;
using CSharpSynth.Synthesis;
using CSharpSynth.Midi;

[RequireComponent (typeof(AudioSource))]
public class UnityMIDISynth : MonoBehaviour
{
	public enum BankType
	{
		GeneralMidi,
		FMSynthesis,
		AnalogSynthesis
	}

	//Public
	//MIDI File must have the .TXT suffix added for Unity to be able to load it.
	//Do this before file import.
	public TextAsset midiFile;

	//Change this variable to alter the sound output (cannot be changed after Awake() currently)
	public BankType bankFileType = BankType.GeneralMidi;	// uses GetBankFilePath(bank) to pass in path in Awake()

	public bool playOnAwake = false;

	//Private 
	//public int bufferSize = 1024;
	private int bufferSize = 1024;

	private float[] sampleBuffer;
	private float gain = 1f;
	private MidiSequencer midiSequencer;
	private StreamSynthesizer midiStreamSynthesizer;
	private bool debugLogMIDINoteEvents = false;

	private string testMidiFilePath = "UnitySynth/MIDI/CheeseBurgerInParadise.mid";

	// Awake is called when the script instance
	// is being loaded.
	void Awake ()
	{
		midiStreamSynthesizer = new StreamSynthesizer (44100, 2, bufferSize, 40);
		sampleBuffer = new float[midiStreamSynthesizer.BufferSize];		
		
		midiStreamSynthesizer.LoadBank (GetBankFilePath(bankFileType));
		
		midiSequencer = new MidiSequencer (midiStreamSynthesizer);
		if (midiFile != null)
			midiSequencer.LoadMidi (midiFile, false);
		else
			midiSequencer.LoadMidi (testMidiFilePath, false);
		//These will be fired by the midiSequencer when a song plays. Check the console for messages
		midiSequencer.NoteOnEvent += new MidiSequencer.NoteOnEventHandler (MidiNoteOnHandler);
		midiSequencer.NoteOffEvent += new MidiSequencer.NoteOffEventHandler (MidiNoteOffHandler);	

		if (playOnAwake)
			PlayMIDI();
	}
	
	// Start is called just before any of the
	// Update methods is called the first time.
	void Start ()
	{
		
	}
	
	// Update is called every frame, if the
	// MonoBehaviour is enabled.
	void Update ()
	{
		
	}

	public void NoteOn(int channel, int note, int velocity, int program)
	{
		midiStreamSynthesizer.NoteOn(channel, note, velocity, program);
	}

	public void NoteOff(int channel, int note)
	{
		midiStreamSynthesizer.NoteOff (channel, note);
	}
	
	public void PlayMIDI()
	{
		midiSequencer.Play ();
	}
	
	public void StopMIDI()
	{
		midiSequencer.Stop (true);
	}
	
	// This function is called when the object
	// becomes enabled and active.
	void OnEnable ()
	{
		
	}
	
	// This function is called when the behaviour
	// becomes disabled () or inactive.
	void OnDisable ()
	{
		
	}
	
	// Reset to default values.
	void Reset ()
	{
		
	}
	
	// See http://unity3d.com/support/documentation/ScriptReference/MonoBehaviour.OnAudioFilterRead.html for reference code
	//	If OnAudioFilterRead is implemented, Unity will insert a custom filter into the audio DSP chain.
	//
	//	The filter is inserted in the same order as the MonoBehaviour script is shown in the inspector. 	
	//	OnAudioFilterRead is called everytime a chunk of audio is routed thru the filter (this happens frequently, every ~20ms depending on the samplerate and platform). 
	//	The audio data is an array of floats ranging from [-1.0f;1.0f] and contains audio from the previous filter in the chain or the AudioClip on the AudioSource. 
	//	If this is the first filter in the chain and a clip isn't attached to the audio source this filter will be 'played'. 
	//	That way you can use the filter as the audio clip, procedurally generating audio.
	//
	//	If OnAudioFilterRead is implemented a VU meter will show up in the inspector showing the outgoing samples level. 
	//	The process time of the filter is also measured and the spent milliseconds will show up next to the VU Meter 
	//	(it turns red if the filter is taking up too much time, so the mixer will starv audio data). 
	//	Also note, that OnAudioFilterRead is called on a different thread from the main thread (namely the audio thread) 
	//	so calling into many Unity functions from this function is not allowed ( a warning will show up ). 	
	private void OnAudioFilterRead (float[] data, int channels)
	{
		
		//This uses the Unity specific float method we added to get the buffer
		midiStreamSynthesizer.GetNext (sampleBuffer);
		
		for (int i = 0; i < data.Length; i++) {
			data [i] = sampleBuffer [i] * gain;
		}
	}
	/// <summary>
	/// Fetch the path in Resources to the three different sound banks for loading from the SoundBankType.
	/// </summary>
	/// <returns>Path to the Sound Bank.</returns>
	/// <param name="bankType">Type of sound bank to load.</param>
	string GetBankFilePath(BankType bankType)
	{
		string resourceBankPath = @"UnitySynth/SoundBank/";
		string gmBankPath = resourceBankPath + @"GM/gm";
		string fmBankPath = resourceBankPath + @"FM/fm";
		string analogBankPath = resourceBankPath + @"Analog/analog";
		switch (bankType)
		{
		case BankType.GeneralMidi:
			return gmBankPath;
		case BankType.FMSynthesis:
			return fmBankPath;
		case BankType.AnalogSynthesis:
			return analogBankPath;
		default:
			Debug.LogWarning ("BankType " + bankType.ToString() + " not found. Using General MIDI.");
			return gmBankPath;
		}
	}
	
	public void MidiNoteOnHandler (int channel, int note, int velocity)
	{
		if (debugLogMIDINoteEvents)
			Debug.Log ("NoteOn: " + note.ToString () + " Velocity: " + velocity.ToString ());
	}
	
	public void MidiNoteOffHandler (int channel, int note)
	{
		if (debugLogMIDINoteEvents)
			Debug.Log ("NoteOff: " + note.ToString ());
	}
	
	
}
