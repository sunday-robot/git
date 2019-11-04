package kotray

abstract class Hitable {
    /**
     * @param ray [Ray]
     * @return ヒットする場合は[Hitable]、そうでない場合はnull
     */
    abstract fun hit(ray: Ray, tMin: Double, tMax: Double): HitRecord?
}
