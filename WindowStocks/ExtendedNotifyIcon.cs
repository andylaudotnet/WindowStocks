//-----------------------------------------------------------------------------------------
// Author:   Murray Foxcroft - April 2009
//-----------------------------------------------------------------------------------------
using System;
using System.Windows.Forms;
using System.Drawing;

namespace WindowStocks
{
	/// <summary>
	/// An extension of the notifyIcon Windows Forms class, unfortunately its a 
	//  sealed class so it cannot be inherited. This class adds a timer and additional 
	//  methods and events to allow for monitoring when a mouse enters and leaves the icon area. 
	/// </summary>
	/// 
	public class ExtendedNotifyIcon : IDisposable
	{
		#region Fields (4) 

		/// <summary>
		/// Standard IDisposable interface implementation. If you dont dispose the windows notify icon, the application
		/// closes but the icon remains in the task bar until such time as you mouse over it.
		/// </summary>
		private bool _IsDisposed = false;
		private Timer delayMouseLeaveEventTimer;
		private Point notifyIconMousePosition;
		public NotifyIcon targetNotifyIcon;

		#endregion Fields 

		#region Constructors (2) 

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="millisecondsToDelayMouseLeaveEvent"></param>
		public ExtendedNotifyIcon(NotifyIcon notifyIcon, int millisecondsToDelayMouseLeaveEvent)
		{
			// Configure and show a notification icon in the system tray
			targetNotifyIcon = notifyIcon;
			targetNotifyIcon.Visible = true;
			targetNotifyIcon.MouseMove += new MouseEventHandler(targetNotifyIcon_MouseMove);

			delayMouseLeaveEventTimer = new Timer();
			delayMouseLeaveEventTimer.Tick += new EventHandler(delayMouseLeaveEventTimer_Tick);
			delayMouseLeaveEventTimer.Interval = 100;
		}

		~ExtendedNotifyIcon()
		{
			Dispose(false);
		}

		#endregion Constructors 

		#region Delegates and Events (4) 

		// Delegates (2) 

		public delegate void MouseLeaveHandler();
		public delegate void MouseMoveHandler();
		// Events (2) 

		public event MouseLeaveHandler MouseLeave;

		public event MouseMoveHandler MouseMove;

		#endregion Delegates and Events 

		#region Methods (6) 

		// Public Methods (4) 

		public void Dispose()
		{
			Dispose(true);
			// Tell the garbage collector not to call the finalizer
			// since all the cleanup will already be done.
			GC.SuppressFinalize(true);
		}

		/// <summary>
		/// Manual override exposed - START the timer which will ultimately trigger the mouse leave event
		/// </summary>
		public void StartMouseLeaveTimer()
		{
			delayMouseLeaveEventTimer.Start();
		}

		/// <summary>
		/// Manual override exposed - STOP the timer that would ultimately close the window
		/// </summary>
		public void StopMouseLeaveEventFromFiring()
		{
			delayMouseLeaveEventTimer.Stop();
		}

		/// <summary>
		/// If the mouse is moving over the notify icon, the popup must be displayed.     
		/// Note: There is no event on the notify icon to trap when the mouse leave, so a timer is used in conjunction 
		/// with tracking the position of the mouse to test for when the popup window needs to be closed. See timer tick event.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void targetNotifyIcon_MouseMove(object sender, MouseEventArgs e)
		{
			notifyIconMousePosition = Control.MousePosition; // Track the position of the mouse over the notify icon
			MouseMove(); // The mouse is moving over the notify Icon, raise the event
			delayMouseLeaveEventTimer.Start();  // The timer counts down and closes the window, as the mouse moves over the icon, keep starting (resetting) this to stop it from closing the popup
		}
		// Protected Methods (1) 

		protected virtual void Dispose(bool IsDisposing)
		{
			if (_IsDisposed)
				return;

			if (IsDisposing) {
				targetNotifyIcon.Dispose();
			}

			// Free any unmanaged resources in this section
			_IsDisposed = true;

		}
		// Private Methods (1) 

		/// <summary>
		/// Under the right conditions, raise the event to the popup window to tell it to close.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void delayMouseLeaveEventTimer_Tick(object sender, EventArgs e)
		{
			// If the mouse position over the icon does not match the sryceen position, the mouse has left the icon (think of this as a type of hit test) 
			if (notifyIconMousePosition != System.Windows.Forms.Control.MousePosition) {
				MouseLeave();  // Raise the event for the mouse leaving 
				delayMouseLeaveEventTimer.Stop(); // Stop the timer, no longer reqired.
			}
		}

		#endregion Methods 
	}
}
