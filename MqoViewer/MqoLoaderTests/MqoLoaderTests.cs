using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mq;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mq.Tests
{
    [TestClass()]
    public class MqoLoaderTests
    {
        /// <summary>
        /// 内容のない(=Metasequoiaでドキュメントを新規作成した際の)ファイルのロード
        /// </summary>
        [TestMethod()]
        public void LoadEmptyFileTest()
        {
            var mqoData = MqoLoader.Load(@"..\..\data\empty.mqo");
            Assert.IsNotNull(mqoData.Scene);
            Assert.IsNull(mqoData.BackImage);
            Assert.AreEqual(0, mqoData.Materials.Count);
            Assert.AreEqual(0, mqoData.MQObjects.Count);
            // mqoData.Sceneは面倒なので無視
        }

        /// <summary>
        /// 背景画像があるファイルのロード
        /// </summary>
        [TestMethod()]
        public void LoadHasBackImageTest()
        {
            var mqoData = Mq.MqoLoader.Load(@"..\..\data\has_backimage.mqo");
            Assert.IsNotNull(mqoData.BackImage);
            Assert.AreEqual(@".\pers_backimage.jpg", mqoData.BackImage.Pers.FilePath);
        }

        /// <summary>
        /// オブジェクトがあるが、マテリアルが何もないファイルのロード
        /// </summary>
        [TestMethod()]
        public void LoadHasAnObjectButNoMaterialsTest()
        {
            var mqoData = MqoLoader.Load(@"..\..\data\has_an_object_but_no_materials.mqo");
            Assert.IsNotNull(mqoData.MQObjects);
            Assert.AreEqual(1, mqoData.MQObjects.Count);
            Assert.AreEqual(4, mqoData.MQObjects[0].Vertexes.Count);
            Assert.AreEqual(4, mqoData.MQObjects[0].Faces.Count);
            Assert.AreEqual(-1, mqoData.MQObjects[0].Faces[0].MaterialIndex);
        }

        [TestMethod()]
        public void LoadTest()
        {
            _LoadTest("..\\..\\data\\bulma_bike.mqo");
        }

        private static void _LoadTest(string filePath)
        {
            try
            {
                MqoLoader.Load(filePath);
            }
            catch (MqoLoaderException e)
            {
                Console.Write(e.GetOriginalException().ToString());
                Assert.Fail();
            }
            catch (Exception e)
            {
                Console.Write(e.ToString());
                Assert.Fail();
            }
        }
    }
}