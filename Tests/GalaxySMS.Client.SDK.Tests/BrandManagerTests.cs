using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Client.Entities;
using GalaxySMS.Client.SDK.DataClasses;
using GalaxySMS.Client.SDK.Managers;
using NUnit.Framework;

namespace GalaxySMS.Client.SDK.Tests
{
    public class BrandManagerTests: GalaxySMSClientSDKManagerTestBase
    {
        private BrandManager _brandManager;
        [SetUp]
        public override void Setup()
        {
            _brandManager = SDK.Helpers.Helpers.GetManager<BrandManager>(MagicStrings.ServerAddress,
                            GalaxySiteServerConnectionSettings.WcfBindingType.Tcp, string.Empty, string.Empty, SessionHeader);
        }

        [TearDown]
        public override void TearDown()
        {

        }

        [Test]
        public void GetAllBrands()
        {
            var brands = _brandManager.GetAllBrands(new Entities.GetParametersWithPhoto());

            // Assert
            Assert.NotNull(brands);
        }


        [Test]
        public async Task GetAllBrandsAsync()
        {
            var brands = await _brandManager.GetAllBrandsAsync(new Entities.GetParametersWithPhoto());

            // Assert
            Assert.NotNull(brands);
        }

        [Test]
        public async Task AddUpdateDeleteBrandAsync()
        {
            // Arrange
            var parameters = new SaveParameters<Brand>();
            parameters.Data = new Brand();
            parameters.Data.BrandName = "Test Brand Name";
            parameters.Data.Category = "Test Category";
            parameters.Data.CompanyName = "Test Company";

            var brand = await _brandManager.SaveBrandAsync(parameters);

            // Assert
            Assert.NotNull(brand);

            brand.BrandName = "Digital";
            parameters.Data = brand;
            brand = await _brandManager.SaveBrandAsync(parameters);
            Assert.AreEqual(brand.BrandName, parameters.Data.BrandName);

            var getParameters = new GetParametersWithPhoto();
            getParameters.UniqueId = brand.BrandUid;
            brand = await _brandManager.GetBrandAsync(getParameters);

            Assert.IsNotNull(brand);

            var deleteParameters = new DeleteParameters<Brand>();
            deleteParameters.Data = brand;

            await _brandManager.DeleteBrandAsync(deleteParameters);
            Assert.IsTrue(_brandManager.Errors.Count == 0);

            getParameters = new GetParametersWithPhoto();
            getParameters.UniqueId = brand.BrandUid;
            brand = await _brandManager.GetBrandAsync(getParameters);
        }
    }
}
