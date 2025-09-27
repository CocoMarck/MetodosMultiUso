using MetodosMultiUso.Core;

namespace MetodosMultiUso.Core {
    public static class DisplayScaleNumber {

        public static readonly int[] DisplayResolution;
        public const float PixelLimit = 4;

        static DisplayScaleNumber() {
            DisplayResolution = SystemUtil.getDisplayResolution();
        }

        public static int GetSideOfResolution(
            int[] resolution, string based="width"
        ){
            if (based == "width") {
                return resolution[0];
            } else {
                return resolution[1];
            }
        }

        /// Obtener numero multiplicado o dividido, pioridad por multiplicar.
        public static float MultiplierOrDivideNumber(
         float number, float multiplier=0, float divisor=0
        ){
            if (multiplier != 0) {
                return number*multiplier;
            } else if (divisor != 0) {
                return number/divisor;
            } else {
                return (float)0;
            }
        }


        /*
        Obtener numero flotante basado en la resolucion `x` o `y` de pantalla.
        */
        public static float GetScaledNumber(
         float multiplier=0, float divisor=0, string based="width", int[]? resolution=null
        ){
            // Determinar la dimención seleccionada
            int[] currentResolution = resolution ?? DisplayResolution;

            float dimensionNumber = (float)GetSideOfResolution(
                resolution:currentResolution, based:based
            );

            // Establecer el valor final
            float finalNumber = MultiplierOrDivideNumber(
             number:dimensionNumber, multiplier:multiplier, divisor:divisor
            );

            // Limite | Asegurarse de que el numero no sea inposible de implementar
            if (finalNumber < PixelLimit) {
                finalNumber = PixelLimit;
            }

            return finalNumber;
        }


        /*
        Obtener dos numeros flotantes basados en la resolucion `x` o `y` de pantalla.
        */
        public static float[] GetScaledNumbers(
            float multiplier=0, float divisor=0, int[]? resolution=null
        ){
            // Determinar la dimención seleccionada
            int[] currentResolution = resolution ?? DisplayResolution;

            // Obtener valores escalados
            float[] scaledNumbers = {
                MultiplierOrDivideNumber(
                 (float)currentResolution[0], multiplier:multiplier, divisor:divisor
                ),
                MultiplierOrDivideNumber(
                 (float)currentResolution[1], multiplier:multiplier, divisor:divisor
                )
            };

            return scaledNumbers;
        }

    }
}
