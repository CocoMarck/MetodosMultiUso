using MetodosMultiUso.Utils;
using System.IO;
using System;
using System.Collections.Generic;
using MetodosMultiUso.Core;



namespace MetodosMultiUso.Core.Config {

    public static class SystemUtilConf { 
        // Resource loader
        private static readonly ResourceLoader resource_loader = new ResourceLoader();

        // Constantes
        private const string NAME_RUN_COMMAND = "runCommand";
        private const string FILE_RUN_COMMAND = $"{NAME_RUN_COMMAND}.conf";
        public static readonly string PATH_RUN_COMMAND;
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
        
            // Escribir texto
            File.WriteAllText( PATH_RUN_COMMAND, DEFAULT_INSTRUCTION );
            string text = File.ReadAllText( PATH_RUN_COMMAND );
        }
        
        // Funciones
        public static string getTerminalName() {
            string name_to_return = LINUX_TERMINAL;
            
            if (resource_loader.existsPath(PATH_RUN_COMMAND) == true) {
                // Leer texto
                string text_file = TextUtil.ignoreComment(
                    text: (string)TextUtil.readTextFile( file: PATH_RUN_COMMAND, return_type: "text" )
                );

                // Establecer valores
                Dictionary<string, string> terminal_variables = new Dictionary<string, string>();
                foreach (string line in text_file.Split("\n") ){
                    string[] var_value = line.Split("=");
                    if (var_value.Length >= 2){
                        terminal_variables.Add( ( var_value[0].Trim() ).ToLower(), var_value[1]);
                    }
                }

                // Obtener terminales por medio del archivo de configuracion
                if ( SystemUtil.getSystem() == "linux" ) 
                    name_to_return = terminal_variables["linux_terminal"];
                else if ( SystemUtil.getSystem() == "win" )
                    name_to_return = terminal_variables["win_terminal"];
                
            } else { 
                // Obtener terminales, pero del modo default
                if ( SystemUtil.getSystem() == "linux" ) 
                   name_to_return = LINUX_TERMINAL;
                else if ( SystemUtil.getSystem() == "win" ) 
                   name_to_return = WIN_TERMINAL;
            }
            
            return name_to_return;
        }
        
    }
}