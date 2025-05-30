using System;
using System.Runtime.InteropServices; // Para getSystem()
using System.Text;
using System.Diagnostics; // Para ejecutar comandos


/*
mcs -out:SystemUtil.exe SystemUtil.cs
mono SystemUtil.exe 
*/
namespace MetodosMultiUso.Core
{

    public static class SystemUtil {
        /// <summary>
        /// Devuelve un string que indica el Sistema Operativo usado.
        /// </summary>
        /// <returns>string</returns>
        public static string getSystem() {
            string os = "other";
            if ( RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ) {
                os = "win";
            }
            else if ( RuntimeInformation.IsOSPlatform(OSPlatform.Linux) ) {
                os = "linux";
            }
            else if ( RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ) {
                os = "mac";
            }
            
            return os;
        }
        
        
        
        
        public static bool runCommand(string command=null) {
            // ...
            return true;
        }
        
        
        
        
        /// <summary>
        /// Limpea la pantalla.
        /// Esta funcion se hace por los loles, porque ya existe Console.Clear(), y hace lo mismo.
        /// Si es windows se ejecuta el comando "cls", y es otro os el comando "clear". Supone que es tipo UNIX
        /// </summary>
        /// <returns>null</returns>
        public static void cleanScreen() {
            if ( getSystem() == "win" ) {
                Process.Start( "cls" );
            } else {
                Process.Start( "clear" );
            }
        }
    }

}