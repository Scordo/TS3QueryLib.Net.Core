namespace TS3QueryLib.Net.Core.Server.Entitities
{
    public enum HostMessageMode
    {
        /// <summary>
        /// dont display anything
        /// </summary>
        HostMessageModeNone = 0,
        /// <summary>
        /// display message in chatlog
        /// </summary>
        HostMessageModeLog = 1,
        /// <summary>
        /// display message in modal dialog
        /// </summary>
        HostMessageModeModal = 2,
        /// <summary>
        /// display message in modal dialog and close connection
        /// </summary>
        HostMessageModeModalQuit = 3    
    }
}