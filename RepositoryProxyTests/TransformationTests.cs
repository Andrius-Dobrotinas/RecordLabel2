using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AndrewD.RecordLabel.Data.EF.Access
{
    [TestClass]
    public class TransformationTests
    {
        [TestMethod]
        public void ReleaseWithNullReference()
        {
            var transformer = new EntityToModelTransformer();
            var dbModel = new Track()
            {
                Id = 1,
                Reference = null,
                Title = "Title"
            };

            var result = transformer.GetTrack(dbModel);

            Assert.AreEqual(dbModel.Id, result.Id, "Ids are not equal");
            Assert.AreEqual(dbModel.Reference, result.Reference, "References are not equal");
            Assert.AreEqual(dbModel.Title, result.Title, "Titles are not equal");
        }

        [TestMethod]
        public void ReferenceTransformation()
        {
            var transformer = new EntityToModelTransformer();
            var dbModel = new Reference()
            {
                Id = 1,
                Order = 5,
                Target = "Some target",
                Type = ReferenceType.Website
            };

            var result = transformer.GetReference(dbModel);

            Assert.AreEqual(dbModel.Id, result.Id, "Ids are not equal");
            Assert.AreEqual(dbModel.Order, result.Order, "Orders are not equal");
            Assert.AreEqual(dbModel.Target, result.Target, "Targets are not equal");
            Assert.AreEqual(dbModel.Type, result.Type, "Types are not equal");
        }

        [TestMethod]
        public void NullReferenceTransformation()
        {
            var transformer = new EntityToModelTransformer();
            Reference dbModel = null;

            var result = transformer.GetReference(dbModel);
            
            Assert.AreEqual(null, result);
        }
    }
}
