using System;
using System.Runtime.InteropServices; // Para getSystem()
using System.Text;
using System.Diagnostics; // Para ejecutar comandos




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
        
        
        
        /// Función para ejecutar comando. Devuelve output del comando.
        public static string runCommand(
            string command=null, bool shell_execute=true, bool external=false
        ){
            // Determinar si hacer que ProcessStartInfo devuelva o no la salida del comando.
            // Si no devuelve salida, el resultado se ve en la terminal.
            bool redirect_standard_output = true;
            bool redirect_standard_error = true;
            if ( shell_execute == true ) {
                redirect_standard_output = false;
                redirect_standard_error = false;
            }

            // Ejecutar comando
            ProcessStartInfo startInfo = new ProcessStartInfo() {
                Arguments = "-c \" " + command + " \"",
                UseShellExecute = shell_execute,
                RedirectStandardOutput = redirect_standard_output,
                RedirectStandardError = redirect_standard_error,
                CreateNoWindow = true    
            };
            
            if ( getSystem() == "win" ) {
                startInfo.FileName = "cmd.exe";
            } else {
                startInfo.FileName = "/bin/bash";
            }

            Process process = new Process() { StartInfo=startInfo };
            process.Start();

            // Obtener o no la salida del comando | String a devolver
            string output = command;
            if ( shell_execute == false ) {
                // Se supone que StandardOutput.ReadToEnd(), siempre devuelve string.
                try {
                    output = $"{process.StandardOutput.ReadToEnd()}";
                }
                catch (Exception e) {
                    output = $"ERROR:\n{e}";
                }
            }
            
            // Salir del proceso, asegurando que se libere la memoria correctamente.
            process.WaitForExit();
            process.Close();
            
            // Devolver un string
            return output;
        }
        
        
        
        
        /// <summary>
        /// Limpea la pantalla.
        /// Esta funcion se hace por los loles, porque ya existe Console.Clear(), y hace lo mismo.
        /// Si es windows se ejecuta el comando "cls", y es otro os el comando "clear". Supone que es tipo UNIX
        /// </summary>
        /// <returns>null</returns>
        public static void cleanScreen() {
            if ( getSystem() == "win" ) {
                runCommand( "cls" );
            } else {
                runCommand( "clear" );
            }
        }
    }

}