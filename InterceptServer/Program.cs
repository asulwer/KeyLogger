using System;
using System.Configuration;
using System.IO;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Windows.Forms;

class InterceptServer
{
    private static Intercept.Intercept.LowLevelKeyboardProc _keyboardProc = Intercept.Intercept.KeyboardHookCallback;
    private static Intercept.Intercept.LowLevelMouseProc _mouseProc = Intercept.Intercept.MouseHookCallback;
    private static IntPtr _keyboardHookID = IntPtr.Zero;
    private static IntPtr _mouseHookID = IntPtr.Zero;
    
    [ServiceContract]
    public interface IInterceptService
    {
        [OperationContract]
        string StartKeyboard(string file);
        [OperationContract]
        string StartMouse(string file);
        [OperationContract]
        string StopKeyboard();
        [OperationContract]
        string StopMouse();
        [OperationContract]
        byte[] GetFile(string file, int position);
    }
    public class InterceptService : IInterceptService
    {
        public string StartKeyboard(string file)
        {
            string result = "Success";
            try
            {
                Intercept.Intercept.KeyboardStream = new FileStream(file, FileMode.Append, FileAccess.Write, FileShare.None);
            }
            catch(Exception ex)
            {
                result = ex.ToString();
            }
            return result;
        }
        public string StartMouse(string file)
        {
            string result = "Success";
            try
            {
                Intercept.Intercept.MouseStream = new FileStream(file, FileMode.Append, FileAccess.Write, FileShare.None);
            }
            catch(Exception ex)
            {
                result = ex.ToString();
            }
            return result;
        }
        public string StopKeyboard()
        {
            string result = "Success";
            try
            {
                Intercept.Intercept.KeyboardStream.Close();
            }
            catch (Exception ex)
            {
                result = ex.ToString();
            }
            return result;
        }
        public string StopMouse()
        {
            string result = "Success";
            try
            {
                Intercept.Intercept.MouseStream.Close();
            }
            catch (Exception ex)
            {
                result = ex.ToString();
            }
            return result;
        }
        public byte[] GetFile(string file, int position)
        {
            byte[] buffer = null;

            if(File.Exists(file))
            {
                try
                {
                    using (Stream s = new FileStream(file, FileMode.Open, FileAccess.Read))
                    {
                        s.Position = position;
                        int offset = (int)(s.Length - s.Position);

                        if (offset < 1024)
                        {
                            buffer = new byte[offset];
                            s.Read(buffer, 0, offset);
                        }
                        else
                        {
                            buffer = new byte[1024];
                            s.Read(buffer, 0, 1024);
                        }
                    }
                }
                catch(Exception)
                {
                    buffer = null;
                }
            }

            return buffer;
        }
    }

    public static void Main()
    {
        Uri baseAddress = new Uri(ConfigurationManager.AppSettings["EndPoint"].ToString());

        using (ServiceHost sh = new ServiceHost(typeof(InterceptService), baseAddress))
        {
            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
            sh.Description.Behaviors.Add(smb);
            
            _keyboardHookID = Intercept.Intercept.SetKeyboardHook(_keyboardProc);
            _mouseHookID = Intercept.Intercept.SetMouseHook(_mouseProc);

            sh.Open();
            Application.Run();
            sh.Close();

            Intercept.Intercept.UnhookWindowsHookEx(_keyboardHookID);
            Intercept.Intercept.UnhookWindowsHookEx(_mouseHookID);            
        }
    }
}