using System;
using MetodosMultiUso.Core;

/*
mcs -out:Program.exe Program.cs Core/SystemUtil.cs Core/ShowPrint.cs
mono Program.exe 
*/

public static class Program {
    static void Main() {
        // cleanScreen | title | separator
        SystemUtil.cleanScreen(); // Console.Clear()
        ShowPrint.title( text: "Probando todos los modulos", console: true );
        Console.WriteLine( 
            "Aca veremos como se usan los modulos locos, por ejemplo, ve como jala " +
            "`ShowPrint.inputContinue`:"
        );

        bool go = ShowPrint.inputContinue( message_error: true );
        if (go == true) {
            Console.WriteLine( "Continuamos..." );
        }
        else {
            Console.WriteLine( "Igualmente vamos a continuar..." );
        }
        
        ShowPrint.separator( console: true );
        

        // Usando "title"
        ShowPrint.title( "Como se muestra por defecto ShowPrint.title", console: true );
        Console.WriteLine( 
            "Por defecto el metodo `title`, se muestra asi:\n    " +
            ShowPrint.title( console: false ) + "\n" +
            
            "Tambien se le pueden cambiar su diseño:\n    "+
            ShowPrint.title(
                text: "Espacio", 
                character: "@", space: 8, console: false
            ) + "\n\n" +
            
            "No te dites cuenta pero ya se esta usando otro metodo, se llama `ShowPrint.separator` " +
            "este sirve para mostrar dar sparaciones visuales, mira esta sparación, " +
            "usando el caracter `^`(con 100 de estos caracteres):\n" +
            
            ShowPrint.separator( character: "^", number: 100, console:false ) + 
            
            "Bueno, ahora veremos como funcan otras funciones/metodos."
        );
        ShowPrint.input( "Preciona enter para continuar..." );
        
        ShowPrint.separator();
        
        
        // Usando ShowPrint.codeText
        ShowPrint.title( "Usando ShowPrint.codeText" );
        ShowPrint.codeText( );

        Console.Write(
            ShowPrint.codeText( "print('Hello world')", "python", false )
        );

        ShowPrint.codeText( 
            "ShowPrint.codeText( string text, string text_type, bool console );",
            "csharp"
        );

        ShowPrint.input( "Preciona enter para continuar..." );
        
        


        // Usando SystemUtil
        //ShowPrint.separator(console: true);
        SystemUtil.cleanScreen(); //Console.Clear(); 
        
        ShowPrint.title( "Usando `SystemUtil`", console:true );
        Console.WriteLine(
            $"El sistema operativo que estas usando es: {SystemUtil.getSystem()}.\n" +
            "El metodo que se uso para saber el OS, es `SystemUtil.getSystem`."
        );
        
        ShowPrint.input( 
            "Ahora vamos a abrir una terminal\n"  +
            "Preciona enter para ver la terminal..."
        );
        SystemUtil.runCommand( command:"neofetch", external:true );
        
        Console.Write( "$HOME es: " + SystemUtil.commandOutput( "echo $HOME" ) );
        
        int[] display = SystemUtil.getDisplayResolution();
        Console.WriteLine( $"La resolucion de pantalla es: {display[0]}x{display[1]}" );
        
        Console.WriteLine( SystemUtil.getGraphicalServer() );
    }
}