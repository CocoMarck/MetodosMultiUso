using MetodosMultiUso.Core;

namespace MetodosMultiUso.Core {
    public static class DisplayScaleNumber {

        public static readonly int[] DISPLAY_RESOLUTION;

        static DisplayScaleNumber() {
            DISPLAY_RESOLUTION = SystemUtil.getDisplayResolution();
        }

        /*
        Obtener numero flotante basado en la resolucion `x` o `y` de pantalla.
        */
        public static float getScaldedNumber(
         float multipler=0, int divisor=0, string based="width"
        ){
            float number = 0;
            return number;
        }
    }
}
