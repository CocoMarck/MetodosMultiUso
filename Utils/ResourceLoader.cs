using static System.Console;
using System.IO;

namespace MetodosMultiUso.Utils {
    public class ResourceLoader {
        /*
        Establecer las rutas principales de trabajo.
        Rutas de trabajo: Config/, Resources/, Logs/, Data/, Docs/
        
        base_dir, sera la ruta principal/base.
        */
        
        public readonly string base_dir;
        public readonly string config_dir;
        public readonly string logs_dir;
        public readonly string data_dir;
        public readonly string docs_dir;
        public readonly string resource_dir;
        
        // Constructor de atributos | Establecer directorios de trabajo
        public ResourceLoader() {
            base_dir = Path.GetFullPath("./");
            config_dir = Path.Combine( base_dir, "Config" );
            logs_dir = Path.Combine( base_dir, "Logs" );
            data_dir = Path.Combine( base_dir, "Data" );
            docs_dir = Path.Combine( base_dir, "Docs" );
            resource_dir = Path.Combine( base_dir, "Resources" );
        }
        
        // Metodos
        // Determina si existen los archivos. 
        
        /// Establece si es un dir o un file, o si no existe
        public string? getPathType( string path ) {
            if ( File.Exists(path) ){
                return "file";
            } else if ( Directory.Exists(path) ){
                return "dir";
            } else {
                return null;
            }
        }
        
        /// Determina si existe un archivo
        public bool existsPath( string path ){
            return ( getPathType(path:path) is string );
        }
        
        public bool existsResource() {
            return Directory.Exists(resource_dir);
        }
        
        public bool existsConfig() {
            return Directory.Exists(config_dir);
        }

        /// Combinar `dir` con `file` Restrictivo, lo generado teiene que existir.
        /*
        Tiene que ser directorio, combinado con file o dir. O si no, no jala.
        */
        public string? restrictiveCombineFile( string directory, string file) {
            string? final_path = null;
            if ( getPathType(directory) == "dir" ) {
                final_path = Path.Combine( directory, file );
                if ( existsPath( final_path ) == false ){
                    final_path = null;
                }
            }
            return final_path;
        }

        // Combinar `Dir`, con `File` o `Dir`. Lo generado, no necesariamente tiene que exister.
        public string? combineResourceFile(string file) {
            return Path.Combine( resource_dir, file );
        } 
        
        public string? combineConfigFile(string file) {
            return Path.Combine( config_dir, file );
        }
        
        public string? combineLogFile(string file) {
            return Path.Combine( logs_dir, file );
        }
        /*
        */
    }
}