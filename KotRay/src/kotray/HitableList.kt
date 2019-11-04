package kotray

/**
 * [Ray]と[Hitable]の衝突情報
 */
class HitableList(private val list: List<Hitable>) {
    fun hit(r: Ray, tMin: Double, tMax: Double): HitRecord? {
        var hitRecord: HitRecord? = null
        var closestSoFar = tMax
        for (hitable in list) {
            val tmp = hitable.hit(r, tMin, closestSoFar)
            if (tmp != null) {
                closestSoFar = tmp.t
                hitRecord = tmp
            }
        }
        return hitRecord
    }
}
