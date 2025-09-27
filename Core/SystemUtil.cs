using System;
using System.Runtime.InteropServices; // Para getSystem()
using System.Text;
using System.Diagnostics; // Para ejecutar comandos
using MetodosMultiUso.Core.Config;




namespace MetodosMultiUso.Core
{
    // 🔹 Solo importar `user32.dll` en Windows
    #if WINDOWS
    [DllImport("user32.dll")]
    public static extern int GetSystemMetrics(int nIndex);
    #endif

    public static class SystemUtil {
        // Constantes
        private static readonly string TERMINAL_NAME = SystemUtilConf.getTerminalName();
        
        
        
        /// <summary>
        /// Devuelve un string que indica el Sistema Operativo usado.
        /// </summary>
        /// <returns>string</returns>
        public static string getSystem() {
            string os = "other";
            if ( RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ) {
                os = "win";
            }
            else {
                os = "linux";
            }
            /*
            else if ( RuntimeInformation.IsOSPlatform(OSPlatform.Linux) ) {
                os = "linux";
            }
            else if ( RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ) {
                os = "mac";
            }
            */
            
            return os;
        }




        /// Obtener texto de argumentos para ejecutar comando
        public static string GetArgumentsForCommand( string? system=null, string command="" ) {
            string final_system = system ?? getSystem();

            string arguments;
            if (final_system == "win"){
                arguments = $"/C \"{command}\"";
            } else {
                arguments = $"-c \"{command}\"";
            }

            return arguments;
        }
        
        
        
        
        /// <summary>
        /// Limpea la pantalla.
        /// Esta funcion se hace por los loles, porque ya existe Console.Clear(), y hace lo mismo.
        /// Si es windows se ejecuta el comando "cls", y es otro os el comando "clear". Supone que es tipo UNIX
        /// </summary>
        /// <returns>null</returns>
        public static void cleanScreen() {
            string get_system = getSystem();
            if ( get_system == "win" ) {
                runCommand( "cls" );
            } else if ( get_system == "linux" || get_system == "mac" ) {
                runCommand( "clear" );
            }
        }
        
        
        

        // Determinar donde ejecutar comandos
        public static string getShellName() {
            string get_system = getSystem();
            string shell_name = "";
            if ( get_system == "win" ) {
                shell_name = "cmd.exe";
            } else if ( get_system == "linux" ) {
                shell_name = "/bin/bash";
            }
            
            return shell_name;
        }
        
        
        /// Función para ejecutar comando. Devuelve output del comando.
        public static string runCommand(
            string command="", bool shell_execute=true, bool external=false
        ){  
            string current_os = getSystem();

            // Determinar argumentos (comando de ejcución)         
            if ( external == true ) {
                shell_execute = false;

                if ( current_os == "win" ) {
                    command = $"{TERMINAL_NAME} /K {command} & pause";
                } else {
                    command = (
                     $"{TERMINAL_NAME} --hold -e " +
                     $"bash -c \"{command}; read; exit\""
                    );
                    //command = $"{TERMINAL_NAME} --hold -e bash -c \"{command}; read; exit\"";
                }

                // Mostrar comando
                Console.WriteLine( command );
            }
            string arguments = GetArgumentsForCommand( system:current_os, command:command );
            
            
            // Determinar si hacer que ProcessStartInfo devuelve o no la salida del comando.
            // Si no devuelve salida, el resultado se ve en la terminal.
            
            // Ejecutar comando
            ProcessStartInfo startInfo = new ProcessStartInfo() {
                Arguments = arguments,
                UseShellExecute = shell_execute,
                RedirectStandardOutput = !shell_execute,
                RedirectStandardError = !shell_execute,
                CreateNoWindow = shell_execute
            };
            
            startInfo.FileName = getShellName();

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
        
        
        
        
        /// <summary>Obtener salida (puro string) de comando ejecutado</summary>
        /// <returns>string</returns>
        public static string commandOutput( string command="" ) {
            string arguments = GetArgumentsForCommand( command:command );

            Process process = new Process();
            process.StartInfo.Arguments = arguments;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            
            process.StartInfo.FileName = getShellName();
            process.Start();
            
            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            return output;
        }
        
        
        
        /// Obtener servidor grafico usado.
        public static string getGraphicalServer() {
            if ( getSystem() == "linux"){
                return commandOutput("echo $XDG_SESSION_TYPE").Trim();
            }
            else if ( getSystem() == "win"){
                return "wddm";
            }
            
            return "Unknown";
        }
        
        
        
        /// Obtener resolución de pantalla actual en el OS
        public static int[] getDisplayResolution() {
            int[] width_height = {1,16};

            string graphical_server = getGraphicalServer();
            string character_separator = "x";
            string output = "";

            if (  graphical_server == "wddm" ) {
                // Usar user32.dll
                #if WINDOWS
                width_height[0] = GetSystemMetrics(0);
                width_height[1] = GetSystemMetrics(1);
                #endif
            } 
            else if ( graphical_server == "x11" || graphical_server == "wayland") {
                // Actualmente nomas jala para x11. 
                // Despues crear func para detectar si se usa Wayland.
                output = commandOutput( "xrandr | grep '*' | awk '{print $1}'" );
                
                // Determinar que el output no ta vacio, y que contiene el caracter "x"
                character_separator = "x";
                

                // Separar valores ancho y largo, convertirlos de string a int, y ponerlos.
                if ( !string.IsNullOrEmpty(output) && output.Contains(character_separator) ) {
                    string[] parts = output.Split(character_separator);
                    width_height[0] = int.Parse(parts[0]);
                    width_height[1] = int.Parse(parts[1]);
                }
            }
            
            // Retorno
            return width_height;
        }
    
    }

}
