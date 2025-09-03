using System.Collections.Generic; // Para Dict y List
using static System.Console; // Para datetime

namespace MetodosMultiUso.Core {
    public static class TimeUtil {
        public const int MULTIPLER_MILLISECOND = 1;
        public const int MULTIPLER_SECOND = 1000;
        public const int MULTIPLER_MINUTE = 60;
        public const int MULTIPLER_HOUR = 60;
        public const int MULTIPLER_DAY = 24;

        public static readonly int MILLISECOND;
        public static readonly int MILLISECOND_PER_SECOND;
        public static readonly int MILLISECOND_PER_MINUTE;
        public static readonly int MILLISECOND_PER_HOUR;
        public static readonly int MILLISECOND_PER_DAY;
        
        public static readonly Dictionary<string, int> TIME_VALUES = new Dictionary<string, int>();
        public static readonly Dictionary<string, int> TIME_MULTIPLER = new Dictionary<string, int>();
        
        public const string DATETIME_FORMAT = "yyyy-MM-ddTHH:mm:ss";
        
        // Constructor
        static TimeUtil(){
            MILLISECOND = 1 * MULTIPLER_MILLISECOND;
            MILLISECOND_PER_SECOND = MILLISECOND * MULTIPLER_SECOND;
            MILLISECOND_PER_MINUTE = MILLISECOND_PER_SECOND * MULTIPLER_MINUTE;
            MILLISECOND_PER_HOUR = MILLISECOND_PER_MINUTE * MULTIPLER_HOUR;
            MILLISECOND_PER_DAY = MILLISECOND_PER_HOUR * MULTIPLER_DAY;
            
            TIME_VALUES.Add( "millisecond", MILLISECOND);
            TIME_VALUES.Add( "second", MILLISECOND_PER_SECOND);
            TIME_VALUES.Add( "minute", MILLISECOND_PER_MINUTE);
            TIME_VALUES.Add( "hour", MILLISECOND_PER_HOUR);
            TIME_VALUES.Add( "day", MILLISECOND_PER_DAY);
            
            TIME_MULTIPLER.Add( "millisecond", MULTIPLER_MILLISECOND );
            TIME_MULTIPLER.Add( "second", MULTIPLER_SECOND );
            TIME_MULTIPLER.Add( "minute", MULTIPLER_MINUTE );
            TIME_MULTIPLER.Add( "hour", MULTIPLER_HOUR );
            TIME_MULTIPLER.Add( "day", MULTIPLER_DAY );
        }
        
        
        
        /*
        /// Funcion milisegundos, segundos, minutos, horas, dias.
        /// Obtener el valor en milisegundos, segundos, minutos, horas, o dias.
        Permite converitr el valor de `x` de tipo `y` a tipo `z`. Donde los tipo `y` y `z`, pueden ser:
        millisecond, second, minute, hour, day.
        
        Ejemplo de uso:
        ```csharp
        decimal number = getTime( 60, "minute", "hour");
        ```
        Resultado: `1.0`
        */
        public static decimal getDecimalTime( 
         int number, string type_of_value = "minute", string convert_to = "hour" 
        ) {
            decimal final_number = 0;
            
            // Los tipo de valor deben existir en el diccionario TIME_VALUES
            if (TIME_VALUES.ContainsKey(type_of_value) && TIME_VALUES.ContainsKey(convert_to)){
                int millisecond_value = number * TIME_VALUES[type_of_value];
                
                if ( TIME_VALUES[type_of_value] == TIME_VALUES[convert_to] ){
                    // No hacer nadota
                    final_number = Convert.ToDecimal(number);
                } else {
                    // Dividir, acción que convertira el valor al indicado.
                    final_number = (
                     Convert.ToDecimal(millisecond_value) / 
                     Convert.ToDecimal(TIME_VALUES[convert_to])
                    );
                }
            }
            
            // Retornar
            return final_number;
        }




        /// Establecer texto de tiempo formateado.
        public static string getDateTimeFormatted( DateTime datetime ) {
            string month_text = datetime.Month.ToString("D2");
            string day_text = datetime.Day.ToString("D2");
            string hour_text = datetime.Hour.ToString("D2");
            string minute_text = datetime.Minute.ToString("D2");
            string second_text = datetime.Second.ToString("D2");

            string datetime_text = (
             $"{datetime.Year}-{month_text}-{day_text}T" +
             $"{hour_text}:{minute_text}:{second_text}"
            );
            return datetime_text;
        }
        
        
        
        
        /// Obtener tiempo actual
        public static string getDateTime() {
            DateTime datetime = DateTime.Now;
            string datetime_text = getDateTimeFormatted( datetime );
            return datetime_text;
        }


        // Obtener datetime de dia acutal
        public static DateTime currentDateTime() {
            return DateTime.Now;
        }


        /// Obtener dia inicial de un mes
        public static string getFirstDayOfTheMonth( DateTime? datetime = null ) {
            /*
            Ayuda:
            ```
            type func( type param? = null )
                type final_value = param ?? DEFAULT_VALUE;
            ```
            */

            // Agregar parametro, si no es nulo, de lo contrario poner fecha actual.
            DateTime dt = datetime ?? DateTime.Now;

            // Establecer tiempo correctamente
            dt = dt.AddDays( -dt.Day +1 ).AddHours( -dt.Hour ).AddMinutes( -dt.Minute ).AddSeconds( -dt.Second );

            // Tiempo en string estructurado
            return getDateTimeFormatted( dt );
        }



        /// Obtener dia final del mes
    
    
    
    
    }
}
