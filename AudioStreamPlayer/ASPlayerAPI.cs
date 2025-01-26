
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.InteropServices;
using static AudioStreamPlayer.MP3StreamingPanel;

namespace AudioStreamPlayer
{
	internal class ASPlayerAPI
	{
		[DllImport("kernel32")]
		public static extern int AllocConsole();

		[DllImport("kernel32")]
		public static extern bool FreeConsole();

		[DllImport("ASPlayer", EntryPoint = "Init")]
		public static extern int Init();

		[DllImport("ASPlayer", EntryPoint = "Play")]
		public static extern void Play(string url);

		[DllImport("ASPlayer", EntryPoint = "Stop")]
		public static extern void Stop();

		[DllImport("ASPlayer", EntryPoint = "Pause")]
		public static extern void Pause();

		[DllImport("ASPlayer")]
		public static extern void ChangeStation(string url);

		[DllImport("ASPlayer")]
		public static extern void PausePlay();

		//__declspec(dllexport) void Seek(INT64 pos)
		[DllImport("ASPlayer")]
		public static extern void Seek(float pos);

		[DllImport("ASPlayer")]
		public static extern void SetVolume(int volume);

		[DllImport("ASPlayer")]
		public static extern void StartRecorder(string URL);

		[DllImport("ASPlayer")]
		public static extern void StopRecorder();

		[DllImport("ASPlayer.dll")]
		public static extern long GetPosition();

		[DllImport("ASPlayer.dll")]
		public static extern VLCState Getstate(); //Playing = 3, Paused = 4, Stopped = 5

		[DllImport("ASPlayer.dll")]
		public static extern long Getduration();

		[DllImport("ASPlayer.dll")]
		public static extern void PlayFile(string filePath);


		[DllImport("ASPlayer.dll")]
		public static extern int GetMediaDuration();

		[DllImport("ASPlayer.dll")]
		public static extern float GetBufferState();

		private const string DllName = "ASPlayer.dll";

		// Delegált típus definiálása a buffer változásra
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void BufferCallback(float buffer);

		// C++ AttachBufferEvent függvény meghívása
		[DllImport(DllName)]
		public static extern void AttachBufferEvent(BufferCallback callback);


		// Esemény hozzácsatolása (pl. Form1_Load)
		public static void RegisterBufferEvent()
		{
			AttachBufferEvent(OnBufferChanged);
		}


		// Callback függvény implementálása C# oldalon
		private static void OnBufferChanged(float buffer)
		{
			//Console.WriteLine($"Buffer állapot: {buffer}%");
			BufferChanged?.Invoke(null, buffer);  // Esemény kiváltása C# oldalon
		}

		// Esemény definiálása C# oldalon
		public static event EventHandler<float> BufferChanged;



		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void PlayingCallback();

		[DllImport("ASPlayer.dll")]
		public static extern void RegisterPlayingCallback(PlayingCallback callback);

		[DllImport("ASPlayer.dll")]
		public static extern void AttachPlayingEvent();

		
	}
}
