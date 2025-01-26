using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AudioStreamPlayer
{
	public class MyTimer : IComponent
	{

		[DllImport("winmm.dll")]
		private static extern int timeGetDevCaps(ref TimerCaps caps, int sizeOfTimerCaps);

		[DllImport("winmm.dll")]
		private static extern int timeSetEvent(int delay, int resolution, TimeProc proc, int user, int mode);

		[DllImport("winmm.dll")]
		private static extern int timeKillEvent(int id);

		private const int TIMERR_NOERROR = 0;


		static MyTimer()
		{
			timeGetDevCaps(ref capabilities_, Marshal.SizeOf(capabilities_));
		}
		public MyTimer() { Initialize(); }

		public MyTimer(IContainer container)
		{
			container.Add(this);
			Initialize();

		}
		private void Initialize()
		{
			this.mode_ = TimerMode.Periodic;
			this.period_ = Capabilities.periodMin;
			this.resolution_ = 1;

			running_ = false;

			timeProcPeriodic = new TimeProc(TimerPeriodicEventCallback);
			timeProcOneShot = new TimeProc(TimerOneShotEventCallback);
			startedRaiser = new EventRaiser(OnStarted);
			stoppedRaiser = new EventRaiser(OnStopped);
			tickRaiser = new EventRaiser(OnTick);
		}

		~MyTimer()
		{
			if (running_)
			{
				timeKillEvent(timerID);
			}
		}

		private void TimerPeriodicEventCallback(int id, int msg, int user, int param1, int param2)
		{
			if (synchronizingObject_ != null)
			{
				synchronizingObject_.BeginInvoke(tickRaiser, new object[] { EventArgs.Empty });
			}
			else
			{
				OnTick(EventArgs.Empty);
			}
		}
		private void TimerOneShotEventCallback(int id, int msg, int user, int param1, int param2)
		{
			if (synchronizingObject_ != null)
			{
				synchronizingObject_.BeginInvoke(tickRaiser, new object[] { EventArgs.Empty });
				Stop();
			}
			else
			{
				OnTick(EventArgs.Empty);
				Stop();
			}
		}

		private ISynchronizeInvoke synchronizingObject_ = null;
		private static TimerCaps capabilities_;
		private volatile int period_;
		private volatile int resolution_;
		private volatile TimerMode mode_;
		private bool running_ = false;

		private delegate void TimeProc(int id, int msg, int user, int param1, int param2);
		private TimeProc timeProcPeriodic, timeProcOneShot;
		private int timerID;

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public static TimerCaps Capabilities
		{
			get { return capabilities_; }
		}

		public bool IsRunning
		{
			get { return running_; }
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public TimerMode Mode
		{
			get
			{
				if (disposed_) { throw new ObjectDisposedException("Timer"); }
				return mode_;
			}
			set
			{
				if (disposed_) { throw new ObjectDisposedException("Timer"); }
				mode_ = value;
				if (running_)
				{
					Stop();
					Start();
				}
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public int Interval
		{
			get
			{
				if (disposed_) { throw new ObjectDisposedException("Timer"); }
				return period_;
			}
			set
			{
				if (disposed_)
				{
					throw new ObjectDisposedException("Timer");
				}
				else if (value < capabilities_.periodMin || value > capabilities_.periodMax)
				{
					throw new ArgumentOutOfRangeException("Period", value, "Multimedia Timer period out of range.");
				}

				period_ = value;
				if (running_)
				{
					Stop();
					Start();
				}
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public ISynchronizeInvoke SynchronizingObject
		{
			get
			{
				if (disposed_) { throw new ObjectDisposedException("Timer"); }
				return synchronizingObject_;
			}
			set
			{
				if (disposed_) { throw new ObjectDisposedException("Timer"); }
				synchronizingObject_ = value;
			}
		}

		public void Start()
		{
			if (disposed_) { throw new ObjectDisposedException("Timer"); }
			if (running_) { return; }
			bool errorStart = false;
			if (Mode == TimerMode.Periodic)
			{
				timerID = timeSetEvent(Interval, 1, timeProcPeriodic, 0, (int)Mode);
			}
			else
			{
				timerID = timeSetEvent(Interval, 1, timeProcOneShot, 0, (int)Mode);
			}
			errorStart = (timerID == 0);
			if (errorStart) throw new TimerStartException("A timer indítása nem sikerült.");
			else
			{
				running_ = true;
				if (SynchronizingObject != null && SynchronizingObject.InvokeRequired)
				{
					SynchronizingObject.BeginInvoke(startedRaiser, new object[] { EventArgs.Empty });
				}
				else
				{
					OnStarted(EventArgs.Empty);
				}
			}
		}
		public void Stop()
		{
			if (disposed_) { throw new ObjectDisposedException("Timer"); }
			if (!running_) { return; }
			int result = timeKillEvent(timerID);
			running_ = false;
			if (SynchronizingObject != null && SynchronizingObject.InvokeRequired) SynchronizingObject.BeginInvoke(stoppedRaiser, new object[] { EventArgs.Empty });
			else OnStopped(EventArgs.Empty);
		}

		public event EventHandler Started;
		public event EventHandler Stopped;
		public event EventHandler Tick;
		private delegate void EventRaiser(EventArgs e);

		private EventRaiser startedRaiser;
		private EventRaiser stoppedRaiser;
		private EventRaiser tickRaiser;

		private void OnStarted(EventArgs e)
		{
			EventHandler handler = Started;
			if (handler != null) { handler(this, e); }
		}
		private void OnStopped(EventArgs e)
		{
			EventHandler handler = Stopped;
			if (handler != null) { handler(this, e); }
		}
		private void OnTick(EventArgs e)
		{
			EventHandler handler = Tick;
			if (handler != null) { handler(this, e); }
		}

		private ISite site_ = null;

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public ISite Site
		{
			get { return site_; }
			set { site_ = value; }
		}

		public event System.EventHandler Disposed;
		private volatile bool disposed_ = false;
		public void Dispose()
		{
			if (disposed_) { return; }
			if (running_) { Stop(); }
			disposed_ = true;
			OnDisposed(EventArgs.Empty);
			GC.SuppressFinalize(this);
		}
		private void OnDisposed(EventArgs e)
		{
			EventHandler handler = Disposed;
			if (handler != null) { handler(this, e); }
		}

		public class TimerStartException : ApplicationException
		{
			public TimerStartException(string message)
			  : base(message)
			{
			}
		}

		public enum TimerMode
		{
			OneShot,
			Periodic
		};


		[StructLayout(LayoutKind.Sequential)]
		public struct TimerCaps
		{
			public int periodMin;
			public int periodMax;
		}
	}
}
