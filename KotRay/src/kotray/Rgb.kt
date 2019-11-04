package kotray

/**
 * 色(光)
 * @param red :
 * @param green :
 * @param  blue :
 */
data class Rgb(val red: Double, val green: Double, val blue: Double) {
    operator fun plus(rgb: Rgb): Rgb = Rgb(red + rgb.red, green + rgb.green, blue + rgb.blue)

    operator fun times(rgb: Rgb): Rgb = Rgb(red * rgb.red, green * rgb.green, blue * rgb.blue)

    operator fun times(s: Double): Rgb = Rgb(red * s, green * s, blue * s)

    operator fun div(s: Double): Rgb = Rgb(red / s, green / s, blue / s)
}
