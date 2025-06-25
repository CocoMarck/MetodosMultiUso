using MetodosMultiUso.Utils;
using System.IO;
using System;
using MetodosMultiUso.Core;



namespace MetodosMultiUso.Core.Config {

    public static class SystemUtilConf { 
        // Resource loader
        private static readonly ResourceLoader resource_loader = new ResourceLoader();

        // Constantes
        private const string NAME_RUN_COMMAND = "runCommand";
        private const string FILE_RUN_COMMAND = $"{NAME_RUN_COMMAND}.conf";
        private static readonly string PATH_RUN_COMMAND;
        private const string WIN_TERMINAL = "cmd.exe";
        private const string LINUX_TERMINAL = "x-terminal-emulator";
    
        private const string DEFAULT_INSTRUCTION = (
            $"# Aca se determina que terminal por defecto abrir\n" +
            $"linux_terminal={LINUX_TERMINAL}\n" +
            $"win_terminal={WIN_TERMINAL}"
        );
        
        // Constructor estatico.
        static SystemUtilConf() {
            // Establecer ruta
            PATH_RUN_COMMAND = resource_loader.combineConfigFile( FILE_RUN_COMMAND );
        
            //
            File.WriteAllText( PATH_RUN_COMMAND, DEFAULT_INSTRUCTION );
            string text = File.ReadAllText( PATH_RUN_COMMAND );
            Console.WriteLine( text );
        }
        
        // Funciones
        public static string getTerminalName() {
            string name_to_return = LINUX_TERMINAL;
            if (resource_loader.existsConfig() == false) {
                if ( SystemUtil.getSystem() == "linux" ) 
                   name_to_return = LINUX_TERMINAL;
                else if ( SystemUtil.getSystem() == "win" ) 
                   name_to_return = WIN_TERMINAL;
            }
            
            return name_to_return;
        }
        
    }
}