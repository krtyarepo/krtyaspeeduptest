using System;
using KrtyaShop.License.Domain;
using Nop.Core.Domain.Orders;
using Nop.Services.Events;
using KrtyaShop.License.Services;
using Nop.Core.Plugins;
using Nop.Core;

namespace KrtyaShop.License.Events
{
    public class OrderPaidEventConsumer : IConsumer<OrderPaidEvent>
    {
        #region Fields

        private readonly ILicenseServices _licenseServices;
        private readonly IPluginFinder _pluginFinder;
        private readonly IStoreContext _storeContext;

        #endregion

        #region Ctro

        public OrderPaidEventConsumer(ILicenseServices licenseServices, IPluginFinder pluginFinder, IStoreContext storeContext)
        {
            _licenseServices = licenseServices;
            _pluginFinder = pluginFinder;
            _storeContext = storeContext;
        }

        #endregion

        public void HandleEvent(OrderPaidEvent eventMessage)
        {
            var pluginDescriptor = _pluginFinder.GetPluginDescriptorBySystemName("KrtyaShop.License");
            if (pluginDescriptor == null)
                return;
            if (!_pluginFinder.AuthenticateStore(pluginDescriptor, _storeContext.CurrentStore.Id))
                return;

            var plugin = pluginDescriptor.Instance() as LicensePlugin;
            if (plugin == null)
                return;

            var order = eventMessage.Order;
            var licenseRecord = new LicenseRecord();
            licenseRecord.CustomerId = order.CustomerId;

            foreach(var product in order.OrderItems)
            {
                licenseRecord.ProductId = product.Id;    
            }

            licenseRecord.LicenseKey = "TempKey";
            licenseRecord.LicenseTypeId = (int)LicenseTypeEnum.Enterprise;
            licenseRecord.OrderId = order.Id;
            licenseRecord.SoftwareProductTypeId = (int)SoftwareProductType.WebApplication;
            licenseRecord.ProgrammingLanguages = "C#";
            licenseRecord.Framework = ".NET";
            licenseRecord.ExpiryDateUTC = DateTime.UtcNow.AddMonths(1);
            licenseRecord.LastRenewalDateUTC = DateTime.UtcNow.AddMonths(-1);
            licenseRecord.CreatedDateUTC = DateTime.UtcNow;
            licenseRecord.UpdatedDateUTC = DateTime.UtcNow;

            _licenseServices.InsertLicenseRecord(licenseRecord);
            
        }
    }
}
