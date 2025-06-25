using System;
using MetodosMultiUso.Core;
using MetodosMultiUso.Core.Config;
using MetodosMultiUso.Utils;

/*
mcs -out:Program.exe Program.cs Core/SystemUtil.cs Core/ShowPrint.cs
mono Program.exe 
*/

public static class Program {
    static void Main() {
        ShowPrint.input( "Primero que nada ve los warnings (Si es que hay)");
    
        // cleanScreen | title | separator
        SystemUtil.cleanScreen(); // Console.Clear()
        
        // SystemUtilConf
        Console.WriteLine( 
            SystemUtilConf.getTerminalName()     
        );

        // Usando resorce loader
        ResourceLoader resource_loader = new ResourceLoader();
        Console.WriteLine( 
            $"{resource_loader.base_dir}\n{resource_loader.config_dir}\n{resource_loader.resource_dir}\n" +
            $""
        );
        Console.WriteLine( resource_loader.getPathType("./Core") );
        Console.WriteLine(
            resource_loader.restrictiveCombineFile( resource_loader.base_dir, "Program.cs" )
        );
        Console.WriteLine(
            Path.Combine( resource_loader.config_dir, "runCommand.ini" )
        );
        
        
        
        
        // log text archivo log
        string log_file_path = resource_loader.combineLogFile( "log.md" );
        string log_text = "";
        
        
        
        
        // ShowPrint
        log_text += ShowPrint.printAndReturn(
            ShowPrint.title( text: "Probando todos los modulos", console: false ) + "\n" +

            "Aca veremos como se usan los modulos locos, por ejemplo, ve como jala " +
            "`ShowPrint.inputContinue`:"
        );

        bool go = ShowPrint.inputContinue( message_error: true );
        if (go == true) {
            log_text += ShowPrint.printAndReturn( "Continuamos..." );
        }
        else {
            log_text += ShowPrint.printAndReturn( "Igualmente vamos a continuar..." );
        }
        
        log_text += ShowPrint.printAndReturn( ShowPrint.separator(), console:false );
        

        // Usando "title"
        log_text += ShowPrint.printAndReturn( 
            ShowPrint.title( "Como se muestra por defecto `ShowPrint.title`" ), console:false
        );

        log_text += ShowPrint.printAndReturn(
            "Por defecto el metodo `title`, se muestra asi:\n    " +
            ShowPrint.title( console: false ) + "\n" +
            
            "Tambien se le pueden cambiar su diseño:\n    "+
            ShowPrint.title(
                text: "Espacio", 
                character: "@", space: 8, console: false
            ) + "\n\n" +
            
            "No te dites cuenta pero ya se esta usando otro metodo, se llama `ShowPrint.separator` " +
            "este sirve para mostrar sparaciones visuales, mira esta sparación, " +
            "usando el caracter `^`(con 100 de estos caracteres):\n" +
            
            ShowPrint.separator( character: "^", number: 100, console:false ) + 
            
            "Bueno, ahora veremos como funcan otras funciones/metodos."
        );
        ShowPrint.input( "Preciona enter para continuar..." );
        log_text += ShowPrint.printAndReturn( ShowPrint.separator(), console:false );
        
        
        
        
        // Usando ShowPrint.codeText
        log_text += ShowPrint.printAndReturn( ShowPrint.title("Usando ShowPrint.codeText"), console:false );
        log_text += ShowPrint.printAndReturn( ShowPrint.codeText(), console:false);

        log_text += ShowPrint.printAndReturn(
            ShowPrint.codeText( "print('Hello world')", "python", false )
        );

        log_text += ShowPrint.printAndReturn( 
            ShowPrint.codeText( 
                "ShowPrint.codeText( string text, string text_type, bool console );",
                "csharp"
            ), console:false
        );

        ShowPrint.input( "Preciona enter para continuar..." );
        
        


        // Usando SystemUtil
        SystemUtil.cleanScreen(); //Console.Clear(); 
        
        string system_name = SystemUtil.getSystem();
        log_text += ShowPrint.printAndReturn(
            ShowPrint.title( "Usando `SystemUtil`", console:false ) + "\n" +
          
            $"El sistema operativo que estas usando es: `{system_name}`.\n" +
            "El metodo que se uso para saber el OS, es `SystemUtil.getSystem`."
        );
        
        ShowPrint.input( 
            "Ahora vamos a abrir una terminal\n"  +
            "Preciona enter para ver la terminal..."
        );
        log_text += ShowPrint.printAndReturn(
            SystemUtil.runCommand( command:"neofetch", external:true ), console:false
        );
        
        log_text += ShowPrint.printAndReturn( ShowPrint.separator(), console:false );
        
        string home_environment_variable = "$HOME";
        log_text += ShowPrint.printAndReturn(
            ShowPrint.title( "Mostrar string de comando", console:false ) 
        );
        if ( system_name == "win" ) {
            home_environment_variable = "%%USERPROFILE%%";
        }
        log_text += ShowPrint.printAndReturn(
            $"`{home_environment_variable}` es: " + SystemUtil.commandOutput( "echo $HOME" ) 
        );
        log_text += ShowPrint.printAndReturn();
        
        log_text += ShowPrint.printAndReturn( 
            ShowPrint.title( "Mostrar resolución de pantalla" ), false 
        );
        int[] display = SystemUtil.getDisplayResolution();
        log_text += ShowPrint.printAndReturn(
            "La resolución de pantalla, indica como se mostraran las imagenes, la cantidad de pixeles " +
            "que se podran mostrar.\n" +
            $"La resolucion de pantalla es: {display[0]}x{display[1]}" 
        );
        log_text += ShowPrint.printAndReturn();
        
        log_text += ShowPrint.printAndReturn( 
            ShowPrint.title( "Mostrar servidor grafico" ), false 
        );
        log_text += ShowPrint.printAndReturn(
            "El servidor grafico, es el que dibuja todo en pantalla, muy bonito.\n" +
            $"El servidor grafico es: `{SystemUtil.getGraphicalServer()}`" 
        );
        log_text += ShowPrint.printAndReturn();
        
        
        
        
        // log text, guardar
        File.WriteAllText( log_file_path, log_text );
    }
}