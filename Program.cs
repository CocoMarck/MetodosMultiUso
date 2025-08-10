using System;
using MetodosMultiUso.Core;
using MetodosMultiUso.Core.Config;
using MetodosMultiUso.Utils;
using System.Collections.Generic;

/*
mcs -out:Program.exe Program.cs Core/SystemUtil.cs Core/ShowPrint.cs
mono Program.exe 
*/

public static class Program {
    static void Main() {
        ShowPrint.input( "Primero que nada ve los warnings (Si es que hay)");
    
        // cleanScreen | title | separator
        SystemUtil.cleanScreen(); // Console.Clear()
        
        
        
        
        // log text archivo log | ResoourceLoader
        ResourceLoader resource_loader = new ResourceLoader();
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
        
        
        
        
        // SystemUtilConf
        log_text += ShowPrint.printAndReturn( ShowPrint.title( text:"`SystemUtilConf`", console:false) );
        log_text += ShowPrint.printAndReturn(
            $"Terminal a ejecutar: `{SystemUtilConf.getTerminalName()}`"
        );
        log_text += ShowPrint.printAndReturn( ShowPrint.separator(console:false) );
        
        
        
        
        // Usando resorce loader
        log_text += ShowPrint.printAndReturn( ShowPrint.title( text:"`ResourceLoader`", console:false) );
        log_text += ShowPrint.printAndReturn(
            $"Rutas locas:\n```\n" +
            $"{resource_loader.base_dir}\n{resource_loader.config_dir}\n{resource_loader.resource_dir}\n" +
            $"```"
        );
        log_text += ShowPrint.printAndReturn(
            "- Obtener tipo de ruta: " + resource_loader.getPathType("./Core") 
        );
        log_text += ShowPrint.printAndReturn(
            "- Combinación restrictiva: `"+
            resource_loader.restrictiveCombineFile( resource_loader.base_dir, "Program.cs" ) + "`"
        );
        log_text += ShowPrint.printAndReturn(
            "- Combinación normal: `"+
            Path.Combine( resource_loader.config_dir, "runCommand.conf" ) + "`"
        );
        log_text += ShowPrint.printAndReturn( ShowPrint.separator(console:false) );
        

        
        
        // Usando ShowPrint "title"
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
        ShowPrint.printAndReturn("\n\n");
        
        


        // Usando SystemUtil
        
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
        log_text += ShowPrint.printAndReturn( ShowPrint.separator(console:false) );
        
        
        
        
        // Usando TextUtil `readText`
        log_text += ShowPrint.printAndReturn( ShowPrint.title("`TextUtil.readText`"), console:false );
        
        log_text += ShowPrint.printAndReturn("text:");
        string run_command_text = (string)TextUtil.readTextFile( file: SystemUtilConf.PATH_RUN_COMMAND );
        log_text += ShowPrint.printAndReturn("```");
        log_text += ShowPrint.printAndReturn( run_command_text);
        log_text += ShowPrint.printAndReturn("```\n\n");
        
        
        log_text += ShowPrint.printAndReturn("array:");
        string[] run_command_array = (string[])TextUtil.readTextFile( 
            file: SystemUtilConf.PATH_RUN_COMMAND, return_type:"array"
        );
        log_text += ShowPrint.printAndReturn("```");
        foreach (string line in run_command_array) {
            log_text += ShowPrint.printAndReturn( line );
        }
        log_text += ShowPrint.printAndReturn("```");
        log_text += ShowPrint.printAndReturn("\n");
        
        
        log_text += ShowPrint.printAndReturn("list:");
        List<string> run_command_list = (List<string>)TextUtil.readTextFile( 
            file: SystemUtilConf.PATH_RUN_COMMAND, return_type:"list"
        );
        log_text += ShowPrint.printAndReturn("```");
        foreach (string line in run_command_list) {
            log_text += ShowPrint.printAndReturn(line);
        }
        log_text += ShowPrint.printAndReturn("```");
        log_text += ShowPrint.printAndReturn("\n");
        
        
        log_text += ShowPrint.printAndReturn("dictionary:");
        Dictionary<int, string> run_command_dict = (Dictionary<int, string>)TextUtil.readTextFile(
            file: SystemUtilConf.PATH_RUN_COMMAND, return_type:"dictionary"
        );
        log_text += ShowPrint.printAndReturn("```");
        foreach (var element in run_command_dict) {
            log_text += ShowPrint.printAndReturn($"{element.Key}. {element.Value}");
        }
        log_text += ShowPrint.printAndReturn("```");
        log_text += ShowPrint.printAndReturn("\n");
        
        
        // TextUtil.ignoreComment
        log_text += ShowPrint.printAndReturn( ShowPrint.title("`TextUtil.ignoreComment`"), console:false );
        log_text += ShowPrint.printAndReturn( 
            TextUtil.ignoreComment( text:"Ejemplo # Comentario\nTexto\n# Chido") 
        );
        log_text += ShowPrint.printAndReturn( 
            TextUtil.ignoreComment( text:run_command_text )  + "\n"
        );
        
        // TextUtil.matixLineBreaks
        ShowPrint.title("TextUtil.matrixLineBreaks");
        foreach( string line in TextUtil.matixLineBreaks() ) {
            ShowPrint.printAndReturn( line );
        }
        ShowPrint.printAndReturn("\n");
        
        // TextUtil.separeText
        ShowPrint.title("TextUtil.separeText");
        foreach( var element in TextUtil.separeText() ) {
            ShowPrint.printAndReturn( $"Key: {element.Key}. Value: {element.Value}" );
        }
        ShowPrint.printAndReturn("\n");
        
        // TextUtil.onlyTheComment
        ShowPrint.title( "TextUtil.onlyTheComment" );
        ShowPrint.printAndReturn( TextUtil.onlyTheComment("#Comentario# Comentario\nTexto") );
        ShowPrint.printAndReturn( "\n" );
        
        


        // Seccion pruebas de Filtrar texto.
        // TextUtil.filteredTextDictionary
        ShowPrint.title( "TextUtil.filteredTextDictionary" );
        foreach( var element in TextUtil.filteredTextDictionary() ) {
            ShowPrint.printAndReturn( $"Key: {element.Key}. Value: {element.Value}" );
        }
        ShowPrint.printAndReturn("\n");
        
        // TextUtil.passTextFilter
        ShowPrint.title( "TextUtil.passTextFilter" );
        ShowPrint.printAndReturn( $"{TextUtil.passTextFilter()}\n"  );
        
        // TextUtil.ignoreTextFilter
        ShowPrint.title( "TextUtil.ignoreTextFilter" );
        ShowPrint.printAndReturn( 
         TextUtil.ignoreTextFilter( 
            text: "Texto chido", 
            filter: TextUtil.FILTER_ABC
         ) + "\n"  
        );
        
        // TextUtil.arrayAlphabet
        ShowPrint.title( "`TextUtil.arrayAlphabet`" );
        string[] for_array_alphabet = {"Volvo", "BMW", "Ford", "Mazda", "1@"};
        string[] test_array_alphabet = TextUtil.arrayAlphabet( for_array_alphabet );
        foreach( string item in test_array_alphabet ) {
            ShowPrint.printAndReturn( item );
        }
        ShowPrint.printAndReturn( "\n" );
        
        // TextUtil.arrayNotRepeatItem
        ShowPrint.title( "`TextUtil.arrayNotRepeatItem`" );
        string[] items = {"hola", "hola", "adios", "hola", "adios"};
        string[] not_repeat_item = TextUtil.arrayNotRepeatItem(items);
        foreach( string i in not_repeat_item ) {
            ShowPrint.printAndReturn(i);
        }
        ShowPrint.printAndReturn( "\n" );
        
        // TextUtil.textOrNone
        ShowPrint.title("`TextUtil.textOrNone`");
        ShowPrint.printAndReturn( TextUtil.textOrNone("Perro loco") );
        ShowPrint.printAndReturn( TextUtil.textOrNone("") );
        ShowPrint.printAndReturn( TextUtil.textOrNone(null) );
        
        
        
        
        // log text, guardar
        File.WriteAllText( log_file_path, log_text );
    }
}