//
// System.Windows.Forms.ApplicationContext
//
// Author:
//   stubbed out by Jaak Simm (jaaksimm@firm.ee)
//	Dennis hayes (dennish@raytek.com)
//
// (C) Ximian, Inc 2002
//

namespace System.Windows.Forms {

	/// <summary>
	/// Specifies the contextual information about an application thread.
	/// </summary>

	[MonoTODO]
	public class ApplicationContext {

		Form mainForm;
		
		// --- (public) Properties ---
		public Form MainForm {
			get { return mainForm; }
			set { mainForm = value; }
		}
		
		// --- Constructor ---
		public ApplicationContext() 
		{
			mainForm = null;
		}
		
		public ApplicationContext(Form mainForm) : this() 
		{
			this.mainForm = mainForm;
		}
		
		// --- Methods ---
		[MonoTODO]
		public void Dispose() 
		{
			// see documentation on ApplicationContext.Dispose Method (Boolean)
			this.Dispose(true);
		}
		
		[MonoTODO]
		protected virtual void Dispose(bool disposing) 
		{
			
		}
		
		[MonoTODO]
		public void ExitThread() 
		{
			//FIXME:
		}
		
		[MonoTODO]
		protected virtual void ExitThreadCore() 
		{
			//FIXME:
		}
		
		[MonoTODO]
		protected virtual void OnMainFormClosed(object sender,EventArgs e) 
		{
			//FIXME:
		}
		
		// --- Methods: object ---
		[MonoTODO]
		~ApplicationContext() {
			// see documentation on ApplicationContext.Dispose Method (Boolean)
			this.Dispose(false);
		}
		
		// --- Events ---
		public event EventHandler ThreadExit;
	}
}
