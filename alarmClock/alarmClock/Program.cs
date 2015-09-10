using System;
using System.Media;
using System.Timers;

namespace alarmClock
{
	class MainClass
	{
		static Timer timer;

		public static void Main (string[] args)
		{
			Console.WriteLine ("How many seconds do you want me to beep?");
			string seconds = Console.ReadLine ();
			int secs;

			if (int.TryParse(seconds, out secs)) {
				secs*=1000;
				// Create a timer with a two second interval.
				timer = new System.Timers.Timer (secs);

				// Hook up the Elapsed event for the timer. 
				timer.Elapsed += OnTimedEvent;

				// Start the timer
				timer.Enabled = true;

				//Garbage Collector keep timer alive for eternity 
				GC.KeepAlive (timer);

				Console.WriteLine ("Press the Enter key to exit the program at any time... ");
				Console.ReadLine ();
			}
			else
			{

				Console.WriteLine ("Uh-Oh, enter a valid integer");
			}

		}

		private static void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
		{
			Console.Beep ();
		}
	}
}
