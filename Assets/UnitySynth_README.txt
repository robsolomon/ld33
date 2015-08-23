Original source came from http://forum.unity3d.com/threads/unitysynth-full-xplatform-midi-synth.130104/

To use:

0) Add a .TXT extension to any MIDI files you wish to use, import to Audio/MIDI (or any folder of your choice).
1) Attach the UnityMIDISynth.cs file to a new GameObject.
2) Drag the MIDI.TXT file from the Project pane to the "Midi File" field in UnityMIDISynth.
3a) Check PlayOnAwake if you want the file to automatically start playing.
3b) To control Play() and Stop() behavior, grab a reference to UnityMIDISynth and call PlayMIDI() or StopMIDI() respectively.

The example scene shows Play() and Stop() being controlled by the new UI buttons (select Canvas->Panel->X Button, scroll to the bottom of the Inspector to see the OnClick() method).