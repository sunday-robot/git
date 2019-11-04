using System;
using System.Collections.Generic;

namespace EasyPhisicsDotNet
{
    /// <summary>
    /// 形状(EpxShape)のコンテナ
    /// </summary>
    public class EpxCollidable
    {
        /// <summary>
        /// 形状の配列(C++版では最大5個と制限していた(秋山))
        /// </summary>
        public List<EpxShape> m_shapes = new List<EpxShape>();

        /// <summary>
        /// AABBの中心
        /// </summary>
        private EpxVector3 _Center;

        /// <summary>
        /// AABBのサイズの半分
        /// </summary>
        private EpxVector3 _Half;

        /// <summary>
        /// AABBの中心
        /// </summary>
        public EpxVector3 Center
        {
            get
            {
                return _Center;
            }
        }

        /// <summary>
        /// AABBのサイズの半分
        /// </summary>
        public EpxVector3 Half
        {
            get
            {
                return _Half;
            }
        }

        /// <summary>
        /// 形状を登録する。
        /// </summary>
        /// <param name="shape">形状</param>
        public void AddShape(EpxShape shape)
        {
            m_shapes.Add(shape);
        }

        /// <summary>
        /// 現在保持している形状(EpxShape)で、AABBを更新する。
        /// </summary>
        public void updateAABB()
        {
            var aabbMax = new EpxVector3(-float.MaxValue);
            var aabbMin = new EpxVector3(float.MaxValue);
            foreach (var shape in m_shapes)
            {
                foreach (EpxVector3 v in shape.Geometry.Vertices)
                {
                    aabbMax = _MaxPerElem(aabbMax, shape.Position + shape.Orientation.Rotate(v));
                    aabbMin = _MinPerElem(aabbMin, shape.Position + shape.Orientation.Rotate(v));
                }
            }
            _Center = (aabbMax + aabbMin) / 2;
            _Half = (aabbMax - aabbMin) / 2;
        }

        private static EpxVector3 _MaxPerElem(EpxVector3 a, EpxVector3 b)
        {
            return new EpxVector3(Math.Max(a.X, b.X), Math.Max(a.Y, b.Y), Math.Max(a.Z, b.Z));
        }

        private static EpxVector3 _MinPerElem(EpxVector3 a, EpxVector3 b)
        {
            return new EpxVector3(Math.Min(a.X, b.X), Math.Min(a.Y, b.Y), Math.Min(a.Z, b.Z));
        }
    }
}
